using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Workboard.Application.Helper
{
    public static class PasswordHashHelper
    {
        private static readonly PasswordHasher<object> hasher_ = new();

        public static string HashPassword(string password)
        {
            return hasher_.HashPassword(null, password);
        }

        public static bool VerifyPassword(string hashedPassword, string providedPassword)
        {
            var result = hasher_.VerifyHashedPassword(null, hashedPassword, providedPassword);

            return result == PasswordVerificationResult.Success;
        }
    }
}
