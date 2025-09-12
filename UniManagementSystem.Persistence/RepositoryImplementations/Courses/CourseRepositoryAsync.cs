using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniManagementSystem.Application.RepositoryInterfaces.Courses;
using UniManagementSystem.Data.DomainEntities;
using UniManagementSystem.Data.DomainModels.ViewModels.Courses;
using UniManagementSystem.Data.DomainModels.ViewModels.Roles;
using UniManagementSystem.Persistence.UniDbContext;

namespace UniManagementSystem.Persistence.RepositoryImplementations.Courses
{
    public class CourseRepositoryAsync : ICourseRepositoryAsync
    {
        private readonly UniManagementSystemDbContext _dbContext;
        public CourseRepositoryAsync(UniManagementSystemDbContext _dbContext)
        {
            this._dbContext = _dbContext;
        }
        public async Task<Course> CreateCourseAsync(Course courseToCreate)
        {
            await _dbContext.Courses.AddAsync(courseToCreate);
            await _dbContext.SaveChangesAsync();
            return courseToCreate;
        }

        public async Task<Course> DeleteCourseAsync(Course courseToDelete)
        {
            var course = await _dbContext.Courses.AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == courseToDelete.Id);

            if (course is null)
            {
                return new Course() { Id = 0 };
            }

            course.IsActive = false;
            course.DateInactive = DateTime.UtcNow;
            _dbContext.Courses.Update(course);
            await _dbContext.SaveChangesAsync();

            return course;

        }

        public async Task<IEnumerable<CourseViewModel>> GetAllCoursesAsync()
        {
            var courses = await _dbContext.Courses
                .Include(x => x.CourseCategory)
                .AsSplitQuery()
                .Select(x => new CourseViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    CourseCategory = x.CourseCategory.Name,
                    CourseCategoryId = x.CourseCategory.Id,
                    IsActive = x.IsActive,
                    DateCreated = x.DateCreated,
                    DateModified = x.DateModified,
                    DateInactive = x.DateInactive,
                })
            .AsNoTracking()
            .ToListAsync();

            if (!courses.Any())
            {
                return Enumerable.Empty<CourseViewModel>();
            }

            return courses;
        }

        public async Task<IEnumerable<CourseViewModel>> GetAllCoursesByCourseCategoryId(int courseCategoryId)
        {
            var courses = await _dbContext.Courses
                .Include(x => x.CourseCategory)
                .Where(x => x.CourseCategory.Id == courseCategoryId)
                .AsSplitQuery()
                .Select(x => new CourseViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    CourseCategory = x.CourseCategory.Name,
                    CourseCategoryId = x.CourseCategory.Id,
                    IsActive = x.IsActive,
                    DateCreated = x.DateCreated,
                    DateModified = x.DateModified,
                    DateInactive = x.DateInactive,
                })
            .AsNoTracking()
            .ToListAsync();

            if (!courses.Any())
            {
                return Enumerable.Empty<CourseViewModel>();
            }

            return courses;
        }

        public async Task<CourseViewModel> GetCourseByIdAsync(int courseId)
        {
            var course = await _dbContext.Courses
                 .Select(x => new CourseViewModel
                 {
                     Id = x.Id,
                     Name = x.Name,
                     CourseCategory = x.CourseCategory.Name,
                     CourseCategoryId = x.CourseCategory.Id,
                     IsActive = x.IsActive,
                     DateCreated = x.DateCreated,
                     DateModified = x.DateModified,
                     DateInactive = x.DateInactive,
                 })
             .AsNoTracking()
             .SingleOrDefaultAsync(x => x.Id == courseId);

            if (course is null)
            {
                return new CourseViewModel() { Id = 0 };
            }

            return course;
        }

        public async Task<Course> UpdateCourseAsync(Course courseToUpdate)
        {
            var course = await _dbContext.Courses.AsNoTracking().SingleOrDefaultAsync(x => x.Id == courseToUpdate.Id);

            if (course is null)
            {
                return new Course() { Id = 0 };
            }

            course.IsActive = true;
            course.Name = courseToUpdate.Name;
            course.DateModified = courseToUpdate.DateModified;
            _dbContext.Courses.Update(course);
            await _dbContext.SaveChangesAsync();
            return course;
        }
    }
}
