using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UniManagementSystem.Application.Common;
using UniManagementSystem.Application.RepositoryInterfaces.StudentAccounts;
using UniManagementSystem.Data.DomainEntities;
using UniManagementSystem.Data.DomainModels.InputModels.StudentAccounts;

namespace UniManagementSystem.Application.Features.StudentAccounts.Commands
{
    public class UpdateStudentAccountCommand : IRequest<BaseResponse<StudentAccount>>
    {
        public StudentAccountUpdateModel studentAccountToUpdate { get; set; }
    }

    public class UpdateStudentAccountCommandHandler : IRequestHandler<UpdateStudentAccountCommand, BaseResponse<StudentAccount>>
    {
        private readonly IStudentAccountRepositoryAsync _studentAccountRepositoryAsync;
        public UpdateStudentAccountCommandHandler(IStudentAccountRepositoryAsync _studentAccountRepositoryAsync)
        {
            this._studentAccountRepositoryAsync = _studentAccountRepositoryAsync;
        }
        public async Task<BaseResponse<StudentAccount>> Handle(UpdateStudentAccountCommand request, CancellationToken cancellationToken)
        {
            var studentAccountToUpdate = new StudentAccount()
            {
                Id = request.studentAccountToUpdate.Id,
                FirstName = request.studentAccountToUpdate.FirstName,
                LastName = request.studentAccountToUpdate.LastName,
                IsActive = request.studentAccountToUpdate.IsActive,
                Gender = request.studentAccountToUpdate.Gender,
                DateOfBirth = request.studentAccountToUpdate.DateOfBirth,
                StudentEmail = request.studentAccountToUpdate.StudentEmail,
            };

            var response = await _studentAccountRepositoryAsync.UpdateStudentAccountAsync(studentAccountToUpdate);

            if (response.Id == 0)
            {
                return new BaseResponse<StudentAccount>
                {
                    StatusCode = (int)HttpStatusCode.NotFound,
                    Succeeded = false,
                    ResponseData = response,
                    Message = "Record not found",
                    ProblemErrors = new List<string>() { "Record not found" }
                };
            }

            response.PasswordHash = null;

            return new BaseResponse<StudentAccount>()
            {
                StatusCode = (int)HttpStatusCode.OK,
                Succeeded = true,
                Message = "Record successfully updated",
                ResponseData = response,
            };

        }
    }
}
