using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniManagementSystem.Data.DomainModels.InputModels.StudentAccounts
{
    public class StudentAccountUpdateModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool IsActive { get; set; }

        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string StudentEmail { get; set; }
    }
}
