using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniManagementSystem.Application.RepositoryInterfaces.AdminAccountRoles;
using UniManagementSystem.Data.DomainEntities;
using UniManagementSystem.Data.DomainModels.ViewModels.AdminAccountRoles;
using UniManagementSystem.Data.DomainModels.ViewModels.CourseEnrollments;
using UniManagementSystem.Persistence.UniDbContext;

namespace UniManagementSystem.Persistence.RepositoryImplementations.AdminAccountRoles
{
    public class AdminAccountRoleRepositoryAsync : IAdminAccountRoleRepositoryAsync
    {
        private readonly UniManagementSystemDbContext _dbContext;

        public AdminAccountRoleRepositoryAsync(UniManagementSystemDbContext _dbContext)
        {
            this._dbContext = _dbContext;
        }
        public async Task<AdminAccountRole> CreateAdminAccountRole(AdminAccountRole adminAccountRoleToCreate)
        {
            await _dbContext.AdminAccountRoles.AddAsync(adminAccountRoleToCreate);
            await _dbContext.SaveChangesAsync();
            return adminAccountRoleToCreate;
        }

        public async Task<AdminAccountRole> DeleteAdminAccountRole(AdminAccountRole adminAccountToDelete)
        {
            var AdminAccountRole = await _dbContext.AdminAccountRoles
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == adminAccountToDelete.Id);

            if (AdminAccountRole is null)
            {
                return new AdminAccountRole() { Id = 0 };
            }

            _dbContext.AdminAccountRoles.Remove(AdminAccountRole);
            await _dbContext.SaveChangesAsync();
            return AdminAccountRole;
        }

        public async Task<IEnumerable<string>> GetAllAdminAccountRoleNamesByAdminAccountIdAsync(int adminAccountId)
        {
            var roleNames = await _dbContext.AdminAccountRoles
                .Where(x => x.Id == adminAccountId)
                .Include(x => x.Role)
                .Include(x => x.AdminAccount)
                .AsSplitQuery()
                .Select(x => x.Role.Name).ToListAsync();


            return roleNames;

        }

        public async Task<IEnumerable<AdminAccountRoleViewModel>> GetAllAdminAccountRolesByAdminAccountId(int adminAccountId)
        {
            var adminAccountRoles = await _dbContext.AdminAccountRoles
               .Include(x => x.AdminAccount)
               .Include(x => x.Role)
               .Select(x => new AdminAccountRoleViewModel
               {
                   Id = x.Id,
                   AdminAccountId = x.AdminAccount.Id,
                   RoleId = x.Role.Id,
                   RoleName = x.Role.Name,
                   AdminFullName = x.AdminAccount.FirstName + "" + x.AdminAccount.LastName,
                   DateCreated = x.DateCreated,
                   DateModified = x.DateModified,
                   DateInactive = x.DateInactive,
               })
               .Where(x => x.Id == adminAccountId)
               .AsNoTracking()
               .ToListAsync();

            if (!adminAccountRoles.Any())
            {
                return Enumerable.Empty<AdminAccountRoleViewModel>();
            }

            return adminAccountRoles;
        }
    }
}
