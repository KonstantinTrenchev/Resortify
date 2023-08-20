using Resortify.Data.Models;

namespace Resortify.Repositories
{
    public interface IUserRepository
    {
        int GetCount();
        Task<bool> MakeOwnerAsync(ResortifyUser user);
        bool IsOwner(ResortifyUser user);
        Task<bool> MakeAdminAsync(ResortifyUser user);
        Task<ResortifyUser> GetByUsernameAsync(string email);
        bool IsAdmin(ResortifyUser user);
        Task<bool> MakeUserAsync(ResortifyUser user, string password);
    }
}
