using System.ComponentModel.DataAnnotations;
using static Resortify.Data.Constants.DataConstants.UserConstants;

namespace Resortify.Models.User
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(MaxFirstNameLength, ErrorMessage = "{0} should be between {2} and {1} characters", MinimumLength = MinFirstLength)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(MaxLastNameLength, ErrorMessage = "{0} should be between {2} and {1} characters", MinimumLength = MinLastNameLength)]
        public string LastName { get; set; }

        [Required]
        [StringLength(MaxUsernameLength, ErrorMessage = "{0} should be between {2} and {1} characters", MinimumLength = MinUsernameLength)]
        public string UserName { get; set; } = null!;

        [Required]
        [EmailAddress]
        [RegularExpression("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$",ErrorMessage ="Please enter a valid mail adress")]
        public string Email { get; set; } = null!;

        [Required]
        [StringLength(MaxPasswordLength, ErrorMessage = "{0} should be between {2} and {1} characters", MinimumLength = MinPasswordLength)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Compare(nameof(Password))]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; } = null!;
    }
}
