using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TuduAPI.Models;

namespace WebApplication.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient httpClient;

        public UserService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var sss = await httpClient.GetJsonAsync<User[]>("/api/User");
            return sss;
        }

        public async Task<string> GetUsername(string username, string password)
        {
            string test = await httpClient.GetJsonAsync<string>($"/api/User/{username}/{password}");
            return test;
        }

        public async Task AddUser(User user)
        {
            await httpClient.SendJsonAsync(HttpMethod.Post, "/api/User", user);
        }
    }
}