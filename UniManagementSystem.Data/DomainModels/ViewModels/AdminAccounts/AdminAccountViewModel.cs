using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniManagementSystem.Data.Common;

namespace UniManagementSystem.Data.DomainModels.ViewModels.AdminAccounts
{
    public class AdminAccountViewModel : AuditFields
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsActive { get; set; }
        public string AdminEmail { get; set; }
    }
}
