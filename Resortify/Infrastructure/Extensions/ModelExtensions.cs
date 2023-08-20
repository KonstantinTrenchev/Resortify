namespace Resortify.Infrastructure.Extensions
{
    using Resortify.Services.Models;

    public static class ModelExtensions
    {
        public static string GetInformation(this IAccomodationModel accomodation)
            => accomodation.Name + "-" + accomodation.Type + "-" + accomodation.OwnerName;
    }
}
