using Microsoft.AspNetCore.Mvc;
using WebApi_VSFlyProject.Models;
using WebApp_VSFlyProject.Models;
using WebApp_VSFlyProject.Service;

namespace WebApp_VSFlyProject.Controllers
{
    public class SalesController : Controller
    {
        private readonly ILogger<SalesController> _logger;
        private readonly HTTPService _httpService;
        public SalesController(ILogger<SalesController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _httpService = new HTTPService(configuration.GetConnectionString("Default"));
        }

        public IActionResult Search()
        {
            return View();
        }

        public async Task<IActionResult> DestinationInfo(string destination)
        {
            double avg = await _httpService.GetAverageSalesByDestination(destination);
            ICollection<BookingModel>? bookings = await _httpService.GetTicketsByDestination(destination);
            return View(new DestinationInfoViewModel()
            {
                Destination = destination,
                Average=avg,
                Bookings=bookings
            });
        }

        public async Task<IActionResult> FlightInfo(string flightNo)
        {
            double sales =  await _httpService.GetSalesByFlight(flightNo);
            return View(new FlightInfoViewModel()
            {
                FlightNo= flightNo,
                Sales=sales
            });
        }
    }
}
