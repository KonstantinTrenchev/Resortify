using Microsoft.AspNetCore.Identity;
using Resortify.Data.Models;
using Resortify.Repositories;

namespace Resortify.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        public UserService(IUserRepository userRepository)
        {
            this._repository = userRepository;
        }
        public int IdByUser(string userId)
        {
            throw new NotImplementedException();
        }

        public bool IsAdmin(string userId)
        {
            throw new NotImplementedException();
        }

        public bool IsOwner(string userId)
        {
            throw new NotImplementedException();
        }


    }
}
