using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using static Resortify.Data.Constants.DataConstants.Owner;

namespace Resortify.Data;

// Add profile data for application users by adding properties to the ResortifyUser class
public class ResortifyUser : IdentityUser
{
    [Required]
    [MaxLength(MaxFirstNameLength)]
    public string FirstName { get; set; }
    [Required]
    [MaxLength(MaxLastNameLength)]
    public string LastName { get; set; }

}

