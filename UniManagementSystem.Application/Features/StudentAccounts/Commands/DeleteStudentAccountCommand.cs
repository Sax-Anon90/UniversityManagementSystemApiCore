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

namespace UniManagementSystem.Application.Features.StudentAccounts.Commands
{
    public class DeleteStudentAccountCommand : IRequest<BaseResponse<StudentAccount>>
    {
        public int studentAccountId { get; set; }
    }

    public class DeleteStudentAccountCommandHandler : IRequestHandler<DeleteStudentAccountCommand, BaseResponse<StudentAccount>>
    {
        private readonly IStudentAccountRepositoryAsync _studentAccountRepositoryAsync;
        public DeleteStudentAccountCommandHandler(IStudentAccountRepositoryAsync _studentAccountRepositoryAsync)
        {
            this._studentAccountRepositoryAsync = _studentAccountRepositoryAsync;
        }
        public async Task<BaseResponse<StudentAccount>> Handle(DeleteStudentAccountCommand request, CancellationToken cancellationToken)
        {
            var studentToMakeInactive = new StudentAccount()
            {
                Id = request.studentAccountId,
            };

            var response = await _studentAccountRepositoryAsync.DeleteStudentAccountAsync(studentToMakeInactive);

            if (response.Id == 0)
            {
                return new BaseResponse<StudentAccount>()
                {
                    StatusCode = (int)HttpStatusCode.NotFound,
                    Succeeded = false,
                    Message = "Student not found to make inactive",
                    ResponseData = response,
                    ProblemErrors = new List<string>() { "Student not found to make inactive" }

                };
            }

            return new BaseResponse<StudentAccount>()
            {
                StatusCode = (int)HttpStatusCode.OK,
                Succeeded = true,
                Message = "Student successfully removed",
                ResponseData = response,
            };
        }
    }
}
