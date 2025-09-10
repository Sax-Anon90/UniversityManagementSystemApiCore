using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniManagementSystem.Data.DomainModels.InputModels.CourseEnrollements
{
    public class CourseEnrollmentInputModel
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
    }
}
