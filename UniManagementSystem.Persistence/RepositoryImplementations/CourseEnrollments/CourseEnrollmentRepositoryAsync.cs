using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniManagementSystem.Application.RepositoryInterfaces.CourseEnrollments;
using UniManagementSystem.Data.DomainEntities;
using UniManagementSystem.Data.DomainModels.ViewModels.CourseEnrollments;
using UniManagementSystem.Data.DomainModels.ViewModels.Courses;
using UniManagementSystem.Persistence.UniDbContext;

namespace UniManagementSystem.Persistence.RepositoryImplementations.CourseEnrollments
{
    public class CourseEnrollmentRepositoryAsync : ICourseEnrollmentRepositoryAsync
    {
        private readonly UniManagementSystemDbContext _dbContext;
        public CourseEnrollmentRepositoryAsync(UniManagementSystemDbContext _dbContext)
        {
            this._dbContext = _dbContext;
        }
        public async Task<CourseEnrollment> CreateCourseEnrollment(CourseEnrollment courseEnrollmentToCreate)
        {
            await _dbContext.CourseEnrollments.AddAsync(courseEnrollmentToCreate);
            await _dbContext.SaveChangesAsync();
            return courseEnrollmentToCreate;
        }

        public async Task<CourseEnrollment> DeleteCourseEnrollment(CourseEnrollment courseEnrollmentToRemove)
        {
            var courseEnrollment = await _dbContext.CourseEnrollments
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == courseEnrollmentToRemove.Id);

            if (courseEnrollment is null)
            {
                return new CourseEnrollment() { Id = 0 };
            }

            _dbContext.CourseEnrollments.Remove(courseEnrollment);
            await _dbContext.SaveChangesAsync();
            return courseEnrollment;

        }

        public async Task<IEnumerable<CourseEnrollmentViewModel>> GetAllStudentCourseEnrollmentsByStudentIdAsync(int studentId)
        {
            var courseEnrollments = await _dbContext.CourseEnrollments
                .Include(x => x.Student)
                .Include(x => x.Course)
                .Select(x => new CourseEnrollmentViewModel
                {
                    Id = x.Id,
                    StudentId = x.Student.Id,
                    StudentNumber = x.Student.StudentNumber,
                    StudentFullName = x.Student.FirstName + "" + x.Student.LastName,
                    CourseId = x.Course.Id,
                    CourseName = x.Course.Name,
                    DateCreated = x.DateCreated,
                    DateModified = x.DateModified,
                    DateInactive = x.DateInactive,
                })
                .Where(x => x.Id == studentId)
                .AsNoTracking()
                .ToListAsync();

            if (!courseEnrollments.Any())
            {
                return Enumerable.Empty<CourseEnrollmentViewModel>();
            }

            return courseEnrollments;
        }
    }
}
