using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniManagementSystem.Data.DomainEntities;

namespace UniManagementSystem.Persistence.UniDbContext
{
    public partial class UniManagementSystemDbContext : DbContext
    {
        public UniManagementSystemDbContext()
        {

        }

        public UniManagementSystemDbContext(DbContextOptions<UniManagementSystemDbContext> options)
            : base(options)
        {

        }

        public virtual DbSet<AdminAccount> AdminAccounts { get; set; }
        public virtual DbSet<AdminAccountRole> AdminAccountRoles { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<CourseCategory> CoursesCategories { get; set; }
        public virtual DbSet<CourseEnrollment> CourseEnrollments { get; set; }
        public virtual DbSet<Role> Roles { get; set; }  
        public virtual DbSet<StudentAccount> StudentAccounts { get; set; }
    }
}
