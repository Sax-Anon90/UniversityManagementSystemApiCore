using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniManagementSystem.Application.RepositoryInterfaces.Roles;
using UniManagementSystem.Data.DomainEntities;
using UniManagementSystem.Data.DomainModels.ViewModels.Roles;

namespace UniManagementSystem.Persistence.RepositoryImplementations.Roles
{
    public class RoleRepositoryAsync : IRoleRepositoryAsync
    {
        public RoleRepositoryAsync()
        {
            
        }
        public Task<Role> CreateRoleAsync(Role roleToCreate)
        {
            throw new NotImplementedException();
        }

        public Task<Role> DeleteRoleAsync(Role roleToDelete)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<RoleViewModel>> GetAllRolesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Role> UpdateRoleAsync(Role roleToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
