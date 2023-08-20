using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Resortify.Data;
using Resortify.Data.Enums;
using Resortify.Data.Models;
using Resortify.Models.Accomodation;
using Resortify.Services.Models;
using System.Drawing.Drawing2D;

namespace Resortify.Services
{
    public class AccomodationService : IAccomodationService

    {
        private readonly ApplicationDbContext data;
        private readonly UserManager<ResortifyUser> userManager;
        private readonly AutoMapper.IConfigurationProvider mapper;

        public AccomodationService(ApplicationDbContext data, IMapper mapper, UserManager<ResortifyUser> _userManager)
        {
            this.data = data;
            this.mapper = mapper.ConfigurationProvider;
            userManager = _userManager;
        }
        public IEnumerable<AccomodationServiceModel> All()
        {
            var accommodations = data.Accomodations.ToList();
            var accomodationViewModels = new List<AccomodationServiceModel>();
            
                foreach (var accomodation in accommodations)
            {
                var owner =  userManager.Users.FirstOrDefault(u => u.Id == accomodation.OwnerId);
                var accomodationViewModel = new AccomodationServiceModel
                {
                    Id = accomodation.Id,
                    Name = accomodation.Name,
                    ImageUrl = accomodation.ImageUrl,
                    Type = Enum.GetName(accomodation.Type),
                    OwnerId = owner.Id,
                    OwnerName = owner.FullName                
                };
                accomodationViewModels.Add(accomodationViewModel);
            }
            return accomodationViewModels;
        }
        public IEnumerable<AccomodationServiceModel> ByUser(string userId)
        {
           return GetAccomodations(this.data
                 .Accomodations
                 .Where(c => c.OwnerId == userId));
        }
        private IEnumerable<AccomodationServiceModel> GetAccomodations(IQueryable<Accomodation> accomodationQuery)
        {
          return   accomodationQuery
                .ProjectTo<AccomodationServiceModel>(this.mapper)
                .ToList();
        }
    public int Create(string name, Accomodation_Type type, string description, string imageUrl, string ownerId)
        {
            var accomodation = new Accomodation
            {
                Name = name,
                Type = type,
                Description = description,
                ImageUrl = imageUrl,
               
                OwnerId
                = ownerId,
            };

            this.data.Accomodations.Add(accomodation);
            this.data.SaveChanges();

            return accomodation.Id;
        }

        public AccomodationDetailsViewModel Details(int accomodationId)
        {
          return  this.data
                            .Accomodations
                            .Where(c => c.Id == accomodationId)
                            .ProjectTo<AccomodationDetailsViewModel>(this.mapper)
                            .FirstOrDefault();
        }

        public bool Edit(int id,string name, Accomodation_Type type, string description, string imageUrl, string ownerId)
        {
            var accomodationData = this.data.Accomodations.Find(id);

            if (accomodationData == null)
            {
                return false;
            }

            accomodationData.Name = name;
            accomodationData.Type = type;
            accomodationData.Description = description;
            accomodationData.ImageUrl = imageUrl;

            this.data.SaveChanges();

            return true;
        }

        public bool IsByOwner(int carId, string dealerId)
        {
           return this.data
                 .Accomodations
                 .Any(c => c.Id == carId && c.OwnerId == dealerId);
        }

    }
}
