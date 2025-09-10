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
    public class AdminAccountRole : AuditFields
    {
        [Key]
        public int Id { get; set; }
        public int AdminAccountId{ get; set; }
        public int RoleId { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [ForeignKey(nameof(AdminAccountId))]
        public AdminAccount AdminAccount { get; set; }

        [ForeignKey(nameof(RoleId))]
        public Role Role { get; set; }
    }
}
