using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UniManagementSystem.Application.RepositoryInterfaces.JwtService;

namespace UniManagementSystem.Tools.Jwt
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _configuration;
        public JwtService(IConfiguration _configuration)
        {
            this._configuration = _configuration;
        }

        public string GenerateJwtTokenForUser(JwtParameters jwtParameters)
        {
            
            var claims = new List<Claim>
            {

                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            if (jwtParameters.IsAdmin)
            {
                var AdminAccountRoleClaims = new List<Claim>();

                if (jwtParameters.AdminAccountRoles.Count > 0)
                {
                    foreach (var userRole in jwtParameters.AdminAccountRoles)
                    {
                        AdminAccountRoleClaims.Add(new Claim(ClaimTypes.Role, userRole));
                    }
                }

                claims.Add(new Claim(JwtRegisteredClaimNames.NameId, jwtParameters.AdminData.Id.ToString()));
                claims.Add(new Claim("AdminAccountId", jwtParameters.AdminData.Id.ToString()));
                claims.Add(new Claim("UserType", "Admin"));
                claims.Add(new Claim("DisplayName", jwtParameters.AdminData.FirstName));
                claims.AddRange(AdminAccountRoleClaims);
            }
            else
            {
                claims.Add(new Claim(JwtRegisteredClaimNames.NameId, jwtParameters.studentData.Id.ToString()));
                claims.Add(new Claim("StudentAccountId", jwtParameters.studentData.Id.ToString()));
                claims.Add(new Claim("UserType", "Student"));
                claims.Add(new Claim("DisplayName", jwtParameters.studentData.FirstName));
                claims.Add(new Claim(ClaimTypes.Role, "Student"));
            }



            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"]));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                                            issuer: _configuration["JwtSettings:Issuer"],
                                            audience: _configuration["JwtSettings:Audience"],
                                            claims: claims,
                                            expires: DateTime.Now.AddHours(24),
                                            signingCredentials: signingCredentials);


            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);


        }
    }
}
