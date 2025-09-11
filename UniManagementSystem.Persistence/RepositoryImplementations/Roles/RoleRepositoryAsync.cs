using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniManagementSystem.Application.RepositoryInterfaces.Roles;
using UniManagementSystem.Data.DomainEntities;
using UniManagementSystem.Data.DomainModels.ViewModels.Roles;
using UniManagementSystem.Persistence.UniDbContext;

namespace UniManagementSystem.Persistence.RepositoryImplementations.Roles
{
    public class RoleRepositoryAsync : IRoleRepositoryAsync
    {
        private readonly UniManagementSystemDbContext _dbContext;
        public RoleRepositoryAsync(UniManagementSystemDbContext _dbContext)
        {
            this._dbContext = _dbContext;
        }
        public async Task<Role> CreateRoleAsync(Role roleToCreate)
        {
            await _dbContext.Roles.AddAsync(roleToCreate);
            await _dbContext.SaveChangesAsync();
            return roleToCreate;
        }

        public async Task<Role> DeleteRoleAsync(Role roleToDelete)
        {
            var role = await _dbContext.Roles.AsNoTracking().SingleOrDefaultAsync(x => x.Id == roleToDelete.Id);

            if (role is null)
            {
                return new Role() { Id = 0 };
            }

            role.IsActive = false;
            role.DateInactive = DateTime.UtcNow;
            _dbContext.Update(role);
            await _dbContext.SaveChangesAsync();
            return role;
        }

        public async Task<IEnumerable<RoleViewModel>> GetAllRolesAsync()
        {
            var roles = await _dbContext.Roles.Select(x => new RoleViewModel
            {
                Id = x.Id,
                Name = x.Name,
                IsActive = x.IsActive,
                DateCreated = x.DateCreated,
                DateModified = x.DateModified,
                DateInactive = x.DateInactive,
            }).ToListAsync();

            if (!roles.Any())
            {
                return Enumerable.Empty<RoleViewModel>();
            }

            return roles;
        }

        public async Task<Role> UpdateRoleAsync(Role roleToUpdate)
        {
            var role = await _dbContext.Roles.AsNoTracking().SingleOrDefaultAsync(x => x.Id == roleToUpdate.Id);

            if (role is null)
            {
                return new Role() { Id = 0 };
            }
            
            role.IsActive = true;
            role.Name = roleToUpdate.Name;
            _dbContext.Roles.Update(role);
            await _dbContext.SaveChangesAsync();
            return role;

        }
    }
}
