using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using WebApplication.Services;

namespace WebApplication.Pages
{
    public class LoginBase : ComponentBase
    {
        public string Username { get; set; }
        [Inject]
        public IUserService UserService { get; set; }
        protected async Task GetUsername(string username, string password)
        {
            Username = await UserService.GetUsername(username, password);
        }
        protected async override Task OnInitializedAsync()
        {
            Username = await UserService.GetUsername("ragez", "mamatata");
        }
    }
}
