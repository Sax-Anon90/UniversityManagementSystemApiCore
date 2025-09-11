using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniManagementSystem.Data.DomainModels.InputModels.Authentication
{
    public class UserAuthDetailsModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
