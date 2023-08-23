using System.ComponentModel.DataAnnotations;

namespace MagicVilla_VillaAPI.Models.DTOs
{
    public class VillaDto
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; } = string.Empty;
        [Required]
        public double Rate { get; set; }
        public string Details { get; set; } = string.Empty;
        public int Occupancy { get; set; }
        public int Sqft { get; set; }
        public string Amenity { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
    }
}
