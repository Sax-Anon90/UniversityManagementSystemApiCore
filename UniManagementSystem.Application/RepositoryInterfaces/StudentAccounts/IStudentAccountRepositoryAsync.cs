using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniManagementSystem.Data.DomainEntities;
using UniManagementSystem.Data.DomainModels.InputModels.Authentication;
using UniManagementSystem.Data.DomainModels.ViewModels.StudentAccounts;

namespace UniManagementSystem.Application.RepositoryInterfaces.StudentAccounts
{
    public interface IStudentAccountRepositoryAsync
    {
        Task<StudentAccountViewModel> GetStudentAccountByIdAsync(int studentAccountId);
        Task<IEnumerable<StudentAccountViewModel>> GetAllStudentAccountsAsync();
        Task<StudentAccountViewModel> GetStudentAccountByEmailAndPassawordHash(UserAuthDetailsModel authDetails);
        Task<StudentAccount> CreateStudentAccountAsync(StudentAccount studentAccToCreate);
        Task<StudentAccount> UpdateStudentAccountAsync(StudentAccount studentAccToUpdate);
        Task<StudentAccount> DeleteStudentAccountAsync(StudentAccount studentAccountToRemove);
        Task<StudentAccount> GetStudentAccountByEmailAsync(string email);
    }
}
