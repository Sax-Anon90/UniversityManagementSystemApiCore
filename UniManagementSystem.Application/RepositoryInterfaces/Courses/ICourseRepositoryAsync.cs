using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniManagementSystem.Data.DomainEntities;
using UniManagementSystem.Data.DomainModels.ViewModels.Courses;

namespace UniManagementSystem.Application.RepositoryInterfaces.Courses
{
    public interface ICourseRepositoryAsync
    {
        Task<IEnumerable<CourseViewModel>> GetAllCoursesAsync();
        Task<CourseViewModel> GetCourseByIdAsync(int courseId);
        Task<IEnumerable<CourseViewModel>> GetAllCoursesByCourseCategoryId(int courseCategoryId);
        Task<Course> CreateCourseAsync(Course courseToCreate);
        Task<Course> UpdateCourseAsync(Course courseToUpdate);
        Task<Course> DeleteCourseAsync(Course courseToDelete);
    }
}
