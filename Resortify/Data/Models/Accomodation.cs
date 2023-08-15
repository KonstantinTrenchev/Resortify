﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Resortify.Data.Enums;
using static Resortify.Data.Constants.DataConstants.AccomoditionConstants;

namespace Resortify.Data.Models
{
    public class Accomodation
    {
        public Accomodation()
        {
            Photos = new List<Photo>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(MaxAccomodationNameLength)]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public Accomodation_Type Type { get; set; }
        public List<Photo> Photos { get; set; }

        [ForeignKey(nameof(OwnerId))]
        public Owner Owner { get; set; }
        public int OwnerId { get; set; }
        public int MaxRenterCount { get; set; }
        public List<Rent> AccomoditionRents { get; set; }
        public bool IsRentedOut { get; set; }

    }
}