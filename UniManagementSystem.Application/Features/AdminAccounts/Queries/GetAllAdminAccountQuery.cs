using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UniManagementSystem.Application.Common;
using UniManagementSystem.Application.RepositoryInterfaces.AdminAccounts;
using UniManagementSystem.Application.RepositoryInterfaces.StudentAccounts;
using UniManagementSystem.Data.DomainModels.ViewModels.AdminAccounts;
using UniManagementSystem.Data.DomainModels.ViewModels.StudentAccounts;

namespace UniManagementSystem.Application.Features.AdminAccounts.Queries
{
    public class GetAllAdminAccountQuery : IRequest<BaseResponse<IEnumerable<AdminAccountViewModel>>>
    {
    }

    public class GetAllAdminAccountQueryHandler : IRequestHandler<GetAllAdminAccountQuery, BaseResponse<IEnumerable<AdminAccountViewModel>>>
    {
        private readonly IAdminAccountRepositoryAsync _adminAccountRepositoryAsync;
        public GetAllAdminAccountQueryHandler(IAdminAccountRepositoryAsync _adminAccountRepositoryAsync)
        {
            this._adminAccountRepositoryAsync = _adminAccountRepositoryAsync;
        }
        public async Task<BaseResponse<IEnumerable<AdminAccountViewModel>>> Handle(GetAllAdminAccountQuery request, CancellationToken cancellationToken)
        {
            var adminAccounts = await _adminAccountRepositoryAsync.GetAllAdminAccountsAsync();

            if (adminAccounts.Any())
            {
                return new BaseResponse<IEnumerable<AdminAccountViewModel>>()
                {
                    StatusCode = (int)HttpStatusCode.OK,
                    Succeeded = true,
                    Message = "Student Records retrieved successfully",
                    ResponseData = adminAccounts
                };
            }

            return new BaseResponse<IEnumerable<AdminAccountViewModel>>()
            {
                StatusCode = (int)HttpStatusCode.OK,
                Succeeded = true,
                Message = "No Student Records found",
                ResponseData = Enumerable.Empty<AdminAccountViewModel>()
            };

        }
    }
}
