using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Resortify.Data;
using Resortify.Data.Models;
using Resortify.Models.Owner;

namespace Resortify.Controllers
{
    public class OwnerController : Controller
    {
        private readonly ApplicationDbContext data;
        private readonly UserManager<ResortifyUser> userManager;

        public OwnerController(ApplicationDbContext data, UserManager<ResortifyUser> userManager)
        {
            this.data = data;
            this.userManager = userManager;
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
            ResortifyUser user = await userManager.FindByNameAsync(User.Identity.Name);
            string userId = user.Id;
            if (user == null)
            {
                return BadRequest();
            }

            var userIdAlreadyOwner = this.data
                .Owners
                .Any(d => d.UserId == userId);

            if (userIdAlreadyOwner)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(owner);
            }
            var ownerData = new Owner();
            var ownerAgency = owner.Agency.Trim();
            if (owner.Agency == null)
            {

                ownerData.Agency = "Independent";
                ownerData.UserId = userId;

                   
            }
            else
            {
                ownerData.Agency = ownerAgency;
                ownerData.UserId = userId;
            }
            
            user.PhoneNumber = owner.PhoneNumber;

            this.data.Owners.Add(ownerData);
            this.data.SaveChanges();

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}