using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UniManagementSystem.Application.Common;
using UniManagementSystem.Application.RepositoryInterfaces.Roles;
using UniManagementSystem.Application.RepositoryInterfaces.StudentAccounts;
using UniManagementSystem.Data.DomainModels.ViewModels.Roles;
using UniManagementSystem.Data.DomainModels.ViewModels.StudentAccounts;

namespace UniManagementSystem.Application.Features.Roles.Queries
{
    public class GetAllRolesQuery : IRequest<BaseResponse<IEnumerable<RoleViewModel>>>
    {
    }

    public class classGetAllRolesQueryHandler : IRequestHandler<GetAllRolesQuery, BaseResponse<IEnumerable<RoleViewModel>>>
    {
        private readonly IRoleRepositoryAsync _roleRepositoryAsync;
        public classGetAllRolesQueryHandler(IRoleRepositoryAsync _roleRepositoryAsync)
        {
            this._roleRepositoryAsync = _roleRepositoryAsync;
        }
        public async Task<BaseResponse<IEnumerable<RoleViewModel>>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
        {
            var roles = await _roleRepositoryAsync.GetAllRolesAsync();

            if (roles.Any())
            {
                return new BaseResponse<IEnumerable<RoleViewModel>>()
                {
                    StatusCode = (int)HttpStatusCode.OK,
                    Succeeded = true,
                    Message = "Role Records retrieved successfully",
                    ResponseData = roles
                };
            }

            return new BaseResponse<IEnumerable<RoleViewModel>>()
            {
                StatusCode = (int)HttpStatusCode.OK,
                Succeeded = true,
                Message = "No Role Records found",
                ResponseData = Enumerable.Empty<RoleViewModel>()
            };
        }
    }
}
