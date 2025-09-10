using System;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniManagementSystem.Data.Common;

namespace UniManagementSystem.Data.DomainEntities
{
    public class AdminAccount : AuditFields
    {
        //Auto Incremented
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(250)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(250)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(20)]
        public string Gender { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        [MaxLength(250)]
        [EmailAddress]
        public string AdminEmail { get; set; }
        [Required]
        [MaxLength(300)]
        public string PasswordHash { get; set; }


        public ICollection<AdminAccountRole> AdminAccountRoles { get; set; }
    }
}
