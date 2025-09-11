using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniManagementSystem.Application.RepositoryInterfaces.JwtService
{
    public interface IJwtService
    {
        string GenerateJwtTokenForUserAsync(JwtParameters jwtParameters);
    }
}
