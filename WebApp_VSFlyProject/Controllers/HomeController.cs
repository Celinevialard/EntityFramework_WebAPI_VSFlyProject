using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Net;
using WebApp_VSFlyProject.Extensions;
using WebApp_VSFlyProject.Models;
using WebApp_VSFlyProject.Service;
using FlightViewModel = WebApp_VSFlyProject.Models.FlightViewModel;

namespace WebApp_VSFlyProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HTTPService _httpService;
        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _httpService = new HTTPService(configuration.GetConnectionString("Default"));
        }

        public async Task<IActionResult> Index()
        {
            ICollection<WebApi_VSFlyProject.Models.FlightModel>? flightModels = await _httpService.GetFlightsNotFull();

            List<FlightViewModel> flightViewModels = new List<FlightViewModel>();
            if (flightModels != null && flightModels.Any())
            {
                foreach (var flightM in flightModels)
                {
                    FlightViewModel flightVM = new FlightViewModel();
                    flightVM.FlightNo = flightM.FlightNo;
                    flightVM.FlightDate = flightM.FlightDate;
                    flightVM.Departure = flightM.Departure;
                    flightVM.Destination = flightM.Destination;
                    flightViewModels.Add(flightVM);
                }
            }
            return View(flightViewModels);
        }

        public async Task<IActionResult> Details(string flightNo)
        {
            double price = await _httpService.GetSaleByFlight(flightNo);

            FlightPriceViewModel flightPriceVM = new()
            {
                FlightNo = flightNo,
                Price = price
            };

            return View(flightPriceVM);
        }

        public IActionResult Book(string flightNo)
        {
            BookingViewModel bookingVM = new()
            {
                FlightNo = flightNo.ToString()
            };

            return View(bookingVM);
        }

        [HttpPost]
        public async Task<IActionResult> Book(BookingViewModel bookingVM)
        {
            if (!ModelState.IsValid)
            {
                return View(bookingVM);
            }
            bool isUpdate = await _httpService.BuyTicket(bookingVM.FlightNo, bookingVM.ConvertToBookingRegistrationModel());

            if (isUpdate)
                return RedirectToAction("Index");
            else
                return RedirectToAction("Index", "Error", new { errorCode = HttpStatusCode.InternalServerError });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}