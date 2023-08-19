using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Resortify.Data.Enums;
using static Resortify.Data.Constants.DataConstants.AccomoditionConstants;

namespace Resortify.Data.Models
{
    public class Accomodation
    {
        public Accomodation()
        {
            this.AccomoditionRents = new List<Rent>();
            this.AccomodationComments = new List<Comment>();
        }

        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(MaxAccomodationNameLength)]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public Accomodation_Type Type { get; set; }
        public ICollection<Comment> AccomodationComments { get; set; }
        public ResortifyUser Owner { get; set; }
        public int MaxRenterCount { get; set; }
        public string ImageUrl { get; set; }
        public ICollection<Rent> AccomoditionRents { get; set; }
        public bool IsRentedOut { get; set; }

    }
}