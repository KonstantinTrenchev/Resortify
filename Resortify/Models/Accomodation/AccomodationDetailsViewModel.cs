namespace Resortify.Models.Accomodation
{
    public class AccomodationDetailsViewModel
    {
        public int Id { get; set; }
        public string OwnerId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public string OwnerName { get; set; }
        public string OwnerAgency { get; set; }
        public string OwnerPhoneNumber { get; set; }
        public string MaxRenterCount { get; set; }
    }
}
