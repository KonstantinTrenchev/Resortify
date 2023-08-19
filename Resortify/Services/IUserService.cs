using Microsoft.AspNetCore.Identity;
using Resortify.Data.Models;

namespace Resortify.Services
{
    public interface IUserService
    {
        public bool IsOwner(string userId);
        public bool IsAdmin(string userId);
        public int IdByUser(string userId);
    }
}
