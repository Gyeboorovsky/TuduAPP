using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TuduAPI.Models;
using WebApplication.Services;

namespace WebApplication.Pages
{
    public class UsersBase : ComponentBase
    {
        public IEnumerable<User> Users { get; set; }

        [Inject]
        public IUserService UserService { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Users = await UserService.GetUsers();
        }
    }
}
