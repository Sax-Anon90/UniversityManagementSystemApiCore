using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UniManagementSystem.Application.Common;
using UniManagementSystem.Application.RepositoryInterfaces.AdminAccountRoles;
using UniManagementSystem.Application.RepositoryInterfaces.CourseEnrollments;
using UniManagementSystem.Data.DomainEntities;
using UniManagementSystem.Data.DomainModels.ViewModels.AdminAccountRoles;
using UniManagementSystem.Data.DomainModels.ViewModels.CourseEnrollments;

namespace UniManagementSystem.Application.Features.AdminAccountRoles.Queries
{
    public class GetAllAdminAccountRolesByIdQuery : IRequest<BaseResponse<IEnumerable<AdminAccountRoleViewModel>>>
    {
        public int adminAccountId { get; set; }
    }

    public class GetAllAdminAccountRolesByIdQueryHandler : IRequestHandler<GetAllAdminAccountRolesByIdQuery, BaseResponse<IEnumerable<AdminAccountRoleViewModel>>>
    {
        private readonly IAdminAccountRoleRepositoryAsync _adminAccountRoleRepositoryAsync;
        public GetAllAdminAccountRolesByIdQueryHandler(IAdminAccountRoleRepositoryAsync _adminAccountRoleRepositoryAsync)
        {
            this._adminAccountRoleRepositoryAsync = _adminAccountRoleRepositoryAsync;
        }
        public async Task<BaseResponse<IEnumerable<AdminAccountRoleViewModel>>> Handle(GetAllAdminAccountRolesByIdQuery request, CancellationToken cancellationToken)
        {
            var courseEnrollments = await _adminAccountRoleRepositoryAsync.GetAllAdminAccountRolesByAdminAccountId(request.adminAccountId);

            if (courseEnrollments.Any())
            {
                return new BaseResponse<IEnumerable<AdminAccountRoleViewModel>>
                {
                    StatusCode = (int)HttpStatusCode.OK,
                    Succeeded = true,
                    Message = $"Records retrieved successfully",
                    ResponseData = courseEnrollments
                };
            }

            return new BaseResponse<IEnumerable<AdminAccountRoleViewModel>>
            {
                StatusCode = (int)HttpStatusCode.OK,
                Succeeded = true,
                Message = $"Admin does not have any roles assigned",
                ResponseData = Enumerable.Empty<AdminAccountRoleViewModel>()
            };
        }
    }
}
