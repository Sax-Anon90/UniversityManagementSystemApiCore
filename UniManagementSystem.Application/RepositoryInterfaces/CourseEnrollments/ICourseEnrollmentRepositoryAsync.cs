using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniManagementSystem.Data.DomainEntities;
using UniManagementSystem.Data.DomainModels.ViewModels.CourseEnrollments;

namespace UniManagementSystem.Application.RepositoryInterfaces.CourseEnrollments
{
    public interface ICourseEnrollmentRepositoryAsync
    {
        Task<CourseEnrollment> CreateCourseEnrollment(CourseEnrollment courseEnrollmentToCreate);
        Task<CourseEnrollment> DeleteCourseEnrollment(CourseEnrollment courseEnrollmentToRemove);
        Task<IEnumerable<string>> GetAllCourseEnrollmentNameByStudentIdAsync(int studentId);
    }
}
