using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace UniManagementSystem.Tools.Password
{
    public static class PasswordService
    {

        public static string GetPasswordHash(string password)
        {
            using (SHA512 sha512Hash = SHA512.Create())
            {
                // ComputeHash SHA512 Algorithm - Convert password string to byte array then hash the byte array 
                byte[] bytes = sha512Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Convert the hashed byte array to a string 
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
