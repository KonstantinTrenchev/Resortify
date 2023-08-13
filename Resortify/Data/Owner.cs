using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Resortify.Data.Constants.DataConstants.Owner;

namespace Resortify.Data
{
    public class Owner
    {
        [Key] 
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(UserId))]
        public ResortifyUser User { get; set; }
        [Required]
        public string UserId { get; set; }
        public List<Accomodation> Accomodations { get; set; }
    }
}
