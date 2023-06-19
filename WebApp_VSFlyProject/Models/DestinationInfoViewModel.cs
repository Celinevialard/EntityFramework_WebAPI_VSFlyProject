using WebApi_VSFlyProject.Models;

namespace WebApp_VSFlyProject.Models
{
    public class DestinationInfoViewModel
    {
        public string Destination { get; set; } = string.Empty;
        public double Average { get; set; }
        public IEnumerable<BookingModel>? Bookings { get; set; }
    }
}
