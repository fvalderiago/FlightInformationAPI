using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FlightInformationAPI.Models
{
    public class Flight
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Flight number is required")]
        [StringLength(10, ErrorMessage = "Flight number cannot exceed 10 characters")]
        public string FlightNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Airline is required")]
        public string Airline { get; set; } = string.Empty;

        [Required]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "Departure airport must be a 3-letter code")]
        public string DepartureAirport { get; set; } = string.Empty;

        [Required]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "Arrival airport must be a 3-letter code")]
        public string ArrivalAirport { get; set; } = string.Empty;

        [Required]
        public DateTime DepartureTime { get; set; }

        [Required]
        public DateTime ArrivalTime { get; set; }


        [Required]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public FlightStatus Status { get; set; }
    }
}
