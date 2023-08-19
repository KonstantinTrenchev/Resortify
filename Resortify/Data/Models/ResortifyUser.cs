using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using static Resortify.Data.Constants.DataConstants.UserConstants;

namespace Resortify.Data.Models;

// Add profile data for application users by adding properties to the ResortifyUser class
public class ResortifyUser : IdentityUser
{
    public ResortifyUser()
    {
        this.Accomodations = new HashSet<Accomodation>();
    }
    [MaxLength(MaxFirstNameLength)]
    public string FirstName { get; set; }
    [Required]
    [MaxLength(MaxLastNameLength)]
    public string LastName { get; set; }
    public string FullName { get; set; }
    public ICollection<Accomodation> Accomodations { get;  set; }
}

