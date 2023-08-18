﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Resortify.Data.Models;
using Resortify.Data;
using Resortify.Models.Accomodation;
using Microsoft.EntityFrameworkCore;
namespace Resortify.Controllers
{
    public class AccomodationController : Controller
    {
        private readonly ApplicationDbContext data;
        private readonly UserManager<ResortifyUser> userManager;

        public AccomodationController(ApplicationDbContext data, UserManager<ResortifyUser> userManager)
        {
            this.data = data;
            this.userManager = userManager;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add(CreateAccomodationViewModel accomodation)
        {
            ResortifyUser user = await userManager.FindByNameAsync(User.Identity.Name);
            Owner ownerData = await data.Owners.FirstOrDefaultAsync(o => o.UserId == user.Id);
            if (ownerData == null)
            {
                return RedirectToAction(nameof(OwnerController.Become), "Dealers");
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
                Owner = ownerData
                
            };
            switch (accomodation.Type)
            {
                case Data.Enums.Accomodation_Type.Room: accomodationData.MaxRenterCount = 1;
                    break;
                case Data.Enums.Accomodation_Type.Studio: accomodationData.MaxRenterCount = 2;
                    break;
                case Data.Enums.Accomodation_Type.Apartment: accomodationData.MaxRenterCount= 4;
                    break;
                case Data.Enums.Accomodation_Type.House: accomodationData.MaxRenterCount = 6;
                    break;
                default:
                    break;
            }
            data.Accomodations.Add(accomodationData);
            data.SaveChanges();
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}
