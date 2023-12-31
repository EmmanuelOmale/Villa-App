﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MagicVilla_VillaAPI.Models
{
    public class Villa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Detals { get; set; } = string.Empty;
        public double Rate { get; set; }
        public string Amenity { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public int Occupancy { get; set; }
        public int Sqft { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
