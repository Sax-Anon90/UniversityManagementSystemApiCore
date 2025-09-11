using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniManagementSystem.Application.RepositoryInterfaces.CourseCategories;
using UniManagementSystem.Data.DomainEntities;
using UniManagementSystem.Data.DomainModels.ViewModels.CourseCategories;
using UniManagementSystem.Data.DomainModels.ViewModels.Courses;
using UniManagementSystem.Persistence.UniDbContext;

namespace UniManagementSystem.Persistence.RepositoryImplementations.CourseCategories
{
    public class CourseCategoryRepositoryAsync : ICourseCategoryRepositoryAsync
    {
        private readonly UniManagementSystemDbContext _dbContext;
        public CourseCategoryRepositoryAsync(UniManagementSystemDbContext _dbContext)
        {
            this._dbContext = _dbContext;
        }
        public async Task<CourseCategory> CreateCourseCategoryAsync(CourseCategory courseCategoryToCreate)
        {
            await _dbContext.CoursesCategories.AddAsync(courseCategoryToCreate);
            await _dbContext.SaveChangesAsync();
            return courseCategoryToCreate;
        }

        public async Task<CourseCategory> DeleteCourseCategoryAsync(CourseCategory courseCategoryToDelete)
        {
            var courseCategory = await _dbContext.CoursesCategories.AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == courseCategoryToDelete.Id);


            if (courseCategory is null)
            {
                return new CourseCategory() { Id = 0 };
            }

            courseCategory.IsActive = false;
            courseCategory.DateInactive = DateTime.UtcNow;
            _dbContext.CoursesCategories.Update(courseCategory);
            await _dbContext.SaveChangesAsync();

            return courseCategory;
        }

        public async Task<IEnumerable<CourseCategoryViewModel>> GetAllCourseCategoriesAsync()
        {
            var courseCategories = await _dbContext.CoursesCategories.Select(x => new CourseCategoryViewModel
            {
                Id = x.Id,
                Name = x.Name,
                IsActive = x.IsActive,
                DateCreated = x.DateCreated,
                DateModified = x.DateModified,
                DateInactive = x.DateInactive,
            }).ToListAsync();

            if (!courseCategories.Any())
            {
                return Enumerable.Empty<CourseCategoryViewModel>();
            }

            return courseCategories;
        }

        public async Task<CourseCategory> UpdateCourseCategoryAsync(CourseCategory courseCategoryToUpdate)
        {
            var courseCategory = await _dbContext.CoursesCategories.AsNoTracking().SingleOrDefaultAsync(x => x.Id == courseCategoryToUpdate.Id);

            if (courseCategory is null)
            {
                return new CourseCategory() { Id = 0 };
            }

            courseCategory.IsActive = true;
            courseCategory.Name = courseCategory.Name;
            _dbContext.CoursesCategories.Update(courseCategory);
            await _dbContext.SaveChangesAsync();
            return courseCategory;
        }
    }
}
