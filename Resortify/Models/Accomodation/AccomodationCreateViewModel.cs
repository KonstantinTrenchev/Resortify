using Resortify.Data.Enums;
using System.ComponentModel.DataAnnotations;
using static Resortify.Data.Constants.DataConstants.AccomoditionConstants;
namespace Resortify.Models.Accomodation
{
    public class AccomodationCreateViewModel
    {
        [Required]
        [StringLength(MaxAccomodationNameLength,ErrorMessage ="[0] Must be betweeb [2] and [1] characters")]
        public string Name { get; set; }
        [Required]
        [MinLength(DescriptionMinLength, ErrorMessage = "[0] Must be atleast [1] characters")]
        public string Description { get; set; }
        [Required]
        public Accomodation_Type Type { get; set; }
        
        [Required]
        public string ImageUrl { get; set; }
    }
}
