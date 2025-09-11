using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniManagementSystem.Data.DomainModels.ViewModels.AdminAccounts;
using UniManagementSystem.Data.DomainModels.ViewModels.StudentAccounts;

namespace UniManagementSystem.Application.RepositoryInterfaces.JwtService
{
    public class JwtParameters
    {
        public List<string> AdminAccountRoles { get; set; } = new();
        public StudentAccountViewModel studentData { get; set; }
        public AdminAccountViewModel AdminData { get; set; }
        public bool IsAdmin { get; set; }
        public bool isStudent { get; set; }
    }
}
