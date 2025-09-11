using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniManagementSystem.Data.DomainEntities;
using UniManagementSystem.Data.DomainModels.ViewModels.AdminAccountRoles;

namespace UniManagementSystem.Application.RepositoryInterfaces.AdminAccountRoles
{
    public interface IAdminAccountRoleRepositoryAsync
    {
        Task<IEnumerable<AdminAccountRoleViewModel>> GetAllAdminAccountRolesByAdminAccountId(int adminAccountId);
        Task<AdminAccountRole> CreateAdminAccountRole(AdminAccountRole adminAccountRoleToCreate);
        Task<AdminAccountRole> DeleteAdminAccountRole(AdminAccount adminAccountToDelete);
        Task<IEnumerable<string>> GetAllAdminAccountRoleNamesByAdminAccountIdAsync(int adminAccountId);
    }
}
