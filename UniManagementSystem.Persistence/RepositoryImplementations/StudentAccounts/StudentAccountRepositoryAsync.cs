using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniManagementSystem.Application.RepositoryInterfaces.StudentAccounts;
using UniManagementSystem.Data.DomainEntities;
using UniManagementSystem.Data.DomainModels.ViewModels.StudentAccounts;

namespace UniManagementSystem.Persistence.RepositoryImplementations.StudentAccounts
{
    public class StudentAccountRepositoryAsync : IStudentAccountRepositoryAsync
    {
        public StudentAccountRepositoryAsync()
        {
            
        }
        public Task<StudentAccount> CreateStudentAccountAsync(StudentAccount studentAccToCreate)
        {
            throw new NotImplementedException();
        }

        public Task<StudentAccount> DeleteStudentAccountAsync(StudentAccount studentAccountToRemove)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<StudentAccountViewModel>> GetAllStudentAccountsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<StudentAccountViewModel> GetStudentAccountByIdAsync(int studentAccountId)
        {
            throw new NotImplementedException();
        }

        public Task<StudentAccount> UpdateStudentAccountAsync(StudentAccount studentAccToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
