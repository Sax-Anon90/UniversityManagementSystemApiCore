using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UniManagementSystem.Application.Common;
using UniManagementSystem.Application.RepositoryInterfaces.AdminAccounts;
using UniManagementSystem.Application.RepositoryInterfaces.PasswordService;
using UniManagementSystem.Application.RepositoryInterfaces.StudentAccounts;
using UniManagementSystem.Data.DomainEntities;
using UniManagementSystem.Data.DomainModels.InputModels.AdminAccounts;

namespace UniManagementSystem.Application.Features.AdminAccounts.Commands
{
    public class CreateAdminAccountCommand : IRequest<BaseResponse<AdminAccount>>
    {
        public AdminAccountInputModel adminAccountToCreate { get; set; }
    }

    public class CreateAdminAccountCommandHandler : IRequestHandler<CreateAdminAccountCommand, BaseResponse<AdminAccount>>
    {
        private readonly IPasswordService _passwordService;
        private readonly IAdminAccountRepositoryAsync _adminAccountRepositoryAsync;

        public CreateAdminAccountCommandHandler(IPasswordService _passwordService,
            IAdminAccountRepositoryAsync _adminAccountRepositoryAsync)
        {
            this._passwordService = _passwordService;
            this._adminAccountRepositoryAsync = _adminAccountRepositoryAsync;
        }
        public async Task<BaseResponse<AdminAccount>> Handle(CreateAdminAccountCommand request, CancellationToken cancellationToken)
        {
            //Check if student already registered

            var admin = await _adminAccountRepositoryAsync.GetAdminAccountByEmailAsync(request.adminAccountToCreate.AdminEmail);

            if (admin.Id != 0)
            {
                //Already registered
                return new BaseResponse<AdminAccount>
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Message = "Admin Account Already Registered",
                    Succeeded = false,
                    ProblemErrors = new List<string> { "Admin Account Already Registred" },
                    ResponseData = null

                };
            }

            //Hash User Password
            var hashedPassword = _passwordService.GetPasswordHash(request.adminAccountToCreate.Password);

            var AdminAccountToRegister = new AdminAccount
            {
                FirstName = request.adminAccountToCreate.FirstName,
                LastName = request.adminAccountToCreate.LastName,
                DateOfBirth = request.adminAccountToCreate.DateOfBirth,
                Gender = request.adminAccountToCreate.Gender,
                IsActive = true,
                PasswordHash = hashedPassword,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                DateInactive = DateTime.UtcNow,
            };

            var createdAdmin = await _adminAccountRepositoryAsync.CreateAdminAccountAsync(AdminAccountToRegister);


            createdAdmin.PasswordHash = null;

            return new BaseResponse<AdminAccount>()
            {
                StatusCode = (int)HttpStatusCode.Created,
                Succeeded = true,
                Message = "Admin Account Registered",
                ResponseData = createdAdmin
            };
        }
    }
}



