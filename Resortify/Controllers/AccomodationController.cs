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
        private readonly IAccomodationService accomodationService;

        public AccomodationController(ApplicationDbContext data, UserManager<ResortifyUser> userManager, IUserService _userService,IAccomodationService _accomodationService)
        {
            this.data = data;
            this.userManager = userManager;
            userService= _userService;
            accomodationService= _accomodationService;
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
        [AllowAnonymous]
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
            switch (accomodation.MaxRenterCount)
            {
                case 1:
                    accomodationDetails.Type = "Room";
                    break;
                case 2:
                    accomodationDetails.Type = "Studio";
                    break;
                case 4:
                    accomodationDetails.Type = "Apartment";
                    break;
                case 6:
                    accomodationDetails.Type = "House";
                    break;

                default:
                    break;
            }
            return View(accomodationDetails);
        }
        [AllowAnonymous]
        public async Task<IActionResult> All()
        {

            var myAccomodations = accomodationService.All();

            return View(myAccomodations);
        }
        [Authorize("Owner,Admin")]
        public async Task <IActionResult> Edit(int id)
        {
            var userId = this.User.Id();
            var user = await userManager.FindByIdAsync(userId);
            bool isOwner = await this.userService.IsOwnerAsync(user);
            bool isAdmin = await this.userService.IsAdminAsync(user);

            if (!isOwner && !isAdmin)
            {
                return RedirectToAction(nameof(OwnerController.Become), "Dealers");
            }

            var accomodation = this.accomodationService.Details(id);

            if (accomodation.OwnerId != userId && !isAdmin)
            {
                return Unauthorized();
            }

            var carForm = new AccomodationCreateViewModel
            {
                ImageUrl = accomodation.ImageUrl,
                Description = accomodation.Description,
                Name = accomodation.Name

            };

            return View(carForm);
        }

        [HttpPost]
        [Authorize("Owner,Admin")]
        public async Task<IActionResult> Edit(int id, AccomodationCreateViewModel accomodation)
        {
            var _accomodation = data.Accomodations.First(a => a.Id == id);
            var owner =userManager.Users.First(o => o.Id == _accomodation.OwnerId);
            bool isAdmin = await this.userService.IsAdminAsync(owner);
            if (owner == null && !User.IsAdmin())
            {
                return RedirectToAction(nameof(OwnerController.Become), "Dealers");
            }

            
            if (!ModelState.IsValid)
            {

                return View(accomodation);
            }

            if (_accomodation == null && !isAdmin)
            {
                return BadRequest();
            }

            var edited = this.accomodationService.Edit(
                id,
                accomodation.Name,
                accomodation.Type,
                accomodation.Description,
                accomodation.ImageUrl,
                owner.Id);
            if (!edited)
            {
                return BadRequest();
            }


            return RedirectToAction(nameof(Details), new { id,});
        }
    }
}
