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
using UniManagementSystem.Data.DomainEntities;
using UniManagementSystem.Data.DomainModels.InputModels.AdminAccounts;

namespace UniManagementSystem.Application.Features.AdminAccounts.Commands
{
    public class UpdateAdminAccountCommand : IRequest<BaseResponse<AdminAccount>>
    {
        public AdminAccountUpdateModel adminAccountToUpdate { get; set; }
    }

    public class UpdateAdminAccountCommandHandler : IRequestHandler<UpdateAdminAccountCommand, BaseResponse<AdminAccount>>
    {
        private readonly IAdminAccountRepositoryAsync _adminAccountRepositoryAsync;
        public UpdateAdminAccountCommandHandler(IAdminAccountRepositoryAsync _adminAccountRepositoryAsync)
        {
            this._adminAccountRepositoryAsync = _adminAccountRepositoryAsync;
        }
        public async Task<BaseResponse<AdminAccount>> Handle(UpdateAdminAccountCommand request, CancellationToken cancellationToken)
        {
            var AdminAccountToUpdate = new AdminAccount()
            {
                Id = request.adminAccountToUpdate.Id,
                FirstName = request.adminAccountToUpdate.FirstName,
                LastName = request.adminAccountToUpdate.LastName,
                IsActive = request.adminAccountToUpdate.IsActive,
                Gender = request.adminAccountToUpdate.Gender,
                DateOfBirth = request.adminAccountToUpdate.DateOfBirth,
                AdminEmail = request.adminAccountToUpdate.AdminEmail,
            };

            var response = await _adminAccountRepositoryAsync.UpdateAdminAccountAsync(AdminAccountToUpdate);

            if (response.Id == 0)
            {
                return new BaseResponse<AdminAccount>
                {
                    StatusCode = (int)HttpStatusCode.NotFound,
                    Succeeded = false,
                    ResponseData = response,
                    Message = "Record not found",
                    ProblemErrors = new List<string>() { "Record not found" }
                };
            }

            response.PasswordHash = null;

            return new BaseResponse<AdminAccount>()
            {
                StatusCode = (int)HttpStatusCode.OK,
                Succeeded = true,
                Message = "Record successfully updated",
                ResponseData = response,
            };

        }
    }
}
