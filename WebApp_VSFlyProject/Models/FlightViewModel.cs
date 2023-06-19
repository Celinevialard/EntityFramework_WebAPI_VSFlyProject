using System.ComponentModel.DataAnnotations;

namespace WebApp_VSFlyProject.Models
{
    public class FlightViewModel
    {
        public string FlightNo { get; set; }

        [DisplayFormat(DataFormatString = "{0:g}")]
        public DateTime FlightDate { get; set; }
        public string Departure { get; set; }
        public string Destination { get; set; }

    }
}
