using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using NuGet.Protocol.Core.Types;
using Resortify.Data;
using Resortify.Data.Models;

namespace Resortify.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<ResortifyUser> userManager;
        public UserRepository(ApplicationDbContext context,UserManager<ResortifyUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public int GetCount()
            => context.Users.Count();

        public bool IsAdmin(ResortifyUser user)
        {
            throw new NotImplementedException();
        }

        public bool IsOwner(ResortifyUser user)
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
                
                if (operation.Succeeded)
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

            if (operation.Succeeded)
            {
                output = true;
            }
            return output;
        }
        public async Task<bool> MakeUserAsync(ResortifyUser user,string password)
        {
            bool output = false;
           var createUser =  await userManager.CreateAsync(user, password);
            var assignUserRole = await userManager.AddToRoleAsync(user, "User");
            var assignUserRoleResult = assignUserRole;
            if (createUser.Succeeded && assignUserRoleResult.Succeeded)
            {
                output = true;
            }
            return output;
        }

    }
}
