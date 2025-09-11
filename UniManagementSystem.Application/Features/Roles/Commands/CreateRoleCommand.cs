using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UniManagementSystem.Application.Common;
using UniManagementSystem.Application.RepositoryInterfaces.Roles;
using UniManagementSystem.Data.DomainEntities;
using UniManagementSystem.Data.DomainModels.InputModels.Roles;

namespace UniManagementSystem.Application.Features.Roles.Commands
{
    public class CreateRoleCommand : IRequest<BaseResponse<Role>>
    {
        public RoleInputModel roleToCreate { get; set; }
    }

    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, BaseResponse<Role>>
    {

        private readonly IRoleRepositoryAsync _roleRepositoryAsync;
        public CreateRoleCommandHandler(IRoleRepositoryAsync _roleRepositoryAsync)
        {
            this._roleRepositoryAsync = _roleRepositoryAsync;
        }
        public async Task<BaseResponse<Role>> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            var roleToAdd = new Role()
            {
                Name = request.roleToCreate.Name,
                IsActive = true,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                DateInactive = DateTime.UtcNow,
            };

            var createdRole = await _roleRepositoryAsync.CreateRoleAsync(roleToAdd);

            return new BaseResponse<Role>
            {
                StatusCode = (int)HttpStatusCode.Created,
                Succeeded = true,
                Message = "Record created successfully",
                ResponseData = createdRole
            };
        }
    }
}
