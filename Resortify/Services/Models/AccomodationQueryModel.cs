namespace Resortify.Services.Models
{
    public class AccomodationQueryModel
    {
        public int CurrentPage { get; init; }

        public int AccomodationsPerPage { get; init; }

        public int TotalAccomodations { get; init; }

        public IEnumerable<AccomodationServiceModel> Accomodations { get; init; }
    }
}
