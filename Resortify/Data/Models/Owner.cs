using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Resortify.Data.Constants.DataConstants.OwnerConstants;

namespace Resortify.Data.Models
{
    public class Owner
    {
        public Owner()
        {
            this.Accomodations = new List<Accomodation>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey(nameof(UserId))]
        public ResortifyUser User { get; set; }
        [Required]
        public string UserId { get; set; }
        [MaxLength(MaxAgnecyNameLength)]
        public string? Agency{ get; set; }
        public ICollection<Accomodation> Accomodations { get; set; }
    }
}
