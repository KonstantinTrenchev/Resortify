using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resortify.Data.Models
{
    public class Rent
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime RentStartDate { get; set; }
        [Required]
        public DateTime RentEndDate { get; set; }
        [Required]
        public Accomodation Accomodation { get; set; }
    }
}
