namespace CarRentingSystem.Infrastructure
{
    using AutoMapper;
    using AutoMapper.Extensions.EnumMapping;
    using Resortify.Data.Enums;
    using Resortify.Data.Models;
    using Resortify.Services.Models;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

           // this.CreateMap<Accomodation, LatestCarServiceModel>();
           // this.CreateMap<CarDetailsServiceModel, CarFormModel>();

            this.CreateMap<Accomodation, AccomodationServiceModel>()
                .ConstructUsingServiceLocator();

            //this.CreateMap<Accomodation, Accomodation>()
            //    .ForMember(c => c.OwnerId, cfg => cfg.MapFrom(c => c.Owner.Id))
            //    .ForMember(c => c.Type, cfg => cfg.MapFrom(c => Enum.GetName(typeof(Accomodation_Type), c.Type)));
        }
    }
}
