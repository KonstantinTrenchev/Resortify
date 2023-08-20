using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Resortify.Data.Models;
using Resortify.Data;
using Resortify.Models.Accomodation;
using Microsoft.EntityFrameworkCore;
using Resortify.Services.Models;
using Resortify.Services;
using Resortify.Areas.Owner.Controllers;
using Resortify.Infrastructure.Extensions;

namespace Resortify.Controllers
{
    public class AccomodationController : Controller
    {
        private readonly ApplicationDbContext data;
        private readonly UserManager<ResortifyUser> userManager;
        private readonly IUserService userService;

        public AccomodationController(ApplicationDbContext data, UserManager<ResortifyUser> userManager, IUserService _userService)
        {
            this.data = data;
            this.userManager = userManager;
            userService= _userService;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add(AccomodationCreateViewModel accomodation)
        {
            ResortifyUser user = await userService.GetByUsernameAsync(User.Identity.Name);
            if (user == null)
            {
                return RedirectToAction(nameof(OwnerController.Become), "Owner");
            }

            if (!ModelState.IsValid)
            {


                return View(accomodation);
            }


            var accomodationData = new Accomodation
            {
                Name = accomodation.Name,
                Description = accomodation.Description,
                ImageUrl = accomodation.ImageUrl,
                IsRentedOut = false,
                Type = accomodation.Type,
                Owner = user

            };
            switch (accomodation.Type)
            {
                case Data.Enums.Accomodation_Type.Room:
                    accomodationData.MaxRenterCount = 1;
                    break;
                case Data.Enums.Accomodation_Type.Studio:
                    accomodationData.MaxRenterCount = 2;
                    break;
                case Data.Enums.Accomodation_Type.Apartment:
                    accomodationData.MaxRenterCount = 4;
                    break;
                case Data.Enums.Accomodation_Type.House:
                    accomodationData.MaxRenterCount = 6;
                    break;
                default:
                    break;
            }
            data.Accomodations.Add(accomodationData);
            data.SaveChanges();
            return RedirectToAction(nameof(Details), new { id = accomodationData.Id });
        }
        public async Task<IActionResult> Details(int id)
        {
            Accomodation accomodation = await data.Accomodations.FindAsync(id);
            ResortifyUser owner = await userService.GetByIdAsync(accomodation.OwnerId);
            if (accomodation == null)
            {
                return BadRequest();
            }
            AccomodationDetailsViewModel accomodationDetails = new AccomodationDetailsViewModel
            {
                Id = accomodation.Id,
                Name = accomodation.Name,
                OwnerId = owner.Id,
                OwnerName = owner.FullName,
                OwnerPhoneNumber = owner.PhoneNumber,
                ImageUrl = accomodation.ImageUrl,
                Description = accomodation.Description,
                MaxRenterCount = accomodation.MaxRenterCount.ToString()
            };
            return View(accomodationDetails);
        }
        public async Task<IActionResult> Mine(string id)
        {

            var myAccomodations = this.cars.ByUser(this.User.Id());

            return View(myAccomodations);
        }
    }
}
