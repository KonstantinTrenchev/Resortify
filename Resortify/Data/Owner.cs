using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Resortify.Data.Constants.DataConstants.Owner;

namespace Resortify.Data
{
    public class Owner
    {
        int Id { get; set; }
        [Required]
        [MaxLength(MaxFirstNameLength)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(MaxLastNameLength)]
        public string LastName { get; set; }
        [Required]
        [ForeignKey(nameof(UserId))]
        public ResortifyUser User { get; set; }
        public int UserId { get; set; }
    }
}
