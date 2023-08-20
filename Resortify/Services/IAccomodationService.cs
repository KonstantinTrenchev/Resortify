using Resortify.Data.Enums;
using Resortify.Models.Accomodation;
using Resortify.Services.Models;

namespace Resortify.Services
{
    public interface IAccomodationService
    {
        AccomodationDetailsViewModel Details(int carId);

        int Create(
            string name,
            Accomodation_Type model,
            string description,
            string imageUrl,
            string dealerId);

        bool Edit(int id,
            string name,
            Accomodation_Type model,
            string description,
            string imageUrl,
            string dealerId);

        IEnumerable<AccomodationServiceModel> ByUser(string userId);

        bool IsByOwner(int carId, string dealerId);
    }
}
