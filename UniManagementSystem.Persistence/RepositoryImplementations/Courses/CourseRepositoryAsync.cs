using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniManagementSystem.Application.RepositoryInterfaces.Courses;
using UniManagementSystem.Data.DomainEntities;
using UniManagementSystem.Data.DomainModels.ViewModels.Courses;

namespace UniManagementSystem.Persistence.RepositoryImplementations.Courses
{
    public class CourseRepositoryAsync : ICourseRepositoryAsync
    {
        public CourseRepositoryAsync()
        {
            
        }
        public Task<Course> CreateCourseAsync(Course courseToCreate)
        {
            throw new NotImplementedException();
        }

        public Task<Course> DeleteCourseAsync(Course courseToDelete)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CourseViewModel>> GetAllCoursesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Course> UpdateCourseAsync(Course courseToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
