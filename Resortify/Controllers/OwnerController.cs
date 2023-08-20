using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Resortify.Controllers;
using Resortify.Data;
using Resortify.Data.Models;
using Resortify.Models.Owner;
using Resortify.Repositories;
using Resortify.Services;

namespace Resortify.Areas.Owner.Controllers
{
    [Authorize(Roles ="User")]
    public class OwnerController : Controller
    {
        private readonly ApplicationDbContext data;
        private readonly UserManager<ResortifyUser> userManager;
        private readonly IUserRepository userRepository;
        private readonly IUserService userService;
        public OwnerController(ApplicationDbContext _data, UserManager<ResortifyUser> _userManager, IUserRepository _userRepository, IUserService _userService)
        {
            this.data = _data;
            this.userManager = _userManager;
            this.userRepository = _userRepository;
            userService = _userService;
        }
        [Authorize]
        public IActionResult Become()
        {
            return View();
        }


        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Become(BecomeOwnerViewModel owner)
        {
            ResortifyUser user = await userService.UserByUsernameAsync(User.Identity.Name);
            if (user == null)
            {
                return BadRequest();
            }

            var userIdAlreadyOwner = await userService.IsOwnerAsync(user);

            if (userIdAlreadyOwner)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return View(owner);
            }
            var result = await userService.MakeOwnerAsync(user);

            user.PhoneNumber = owner.PhoneNumber;

            data.SaveChanges();

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}