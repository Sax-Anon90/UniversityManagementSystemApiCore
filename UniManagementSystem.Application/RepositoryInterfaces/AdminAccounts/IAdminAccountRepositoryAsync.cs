using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniManagementSystem.Data.DomainEntities;
using UniManagementSystem.Data.DomainModels.ViewModels.AdminAccounts;

namespace UniManagementSystem.Application.RepositoryInterfaces.AdminAccounts
{
    public interface IAdminAccountRepositoryAsync
    {
        Task<IEnumerable<AdminAccountViewModel>> GetAllAdminAccountsAsync();
        Task<AdminAccountViewModel> GetAdminAccountByIdAsync(int adminAccountId);
        Task<AdminAccount> CreateAdminAccountAsync(AdminAccount adminAccountToCreate);
        Task<AdminAccount> UpdateAdminAccountAsync(AdminAccount adminAccountToUpdate);
        Task<AdminAccount> DeleteAdminAccountAsync(AdminAccount adminAccountToDelete);
        Task<AdminAccount> GetAdminAccountByEmailAsync(string email);
        

    }
}
