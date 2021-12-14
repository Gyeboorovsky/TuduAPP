using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebApplication.Helpers
{
    public class Validations
    {
        public static bool ValidateUsername(string username)
        {
            //1. condition
            if(username.Length < 4) return false;

            //2. condition
            if (username.Length > 16) return false;

            //3. condition
            if (username.Contains(" ")) return false;

            //4. condition
            string charactersAllowed = "abcdefghijklmnoprstqwxyz1234567890";

            foreach (char u in username)
            {
                if (!charactersAllowed.Contains(Char.ToLower(u)))
                {
                    return false;
                }
            }
            return true;

            //5. condition
            if(Regex.Matches(username, @"[a-zA-Z]") == null) return false;
        }

        public static bool ValidatePassword(string password)
        {
            if(password.Length < 8) return false; return true;
        }

        public static bool ValidateEmail(string email)
        {
            if(email.Contains('@')) return true; return false;
        }
    }
}
