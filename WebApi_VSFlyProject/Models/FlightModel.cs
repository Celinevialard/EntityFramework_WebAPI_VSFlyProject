using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApi_VSFlyProject.Models
{
    public class FlightModel
    {
        public string FlightNo { get; set; }
        public DateTime FlightDate { get; set; }
        public DateTime BoardingEndDate { get; set; }
        public DateTime CheckinEndDate { get; set; }
        public string Departure { get; set; }
        public string Destination { get; set; }
        public double Price { get; set; }
        public bool NonSmokingFlight { get; set; }
    }
}
