namespace Resortify.Services.Models
{
    public class AccomodationServiceModel : IAccomodationModel
    {
        public int Id { get; set; }
        public string OwnerId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string OwnerName { get; set; }
        public string Type { get; set; }

    }
}
