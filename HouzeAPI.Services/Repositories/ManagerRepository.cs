using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HouzeAPI.Entities;
using HouzeAPI.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace HouzeAPI.Services.Repositories
{
    public class ManagerRepository : IManager
    {
        private readonly UserManager<AppUser> userManager;

        public ManagerRepository(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        public string GetUserImage(Guid id)
        {
            var user = GetUser(id).Result;
            return user.Image;
        }

        public string GetUserName(Guid id)
        {

            var user = GetUser(id).Result;
            return user.Name;
        }

        public async Task<AppUser> GetUser(Guid id)
        {
            var user = await userManager.FindByIdAsync(id.ToString());
            return user;
        }
    }
}
