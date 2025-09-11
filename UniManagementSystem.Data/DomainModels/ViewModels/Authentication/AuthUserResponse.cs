using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniManagementSystem.Data.DomainModels.ViewModels.Authentication
{
    public class AuthUserResponse
    {
        public int UserId { get; set; }
        public string UserEmail { get; set; }
        public string DisplayName { get; set; }
        public bool IsAdmin { get; set; }
        public string JwtAccessToken { get; set; }
    }
}
