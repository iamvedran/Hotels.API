using Microsoft.Build.Framework;

namespace Hotels.API.Models.Hotel
{
    public class UpdateHotelDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public double Longitude { get; set; }
        [Required]
        public double Latutude { get; set; }
    }
}
