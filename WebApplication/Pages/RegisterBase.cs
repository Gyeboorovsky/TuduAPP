using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TuduAPI.Models;
using WebApplication.Services;
using static WebApplication.Helpers.Validations;

namespace WebApplication.Pages
{
    public class RegisterBase : ComponentBase
    {
        [Inject]
        public IUserService UserService { get; set; }

        protected async Task AddUser(string username, string password, string email)
        {
            bool validUsername = ValidateUsername(username);
            bool validPassword = ValidatePassword(password);
            bool validEmail = ValidateEmail(email);

            if (validUsername && validPassword && validEmail)
            {
                User user = new User()
                {
                    Username = username,
                    Password = password,
                    Email = email
                };

                await UserService.AddUser(user);
            }
            else
            {
                Console.Write($"Validation failed:\n" +
                    $"Valid Username: {validUsername}\n" +
                    $"Valid Password: {validPassword}\n" +
                    $"Valid Email: {validEmail}");
            }
        }
    }
}
