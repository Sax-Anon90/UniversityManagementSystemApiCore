using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniManagementSystem.Data.Common;

namespace UniManagementSystem.Data.DomainEntities
{
    public class Course : AuditFields
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(250)]
        public string Name { get; set; }
        [Required]
        public bool IsActive { get; set; }

        public int CourseCategoryId { get; set; }

        [ForeignKey(nameof(CourseCategoryId))]
        public CourseCategory CourseCategory { get; set; }

        public ICollection<CourseEnrollment> CourseEnrollments { get; set; }
    }
}
