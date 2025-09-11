using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniManagementSystem.Data.DomainEntities;
using UniManagementSystem.Data.DomainModels.ViewModels.Roles;

namespace UniManagementSystem.Application.RepositoryInterfaces.Roles
{
    public interface IRoleRepositoryAsync
    {
        Task<IEnumerable<RoleViewModel>> GetAllRolesAsync(); 
        Task<Role> CreateRoleAsync(Role roleToCreate);
        Task<Role> UpdateRoleAsync(Role roleToUpdate);
        Task<Role> DeleteRoleAsync(Role roleToDelete);



    }
}
