using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniManagementSystem.Application.RepositoryInterfaces.AdminAccounts;
using UniManagementSystem.Data.DomainEntities;
using UniManagementSystem.Data.DomainModels.ViewModels.AdminAccounts;

namespace UniManagementSystem.Persistence.RepositoryImplementations.AdminAccounts
{
    public class AdminAccountRepositoryAsync : IAdminAccountRepositoryAsync
    {
        public AdminAccountRepositoryAsync()
        {
            
        }
        public Task<AdminAccount> CreateAdminAccountAsync(AdminAccount adminAccountToCreate)
        {
            throw new NotImplementedException();
        }

        public Task<AdminAccount> DeleteAdminAccountAsync(AdminAccount adminAccountToDelete)
        {
            throw new NotImplementedException();
        }

        public Task<AdminAccountViewModel> GetAdminAccountByIdAsync(int adminAccountId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AdminAccountViewModel>> GetAllAdminAccountsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<AdminAccount> UpdateAdminAccountAsync(AdminAccount adminAccountToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
