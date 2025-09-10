using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniManagementSystem.Data.Common;

namespace UniManagementSystem.Data.DomainModels.ViewModels.AdminAccountRoles
{
    public class AdminAccountRoleViewModel : AuditFields
    {
        public int Id { get; set; }
        public int AdminAccountId { get; set; }
        public int RoleId { get; set; }

        public string RoleName { get; set; }
        public string AdminFullName { get; set; }
    }
}
