using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniManagementSystem.Data.Common;

namespace UniManagementSystem.Data.DomainModels.ViewModels.Courses
{
    public class CourseViewModel : AuditFields
    {
        public int Id { get; set; }
        public int CourseCategoryId { get; set; }
        public string Name { get; set; }
        public string CourseCategory { get; set; }
        public bool IsActive { get; set; }
    }
}
