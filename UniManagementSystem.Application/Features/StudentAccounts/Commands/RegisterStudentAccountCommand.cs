using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UniManagementSystem.Application.Common;
using UniManagementSystem.Application.RepositoryInterfaces.PasswordService;
using UniManagementSystem.Application.RepositoryInterfaces.StudentAccounts;
using UniManagementSystem.Data.DomainEntities;
using UniManagementSystem.Data.DomainModels.InputModels.StudentAccounts;

namespace UniManagementSystem.Application.Features.StudentAccounts.Commands
{
    public class RegisterStudentAccountCommand : IRequest<BaseResponse<StudentAccount>>
    {
        public StudentAccountInputModel studentAccountToCreate { get; set; }
    }

    public class RegisterStudentAccountCommandHandler : IRequestHandler<RegisterStudentAccountCommand, BaseResponse<StudentAccount>>
    {
        private readonly IStudentAccountRepositoryAsync _studentAccountRepositoryAsync;
        private readonly IPasswordService _passwordService;
        public RegisterStudentAccountCommandHandler(IStudentAccountRepositoryAsync _studentAccountRepositoryAsync,
            IPasswordService _passwordService)
        {
            this._studentAccountRepositoryAsync = _studentAccountRepositoryAsync;
            this._passwordService = _passwordService;
        }
        public async Task<BaseResponse<StudentAccount>> Handle(RegisterStudentAccountCommand request, CancellationToken cancellationToken)
        {
            //Check if student already registered

            var student = await _studentAccountRepositoryAsync.GetStudentAccountByEmailAsync(request.studentAccountToCreate.StudentEmail);

            if (student.Id != 0)
            {
                //Already registered
                return new BaseResponse<StudentAccount>
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Message = "Student Already Registered",
                    Succeeded = false,
                    ProblemErrors = new List<string> { "Student Already Registred" },
                    ResponseData = null

                };
            }

            //Hash User Password
            var hashedPassword = _passwordService.GetPasswordHash(request.studentAccountToCreate.Password);

            var studentAccountToRegister = new StudentAccount
            {
                FirstName = request.studentAccountToCreate.FirstName,
                LastName = request.studentAccountToCreate.LastName,
                DateOfBirth = request.studentAccountToCreate.DateOfBirth,
                Gender = request.studentAccountToCreate.Gender,
                StudentEmail = request.studentAccountToCreate.StudentEmail,
                StudentNumber = Guid.NewGuid().ToString(),
                IsActive = false,
                PasswordHash = hashedPassword,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                DateInactive = DateTime.UtcNow,

            };

            var createdStudent = await _studentAccountRepositoryAsync.CreateStudentAccountAsync(studentAccountToRegister);


            createdStudent.PasswordHash = null;

            return new BaseResponse<StudentAccount>()
            {
                StatusCode = (int)HttpStatusCode.Created,
                Succeeded = true,
                Message = "Student Account Regustered",
                ResponseData = createdStudent;
        }

    }
}

