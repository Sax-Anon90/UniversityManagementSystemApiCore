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

namespace UniManagementSystem.Application.Features.AdminAccountRoles.Commands
{
    public class DeleteAdminAccountRoleCommand : IRequest<BaseResponse<AdminAccountRole>>
    {
        public int adminAccountRoleId { get; set; }
    }

    public class DeleteAdminAccountRoleCommandHandler : IRequestHandler<DeleteAdminAccountRoleCommand, BaseResponse<AdminAccountRole>>
    {
        private readonly IAdminAccountRoleRepositoryAsync _adminAccountRoleRepositoryAsync;
        public DeleteAdminAccountRoleCommandHandler(IAdminAccountRoleRepositoryAsync _adminAccountRoleRepositoryAsync)
        {
            this._adminAccountRoleRepositoryAsync = _adminAccountRoleRepositoryAsync;
        }
        public async Task<BaseResponse<AdminAccountRole>> Handle(DeleteAdminAccountRoleCommand request, CancellationToken cancellationToken)
        {
            var adminAccountRoleToRemove = new AdminAccountRole { Id = request.adminAccountRoleId };

            var response = await _adminAccountRoleRepositoryAsync.DeleteAdminAccountRole(adminAccountRoleToRemove);

            if (response.Id == 0)
            {
                return new BaseResponse<AdminAccountRole>()
                {
                    StatusCode = (int)HttpStatusCode.NotFound,
                    Succeeded = false,
                    Message = "Record not found",
                    ResponseData = response,
                    ProblemErrors = new List<string>() { "Record not found" }

                };
            }

            return new BaseResponse<AdminAccountRole>()
            {
                StatusCode = (int)HttpStatusCode.OK,
                Succeeded = false,
                Message = "Record successfully removed",
                ResponseData = response,
            };
        }
    }
}
