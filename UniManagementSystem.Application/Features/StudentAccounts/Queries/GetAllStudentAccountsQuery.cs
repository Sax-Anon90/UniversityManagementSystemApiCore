using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UniManagementSystem.Application.Common;
using UniManagementSystem.Application.RepositoryInterfaces.StudentAccounts;
using UniManagementSystem.Data.DomainModels.ViewModels.StudentAccounts;

namespace UniManagementSystem.Application.Features.StudentAccounts.Queries
{
    public class GetAllStudentAccountsQuery : IRequest<BaseResponse<IEnumerable<StudentAccountViewModel>>>
    {
    }

    public class GetAllStudentAccountsQueryHandler : IRequestHandler<GetAllStudentAccountsQuery,
        BaseResponse<IEnumerable<StudentAccountViewModel>>>
    {
        private readonly IStudentAccountRepositoryAsync _studentAccountRepositoryAsync;
        public GetAllStudentAccountsQueryHandler(IStudentAccountRepositoryAsync _studentAccountRepositoryAsync)
        {
            this._studentAccountRepositoryAsync = _studentAccountRepositoryAsync;
        }
        public async Task<BaseResponse<IEnumerable<StudentAccountViewModel>>> Handle(GetAllStudentAccountsQuery request, CancellationToken cancellationToken)
        {
            var studentAccounts = await _studentAccountRepositoryAsync.GetAllStudentAccountsAsync();

            if (studentAccounts.Any())
            {
                return new BaseResponse<IEnumerable<StudentAccountViewModel>>()
                {
                    StatusCode = (int)HttpStatusCode.OK,
                    Succeeded = true,
                    Message = "Student Records retrieved successfully",
                    ResponseData = studentAccounts
                };
            }

            return new BaseResponse<IEnumerable<StudentAccountViewModel>>()
            {
                StatusCode = (int)HttpStatusCode.OK,
                Succeeded = true,
                Message = "No Student Records found",
                ResponseData = Enumerable.Empty<StudentAccountViewModel>()
            };

        }
    }
}



