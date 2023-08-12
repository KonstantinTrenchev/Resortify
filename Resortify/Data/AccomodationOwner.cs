using System.ComponentModel.DataAnnotations;

namespace Resortify.Data
{
    public class AccomodationOwner
    {
        public class Owneer
        {
            public int Id { get; init; }

            [Required]
            [MaxLength(NameMaxLength)]
            public string Name { get; set; }

            [Required]
            [MaxLength(PhoneNumberMaxLength)]
            public string PhoneNumber { get; set; }

            [Required]
            public int UserId { get; set; }

            public IEnumerable<Accomodation> Cars { get; init; } = new List<Accomodation>();
        }
    }
}
