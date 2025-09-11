using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniManagementSystem.Application.RepositoryInterfaces.AdminAccountRoles;
using UniManagementSystem.Application.RepositoryInterfaces.AdminAccounts;
using UniManagementSystem.Application.RepositoryInterfaces.CourseCategories;
using UniManagementSystem.Application.RepositoryInterfaces.CourseEnrollments;
using UniManagementSystem.Application.RepositoryInterfaces.Courses;
using UniManagementSystem.Application.RepositoryInterfaces.Roles;
using UniManagementSystem.Application.RepositoryInterfaces.StudentAccounts;
using UniManagementSystem.Persistence.RepositoryImplementations.AdminAccountRoles;
using UniManagementSystem.Persistence.RepositoryImplementations.AdminAccounts;
using UniManagementSystem.Persistence.RepositoryImplementations.CourseCategories;
using UniManagementSystem.Persistence.RepositoryImplementations.CourseEnrollments;
using UniManagementSystem.Persistence.RepositoryImplementations.Courses;
using UniManagementSystem.Persistence.RepositoryImplementations.Roles;
using UniManagementSystem.Persistence.RepositoryImplementations.StudentAccounts;
using UniManagementSystem.Persistence.UniDbContext;

namespace UniManagementSystem.Persistence.ServiceRegistrations
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<UniManagementSystemDbContext>(options =>
             options.UseSqlite($"Data Source={Path.Combine(AppContext.BaseDirectory, "appdata/UniManagementSystem.db")}"));


            var serviceProvider = services.BuildServiceProvider();

            var dbContext = serviceProvider.GetRequiredService<UniManagementSystemDbContext>();

            dbContext.Database.MigrateAsync();

            services.AddScoped<IStudentAccountRepositoryAsync, StudentAccountRepositoryAsync>();
            services.AddScoped<IRoleRepositoryAsync, RoleRepositoryAsync>();
            services.AddScoped<ICourseRepositoryAsync, CourseRepositoryAsync>();
            services.AddScoped<ICourseEnrollmentRepositoryAsync, CourseEnrollmentRepositoryAsync>();
            services.AddScoped<ICourseCategoryRepositoryAsync, CourseCategoryRepositoryAsync>();
            services.AddScoped<IAdminAccountRepositoryAsync, AdminAccountRepositoryAsync>();
            services.AddScoped<IAdminAccountRoleRepositoryAsync, AdminAccountRoleRepositoryAsync>();

            return services;


        }
    }
}
