using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using NuGet.Protocol.Core.Types;
using Resortify.Data;
using Resortify.Data.Models;
using Resortify.Services;

namespace Resortify.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<ResortifyUser> userManager;

        public UserService(ApplicationDbContext context, UserManager<ResortifyUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public Task<ResortifyUser> GetByIdAsync(string id)
        {
            var user = userManager.FindByIdAsync(id);
            return user;
        }

        public async Task<ResortifyUser> GetByUsernameAsync(string username)
        {
            ResortifyUser user = await userManager.FindByNameAsync(username);
            return user;
        }

        public int GetCount()
            => context.Users.Count();

        public Task<bool> IsAdminAsync(ResortifyUser user)
        {

          return  userManager.IsInRoleAsync(user, "Admin");
        }

        public Task<bool> IsOwnerAsync(ResortifyUser user)
        {

            return userManager.IsInRoleAsync(user, "Owner");
        }

        public Task IsOwnerByIdAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> MakeAdminAsync(ResortifyUser user)
        {
            bool output = false;
            int count = GetCount();
            if (count == 1)
            {
                var operation = await userManager.AddToRoleAsync(user, "Admin");
                var remove = await userManager.RemoveFromRoleAsync(user, "User");

                if (operation.Succeeded && remove.Succeeded)
                {
                    output = true;
                }
            }

            return output;
        }

        public async Task<bool> MakeOwnerAsync(ResortifyUser user)
        {
            bool output = false;
            var operation = await userManager.AddToRoleAsync(user, "Owner");
            var remove = await userManager.RemoveFromRoleAsync(user, "User");

            if (operation.Succeeded && remove.Succeeded)
            {
                output = true;
            }
            return output;
        }
        public async Task<bool> MakeUserAsync(ResortifyUser user, string password)
        {
            bool output = false;
            var createUser = await userManager.CreateAsync(user, password);
            var assignUserRole = await userManager.AddToRoleAsync(user, "User");
            var assignUserRoleResult = assignUserRole;
            if (createUser.Succeeded && assignUserRoleResult.Succeeded)
            {
                output = true;
            }
            return output;
        }

        public async Task<ResortifyUser> UserByUsernameAsync(string? name)
        {
            ResortifyUser user = await userManager.FindByNameAsync(name);
            return user;
        }
    }
}
