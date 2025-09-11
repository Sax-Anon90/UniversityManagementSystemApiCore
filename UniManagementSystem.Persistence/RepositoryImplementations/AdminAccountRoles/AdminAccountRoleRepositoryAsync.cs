using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniManagementSystem.Application.RepositoryInterfaces.AdminAccountRoles;
using UniManagementSystem.Data.DomainEntities;
using UniManagementSystem.Data.DomainModels.ViewModels.AdminAccountRoles;

namespace UniManagementSystem.Persistence.RepositoryImplementations.AdminAccountRoles
{
    public class AdminAccountRoleRepositoryAsync : IAdminAccountRoleRepositoryAsync
    {
        
        public AdminAccountRoleRepositoryAsync()
        {
            
        }
        public Task<AdminAccountRole> CreateAdminAccountRole(AdminAccountRole adminAccountRoleToCreate)
        {
            throw new NotImplementedException();
        }

        public Task<AdminAccountRole> DeleteAdminAccountRole(AdminAccount adminAccountToDelete)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<string>> GetAllAdminAccountRoleNamesByAdminAccountIdAsync(int adminAccountId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AdminAccountRoleViewModel>> GetAllAdminAccountRolesByAdminAccountId(int adminAccountId)
        {
            throw new NotImplementedException();
        }

        public Task<AdminAccountRole> UpdateAdminAccountRole(AdminAccountRole adminAccountRoleToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
