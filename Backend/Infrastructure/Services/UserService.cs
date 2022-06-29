using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> userManager;

        public UserService(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task Create(AppUser appUser, string password)
        {
            await userManager.CreateAsync(appUser, password);
        }

        public async Task<AppUser> Delete(string userid)
        {
            AppUser appUser = await userManager.FindByIdAsync(userid);
            await userManager.DeleteAsync(appUser);
            return appUser;
        }

        public async Task<AppUser> Get(string userid)
        {
            return await userManager.FindByIdAsync(userid);
        }

        public async Task<IReadOnlyList<AppUser>> GetAll()
        {
            return await userManager.Users.ToListAsync();
        }

        public async Task<AppUser> Update(AppUser appUser)
        {
            await userManager.UpdateAsync(appUser);
            return appUser;
        }
    }
}