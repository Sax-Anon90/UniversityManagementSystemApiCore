using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniManagementSystem.Data.DomainEntities;
using UniManagementSystem.Data.DomainModels.ViewModels.CourseCategories;

namespace UniManagementSystem.Application.RepositoryInterfaces.CourseCategories
{
    public interface ICourseCategoryRepositoryAsync
    {
        Task<IEnumerable<CourseCategoryViewModel>> GetAllCourseCategoriesAsync();
        Task<CourseCategoryViewModel> GetCourseCategoryById(int courseCategoryId);

        Task<CourseCategory> CreateCourseCategoryAsync(CourseCategory courseCategoryToCreate);
        Task<CourseCategory> UpdateCourseCategoryAsync(CourseCategory courseCategoryToUpdate);
        Task<CourseCategory> DeleteCourseCategoryAsync(CourseCategory courseCategoryToDelete);

    }
}
