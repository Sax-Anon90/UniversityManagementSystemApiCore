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
    public class GetStudentAccountByIdQuery : IRequest<BaseResponse<StudentAccountViewModel>>
    {
        public int StudentId { get; set; }
    }

    public class GetStudentAccountByIdQueryHandler : IRequestHandler<GetStudentAccountByIdQuery, BaseResponse<StudentAccountViewModel>>
    {
        private readonly IStudentAccountRepositoryAsync _studentAccountRepositoryAsync;
        public GetStudentAccountByIdQueryHandler(IStudentAccountRepositoryAsync _studentAccountRepositoryAsync)
        {
            this._studentAccountRepositoryAsync = _studentAccountRepositoryAsync;
        }
        public async Task<BaseResponse<StudentAccountViewModel>> Handle(GetStudentAccountByIdQuery request, CancellationToken cancellationToken)
        {
            var studentAccount = await _studentAccountRepositoryAsync.GetStudentAccountByIdAsync(request.StudentId);

            if (studentAccount.Id == 0)
            {
                return new BaseResponse<StudentAccountViewModel>()
                {
                    StatusCode = (int)HttpStatusCode.NotFound,
                    Succeeded = false,
                    Message = "Record not found",
                    ResponseData = new StudentAccountViewModel()
                };
            }

            return new BaseResponse<StudentAccountViewModel>()
            {
                StatusCode = (int)HttpStatusCode.OK,
                Succeeded = true,
                Message = "Record retrieved successfully",
                ResponseData = studentAccount
            };
        }
    }
}
