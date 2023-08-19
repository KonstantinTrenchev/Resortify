//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using Resortify.Data.Models;
//using Resortify.Data;
//using Resortify.Models.Accomodation;
//using Microsoft.EntityFrameworkCore;
//using Resortify.Services.Models;

//namespace Resortify.Controllers
//{
//    public class AccomodationController : Controller
//    {
//        private readonly ApplicationDbContext data;
//        private readonly UserManager<ResortifyUser> userManager;

//        public AccomodationController(ApplicationDbContext data, UserManager<ResortifyUser> userManager)
//        {
//            this.data = data;
//            this.userManager = userManager;
//        }
//        [HttpGet]
//        public IActionResult Add()
//        {
//            return View();
//        }
//        [HttpPost]
//        [Authorize]
//        public async Task<IActionResult> Add(AccomodationCreateViewModel accomodation)
//        {
//            ResortifyUser user = await userManager.FindByNameAsync(User.Identity.Name);
//            Owner ownerData = await data.Owners.FirstOrDefaultAsync(o => o.UserId == user.Id);
//            if (ownerData == null)
//            {
//                return RedirectToAction(nameof(OwnerControlleer.Become), "Dealers");
//            }

//            if (!ModelState.IsValid)
//            {


//                return View(accomodation);
//            }


//            var accomodationData = new Accomodation
//            {
//                Name = accomodation.Name,
//                Description = accomodation.Description,
//                ImageUrl = accomodation.ImageUrl,
//                IsRentedOut = false,
//                Type = accomodation.Type,
//                OwnerId = ownerData.Id

//            };
//            switch (accomodation.Type)
//            {
//                case Data.Enums.Accomodation_Type.Room:
//                    accomodationData.MaxRenterCount = 1;
//                    break;
//                case Data.Enums.Accomodation_Type.Studio:
//                    accomodationData.MaxRenterCount = 2;
//                    break;
//                case Data.Enums.Accomodation_Type.Apartment:
//                    accomodationData.MaxRenterCount = 4;
//                    break;
//                case Data.Enums.Accomodation_Type.House:
//                    accomodationData.MaxRenterCount = 6;
//                    break;
//                default:
//                    break;
//            }
//            data.Accomodations.Add(accomodationData);
//            data.SaveChanges();
//            Console.WriteLine(ownerData.Accomodations);
//            return RedirectToAction(nameof(Details), new { id = accomodationData.Id });
//        }
//        public async Task<IActionResult> Details(int id)
//        {
//            Accomodation accomodation = await data.Accomodations.FindAsync(id);
//            if (accomodation == null)
//            {
//                return BadRequest();
//            }
//            Owner owner = await data.Owners.FindAsync(accomodation.OwnerId);
//            ResortifyUser userIdentity = await userManager.FindByIdAsync(owner.UserId);
//            string RentedOut = $"{accomodation.AccomoditionRents.Count}/{accomodation.MaxRenterCount}";
//            AccomodationDetailsViewModel accomodationDetails = new AccomodationDetailsViewModel
//            {
//                Id = accomodation.Id,
//                Name = accomodation.Name,
//                OwnerId = owner.Id,
//                OwnerName = userIdentity.FullName,
//                OwnerAgency = owner.Agency,
//                OwnerPhoneNumber = owner.User.PhoneNumber,
//                ImageUrl = accomodation.ImageUrl,
//                Description = accomodation.Description,
//                HaveAlreadyRented = RentedOut
//            };
//            return View(accomodationDetails);
//        }
//        public async Task<IActionResult> Mine(int id)
//        {

//            Owner owner = await data.Owners.FindAsync(id);
//            ResortifyUser user = await userManager.FindByIdAsync(owner.UserId);
//            var accomodationsData = data.Accomodations.Where(a => a.OwnerId == id);
//            List<AccomodationServiceModel> accomodations = new List<AccomodationServiceModel>();
//            foreach (var accomodationData in accomodationsData)
//            {
//                string RentedOut = $"{accomodationData.AccomoditionRents.Count}/{accomodationData.MaxRenterCount}";
//                AccomodationServiceModel accomodationDetails = new AccomodationServiceModel
//                {
//                    Id = accomodationData.Id,
//                    Name = accomodationData.Name,
//                    OwnerId = owner.Id,
//                    OwnerName = user.FullName,
//                    OwnerAgency = owner.Agency,

//                };
//                accomodations.Add(accomodationDetails);

//            }

//            return View(accomodations);
//        }
//    }
//}
