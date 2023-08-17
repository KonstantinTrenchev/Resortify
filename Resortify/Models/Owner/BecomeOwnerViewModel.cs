using Microsoft.Build.Framework;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static Resortify.Data.Constants.DataConstants.Owner;
namespace Resortify.Models.Owner
{
    public class BecomeOwnerViewModel
    {
        [System.ComponentModel.DataAnnotations.Required]
        [StringLength(MaxPhoneNumberLength, ErrorMessage ="[0] should be between [2] and [0] characters", MinimumLength = MinPhoneNumberLength)]
        public string PhoneNumber { get; set; }
        [DefaultValue("Independent")]
        [StringLength(MaxPhoneNumberLength, ErrorMessage = "[0] should be [1] characters at most")]
        public string Agency { get; set; }
    }
}
