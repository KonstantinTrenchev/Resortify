﻿//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using Resortify.Controllers;
//using Resortify.Data;
//using Resortify.Data.Models;
//using Resortify.Models.Owner;

//namespace Resortify.Areas.Owner.Controllers
//{
//    public class OwnerController : Controller
//    {
//        private readonly ApplicationDbContext data;
//        private readonly UserManager<ResortifyUser> userManager;

//        public OwnerController(ApplicationDbContext data, UserManager<ResortifyUser> userManager)
//        {
//            this.data = data;
//            this.userManager = userManager;
//        }
//        [Authorize]
//        public IActionResult Become()
//        {
//            return View();
//        }


//        [HttpPost]
//        [Authorize]
//        public async Task<IActionResult> Become(BecomeOwnerViewModel owner)
//        {
//            ResortifyUser user = await userManager.FindByNameAsync(User.Identity.Name);
//            Guid userId = user.Id;
//            if (user == null)
//            {
//                return BadRequest();
//            }

//            var userIdAlreadyOwner = data
//                .Owners
//                .Any(d => d.UserId == userId);

//            if (userIdAlreadyOwner)
//            {
//                return BadRequest();
//            }
//            var ownerAgency = owner.Agency.Trim();
//            if (!ModelState.IsValid)
//            {
//                return View(owner);
//            }
//            var ownerData = new Owner
//            {

//                Agency = owner.Agency,
//                UserId = userId,
//            };



//            user.PhoneNumber = owner.PhoneNumber;

//            data.Owners.Add(ownerData);
//            data.SaveChanges();

//            return RedirectToAction(nameof(HomeController.Index), "Home");
//        }
//    }
//}