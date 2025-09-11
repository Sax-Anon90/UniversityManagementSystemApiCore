using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniManagementSystem.Application.RepositoryInterfaces.StudentAccounts;
using UniManagementSystem.Data.DomainEntities;
using UniManagementSystem.Data.DomainModels.ViewModels.StudentAccounts;
using UniManagementSystem.Persistence.UniDbContext;

namespace UniManagementSystem.Persistence.RepositoryImplementations.StudentAccounts
{
    public class StudentAccountRepositoryAsync : IStudentAccountRepositoryAsync
    {
        private readonly UniManagementSystemDbContext _dbContext;
        public StudentAccountRepositoryAsync(UniManagementSystemDbContext _dbContext)
        {
            this._dbContext = _dbContext;
        }
        public async Task<StudentAccount> CreateStudentAccountAsync(StudentAccount studentAccToCreate)
        {
            await _dbContext.StudentAccounts.AddAsync(studentAccToCreate);
            await _dbContext.SaveChangesAsync();
            return studentAccToCreate;
        }

        public async Task<StudentAccount> DeleteStudentAccountAsync(StudentAccount studentAccountToRemove)
        {
            var studentAccount = await _dbContext.StudentAccounts.AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == studentAccountToRemove.Id);

            if (studentAccountToRemove is null)
            {
                return new StudentAccount() { Id = 0 };
            }

            studentAccount.IsActive = false;
            studentAccount.DateInactive = DateTime.UtcNow;
            _dbContext.StudentAccounts.Update(studentAccountToRemove);
            await _dbContext.SaveChangesAsync();
            return studentAccount;
        }

        public async Task<IEnumerable<StudentAccountViewModel>> GetAllStudentAccountsAsync()
        {
            var studentAccounts = await _dbContext.StudentAccounts.Select(x => new StudentAccountViewModel()
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Gender = x.Gender,
                StudentEmail = x.StudentEmail,
                StudentNumber = x.StudentNumber,
                IsActive = x.IsActive,
                DateOfBirth = x.DateOfBirth,
                DateCreated = x.DateCreated,
                DateModified = x.DateModified,
                DateInactive = x.DateInactive


            }).ToListAsync();

            if (!studentAccounts.Any())
            {
                return Enumerable.Empty<StudentAccountViewModel>();
            }
            return studentAccounts;
        }

        public async Task<StudentAccountViewModel> GetStudentAccountByIdAsync(int studentAccountId)
        {
            var studentAccount = await _dbContext.StudentAccounts.Select(x => new StudentAccountViewModel()
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Gender = x.Gender,
                StudentEmail = x.StudentEmail,
                StudentNumber = x.StudentNumber,
                IsActive = x.IsActive,
                DateOfBirth = x.DateOfBirth,
                DateCreated = x.DateCreated,
                DateModified = x.DateModified,
                DateInactive = x.DateInactive


            }).SingleOrDefaultAsync(x => x.Id == studentAccountId);

            if (studentAccount is not null)
            {
                return new StudentAccountViewModel() { Id = 0 };
            }

            return studentAccount;
        }

        public async Task<StudentAccount> UpdateStudentAccountAsync(StudentAccount studentAccToUpdate)
        {
            var studentAccount = await _dbContext.StudentAccounts.AsNoTracking()
                 .SingleOrDefaultAsync(x => x.Id == studentAccToUpdate.Id);

            if (studentAccount is null)
            {
                return new StudentAccount() { Id = 0 };
            }

            studentAccount.FirstName = studentAccToUpdate.FirstName;
            studentAccount.LastName = studentAccToUpdate.LastName;
            studentAccount.Gender = studentAccToUpdate.Gender;
            studentAccount.DateOfBirth = studentAccToUpdate.DateOfBirth;
            studentAccount.StudentEmail = studentAccToUpdate.StudentEmail;
            studentAccount.IsActive = studentAccToUpdate.IsActive;
            studentAccount.StudentNumber = studentAccToUpdate.StudentNumber;
            studentAccount.DateModified = DateTime.UtcNow;

            _dbContext.StudentAccounts.Update(studentAccount);
            await _dbContext.SaveChangesAsync();
            return studentAccount;
        }
    }
}
