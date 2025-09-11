using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniManagementSystem.Application.RepositoryInterfaces.PasswordService
{
    public interface IPasswordService
    {
        string GetPasswordHash(string password);
    }
}
