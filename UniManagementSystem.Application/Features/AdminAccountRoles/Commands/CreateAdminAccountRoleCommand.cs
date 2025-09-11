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
using UniManagementSystem.Data.DomainModels.InputModels.AdminAccountRoles;

namespace UniManagementSystem.Application.Features.AdminAccountRoles.Commands
{
    public class CreateAdminAccountRoleCommand : IRequest<BaseResponse<AdminAccountRole>>
    {
        public AdminAccountRoleInputModel adminAccountRoleToCreate { get; set; }
    }

    public class CreateAdminAccountRoleCommandHandler : IRequestHandler<CreateAdminAccountRoleCommand, BaseResponse<AdminAccountRole>>
    {
        private readonly IAdminAccountRoleRepositoryAsync _adminAccountRoleRepositoryAsync;
        public CreateAdminAccountRoleCommandHandler(IAdminAccountRoleRepositoryAsync _adminAccountRoleRepositoryAsync)
        {
            this._adminAccountRoleRepositoryAsync = _adminAccountRoleRepositoryAsync;
        }
        public async Task<BaseResponse<AdminAccountRole>> Handle(CreateAdminAccountRoleCommand request, CancellationToken cancellationToken)
        {
            var adminAccountRoleToCreate = new AdminAccountRole()
            {
                AdminAccountId = request.adminAccountRoleToCreate.AdminAccountId,
                RoleId = request.adminAccountRoleToCreate.RoleId,
                IsActive = true,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                DateInactive = DateTime.UtcNow,
            };

            var createdAdminAccountRole = await _adminAccountRoleRepositoryAsync.CreateAdminAccountRole(adminAccountRoleToCreate);

            return new BaseResponse<AdminAccountRole>
            {
                StatusCode = (int)HttpStatusCode.Created,
                Succeeded = true,
                Message = "Record created successfully",
                ResponseData = createdAdminAccountRole
            };
        }
    }
}
