namespace Resortify.Services.Models
{
    public class AccomodationServiceModel
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string OwnerName { get; set; }
        public string OwnerAgency { get; set; }
        public string Type { get; set; }
    }
}
