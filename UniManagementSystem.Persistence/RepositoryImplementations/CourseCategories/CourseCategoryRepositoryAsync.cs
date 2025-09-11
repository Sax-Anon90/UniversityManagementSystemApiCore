using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniManagementSystem.Application.RepositoryInterfaces.CourseCategories;
using UniManagementSystem.Data.DomainEntities;
using UniManagementSystem.Data.DomainModels.ViewModels.CourseCategories;

namespace UniManagementSystem.Persistence.RepositoryImplementations.CourseCategories
{
    public class CourseCategoryRepositoryAsync : ICourseCategoryRepositoryAsync
    {
        public CourseCategoryRepositoryAsync()
        {
            
        }
        public Task<CourseCategory> CreateCourseCategoryAsync(CourseCategory courseCategoryToCreate)
        {
            throw new NotImplementedException();
        }

        public Task<CourseCategory> DeleteCourseCategoryAsync(CourseCategory courseCategoryToDelete)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CourseCategoryViewModel>> GetAllCourseCategoriesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CourseCategory> UpdateCourseCategoryAsync(CourseCategory courseCategoryToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
