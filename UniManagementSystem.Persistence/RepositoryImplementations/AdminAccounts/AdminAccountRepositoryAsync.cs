using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniManagementSystem.Application.RepositoryInterfaces.AdminAccounts;
using UniManagementSystem.Data.DomainEntities;
using UniManagementSystem.Data.DomainModels.ViewModels.AdminAccounts;
using UniManagementSystem.Data.DomainModels.ViewModels.StudentAccounts;
using UniManagementSystem.Persistence.UniDbContext;

namespace UniManagementSystem.Persistence.RepositoryImplementations.AdminAccounts
{
    public class AdminAccountRepositoryAsync : IAdminAccountRepositoryAsync
    {
        private readonly UniManagementSystemDbContext _dbContext;
        public AdminAccountRepositoryAsync(UniManagementSystemDbContext _dbContext)
        {
            this._dbContext = _dbContext;
        }
        public async Task<AdminAccount> CreateAdminAccountAsync(AdminAccount adminAccountToCreate)
        {
            await _dbContext.AdminAccounts.AddAsync(adminAccountToCreate);
            await _dbContext.SaveChangesAsync();
            return adminAccountToCreate;
        }

        public async Task<AdminAccount> DeleteAdminAccountAsync(AdminAccount adminAccountToDelete)
        {
            var AdminAccount = await _dbContext.AdminAccounts.AsNoTracking()
               .SingleOrDefaultAsync(x => x.Id == adminAccountToDelete.Id);

            if (AdminAccount is null)
            {
                return new AdminAccount() { Id = 0 };
            }

            AdminAccount.IsActive = false;
            AdminAccount.DateInactive = DateTime.UtcNow;
            _dbContext.AdminAccounts.Update(adminAccountToDelete);
            await _dbContext.SaveChangesAsync();
            return AdminAccount;
        }

        public async Task<AdminAccount> GetAdminAccountByEmailAsync(string email)
        {
            var AdminAccount = await _dbContext.AdminAccounts.AsNoTracking().SingleOrDefaultAsync(x => x.AdminEmail == email);

            if (AdminAccount is null)
            {
                return new AdminAccount() { Id = 0 };
            }

            return AdminAccount;
        }

        public async Task<AdminAccountViewModel> GetAdminAccountByIdAsync(int adminAccountId)
        {
            var AdminAccount = await _dbContext.StudentAccounts.Select(x => new AdminAccountViewModel()
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Gender = x.Gender,
                IsActive = x.IsActive,
                DateOfBirth = x.DateOfBirth,
                DateCreated = x.DateCreated,
                DateModified = x.DateModified,
                DateInactive = x.DateInactive


            }).AsNoTracking().SingleOrDefaultAsync(x => x.Id == adminAccountId);

            if (AdminAccount is null)
            {
                return new AdminAccountViewModel() { Id = 0 };
            }

            return AdminAccount;
        }

        public async Task<IEnumerable<AdminAccountViewModel>> GetAllAdminAccountsAsync()
        {
            var AdminAccounts = await _dbContext.StudentAccounts.Select(x => new AdminAccountViewModel()
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Gender = x.Gender,
                IsActive = x.IsActive,
                DateOfBirth = x.DateOfBirth,
                DateCreated = x.DateCreated,
                DateModified = x.DateModified,
                DateInactive = x.DateInactive


            })
            .AsNoTracking()
            .ToListAsync();

            if (AdminAccounts is null)
            {
                return Enumerable.Empty<AdminAccountViewModel>();
            }

            return AdminAccounts;
        }

        public async Task<AdminAccount> UpdateAdminAccountAsync(AdminAccount adminAccountToUpdate)
        {
            var AdminAccount = await _dbContext.AdminAccounts.AsNoTracking()
                  .SingleOrDefaultAsync(x => x.Id == adminAccountToUpdate.Id);

            if (AdminAccount is null)
            {
                return new AdminAccount() { Id = 0 };
            }

            AdminAccount.FirstName = adminAccountToUpdate.FirstName;
            AdminAccount.LastName = adminAccountToUpdate.LastName;
            AdminAccount.Gender = adminAccountToUpdate.Gender;
            AdminAccount.DateOfBirth = adminAccountToUpdate.DateOfBirth;
            AdminAccount.IsActive = adminAccountToUpdate.IsActive;
            AdminAccount.DateModified = DateTime.UtcNow;

            _dbContext.AdminAccounts.Update(AdminAccount);
            await _dbContext.SaveChangesAsync();
            return AdminAccount;
        }
    }
}
