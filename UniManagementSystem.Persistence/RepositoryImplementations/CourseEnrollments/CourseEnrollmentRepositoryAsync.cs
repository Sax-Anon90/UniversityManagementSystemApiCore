using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniManagementSystem.Application.RepositoryInterfaces.CourseEnrollments;
using UniManagementSystem.Data.DomainEntities;
using UniManagementSystem.Data.DomainModels.ViewModels.CourseEnrollments;

namespace UniManagementSystem.Persistence.RepositoryImplementations.CourseEnrollments
{
    public class CourseEnrollmentRepositoryAsync : ICourseEnrollmentRepositoryAsync
    {
        public CourseEnrollmentRepositoryAsync()
        {
            
        }
        public Task<CourseEnrollment> CreateCourseEnrollment(CourseEnrollment courseEnrollmentToCreate)
        {
            throw new NotImplementedException();
        }

        public Task<CourseEnrollment> DeleteCourseEnrollment(CourseEnrollment courseEnrollmentToRemove)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<string>> GetAllCourseEnrollmentNameByStudentIdAsync(int studentId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CourseEnrollmentViewModel>> GetAllStudentCourseEnrollmentsByStudentIdAsync(int studentId)
        {
            throw new NotImplementedException();
        }
    }
}
