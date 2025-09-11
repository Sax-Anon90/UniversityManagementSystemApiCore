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
    public class UpdateRoleCommand : IRequest<BaseResponse<Role>>
    {
        public RoleUpdateModel RoleToUpdate { get; set; }
    }

    public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand, BaseResponse<Role>>
    {
        private readonly IRoleRepositoryAsync _roleRepositoryAsync;
        public UpdateRoleCommandHandler(IRoleRepositoryAsync _roleRepositoryAsync)
        {
            this._roleRepositoryAsync = _roleRepositoryAsync;
        }
        public async Task<BaseResponse<Role>> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            var roleToUpdate = new Role()
            {
                Id = request.RoleToUpdate.Id,
                Name = request.RoleToUpdate.Name,
                IsActive = true
            };

            var response = await _roleRepositoryAsync.UpdateRoleAsync(roleToUpdate);

            if (response.Id == 0)
            {
                return new BaseResponse<Role>()
                {
                    StatusCode = (int)HttpStatusCode.NotFound,
                    Succeeded = false,
                    Message = "Record not found",
                    ProblemErrors = new List<string>() { "Record not found" },
                    ResponseData = null
                };
            }

            return new BaseResponse<Role>()
            {
                StatusCode = (int)HttpStatusCode.OK,
                Succeeded = true,
                Message = "Record updated successfully",
                ResponseData = response
            };
        }
    }
}
