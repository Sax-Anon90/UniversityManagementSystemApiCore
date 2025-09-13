using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UniManagementSystem.Application.Common;
using UniManagementSystem.Application.RepositoryInterfaces.AdminAccountRoles;
using UniManagementSystem.Application.RepositoryInterfaces.AdminAccounts;
using UniManagementSystem.Application.RepositoryInterfaces.JwtService;
using UniManagementSystem.Application.RepositoryInterfaces.PasswordService;
using UniManagementSystem.Application.RepositoryInterfaces.StudentAccounts;
using UniManagementSystem.Data.DomainModels.InputModels.Authentication;
using UniManagementSystem.Data.DomainModels.ViewModels.AdminAccounts;
using UniManagementSystem.Data.DomainModels.ViewModels.Authentication;
using UniManagementSystem.Data.DomainModels.ViewModels.StudentAccounts;

namespace UniManagementSystem.Application.Features.Authentication.Commands
{
    public class AuthenticateCommand : IRequest<BaseResponse<AuthUserResponse>>
    {
        public UserAuthDetailsModel authModel { get; set; }
    }

    public class AuthenticateCommandHandler : IRequestHandler<AuthenticateCommand, BaseResponse<AuthUserResponse>>
    {
        private readonly IJwtService _jwtService;
        private readonly IStudentAccountRepositoryAsync _studentAccountRepositoryAsync;
        private readonly IAdminAccountRepositoryAsync _adminAccountRepositoryAsync;
        private readonly IAdminAccountRoleRepositoryAsync _adminAccountRoleRepositoryAsync;
        private readonly IPasswordService _passwordService;
        public AuthenticateCommandHandler(IJwtService _jwtService,
            IStudentAccountRepositoryAsync _studentAccountRepositoryAsync, IAdminAccountRepositoryAsync _adminAccountRepositoryAsync,
           IAdminAccountRoleRepositoryAsync _adminAccountRoleRepositoryAsync,
           IPasswordService _passwordService)
        {
            this._jwtService = _jwtService;
            this._studentAccountRepositoryAsync = _studentAccountRepositoryAsync;
            this._adminAccountRepositoryAsync = _adminAccountRepositoryAsync;
            this._adminAccountRoleRepositoryAsync = _adminAccountRoleRepositoryAsync;
            this._passwordService = _passwordService;

        }
        public async Task<BaseResponse<AuthUserResponse>> Handle(AuthenticateCommand request, CancellationToken cancellationToken)
        {

            var userPasswordHash = _passwordService.GetPasswordHash(request.authModel.Password);
            var AdminAccount = new AdminAccountViewModel();
            var studentAccount = new StudentAccountViewModel();

            var TokenParameters = new JwtParameters();

            //First check If its an Admin Acc
            AdminAccount = await _adminAccountRepositoryAsync.GetAdminAccountByEmailAndPasswordHash(new UserAuthDetailsModel()
            {
                Email = request.authModel.Email,
                Password = userPasswordHash
            });

            if (AdminAccount.Id == 0)
            {
                //Check if its a Student Account
                studentAccount = await _studentAccountRepositoryAsync.GetStudentAccountByEmailAndPassawordHash(new UserAuthDetailsModel()
                {
                    Email = request.authModel.Email,
                    Password = userPasswordHash
                });
            }

            if (AdminAccount.Id == 0 && studentAccount.Id == 0)
            {
                //Invalid Credentials Entered
                return new BaseResponse<AuthUserResponse>()
                {
                    StatusCode = (int)HttpStatusCode.Unauthorized,
                    Succeeded = false,
                    Message = "Invalid Credentials Entered",
                    ResponseData = null,
                    ProblemErrors = new List<string>() { "Invalid Credentials" }
                };
            }

            //Admin User that has logged in
            if (AdminAccount.Id != 0)
            {
                var AdminAccountRoles = await _adminAccountRoleRepositoryAsync.GetAllAdminAccountRoleNamesByAdminAccountIdAsync(AdminAccount.Id);

                TokenParameters.AdminAccountRoles = AdminAccountRoles.ToList();
                TokenParameters.studentData = null;
                TokenParameters.AdminData = AdminAccount;
                TokenParameters.IsAdmin = true;

                var Admintoken = _jwtService.GenerateJwtTokenForUser(TokenParameters);

                return new BaseResponse<AuthUserResponse>()
                {
                    StatusCode = (int)HttpStatusCode.OK,
                    Succeeded = true,
                    Message = "Admin Successfully authenticated",
                    ResponseData = new AuthUserResponse()
                    {
                        UserId = AdminAccount.Id,
                        UserEmail = AdminAccount.AdminEmail,
                        DisplayName = AdminAccount.FirstName + " " + AdminAccount.LastName,
                        JwtAccessToken = Admintoken
                    }
                };
            }

            //Student that has logged in

            if (studentAccount.IsActive == false)
            {
                return new BaseResponse<AuthUserResponse>()
                {
                    StatusCode = (int)HttpStatusCode.Unauthorized,
                    Succeeded = false,
                    Message = "Account not active",
                    ResponseData = null,
                    ProblemErrors = new List<string>() { "Account not active" }
                };
            }

            TokenParameters.AdminAccountRoles = null;
            TokenParameters.studentData = studentAccount;
            TokenParameters.AdminData = null;
            TokenParameters.IsAdmin = false;

            var studentToken = _jwtService.GenerateJwtTokenForUser(TokenParameters);

            return new BaseResponse<AuthUserResponse>()
            {
                StatusCode = (int)HttpStatusCode.OK,
                Succeeded = true,
                Message = "Student Successfully authenticated",
                ResponseData = new AuthUserResponse()
                {
                    UserId = studentAccount.Id,
                    UserEmail = studentAccount.StudentEmail,
                    DisplayName = studentAccount.FirstName + " " + studentAccount.LastName,
                    JwtAccessToken = studentToken
                }
            };
        }
    }
}
