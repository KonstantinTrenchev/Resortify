using Resortify.Data.Models;

namespace Resortify.Services
{
    public interface IUserService
    {
       int GetCount();
        Task<bool> MakeOwnerAsync(ResortifyUser user);
        Task<bool> IsOwnerAsync(ResortifyUser user);
        Task<bool> MakeAdminAsync(ResortifyUser user);
        Task<ResortifyUser> GetByUsernameAsync(string email);
        Task<bool> IsAdminAsync(ResortifyUser user);
        Task<bool> MakeUserAsync(ResortifyUser user, string password);
        Task<ResortifyUser> UserByUsernameAsync(string? name);
        Task<ResortifyUser> GetByIdAsync(string id);
    }
}
