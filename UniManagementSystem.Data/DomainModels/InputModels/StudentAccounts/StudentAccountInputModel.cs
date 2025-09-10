using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniManagementSystem.Data.DomainModels.InputModels.StudentAccounts
{
    public class StudentAccountInputModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string StudentEmail { get; set; }
        public string Password { get; set; }
    }
}
