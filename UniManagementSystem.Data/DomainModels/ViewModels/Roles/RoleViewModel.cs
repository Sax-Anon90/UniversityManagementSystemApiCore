using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniManagementSystem.Data.Common;

namespace UniManagementSystem.Data.DomainModels.ViewModels.Roles
{
    public class RoleViewModel : AuditFields
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
