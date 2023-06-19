using EntityFramework_WebAPI_VSFlyProject;
using EntityFramework_WebAPI_VSFlyProject.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using WebApi_VSFlyProject.Extensions;
using WebApi_VSFlyProject.Models;

namespace WebApi_VSFlyProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VsFlyController : ControllerBase
    {
        private readonly VSFlyContext _context;

        public VsFlyController(VSFlyContext context) 
        {
            _context = context;
        }

        //Return all available flights(not full)
        [HttpGet]
        public async Task<ActionResult<ICollection<FlightModel>>> GetFlightsNotFull()
        {
           ICollection<Flight> flightWithFreeSeats = await _context.Flights.Where(f => f.FreeSeats > 0 && f.FlightDate > DateTime.Now).ToListAsync();
           ICollection<FlightModel> flighWithFreeSeatM = flightWithFreeSeats.ConvertToFlightsModel();
           return Ok(flighWithFreeSeatM);
        }

        //Return the sale price of a flight if is not full and in future
        [HttpGet("salePrice/{flightNumber}")]
        public async Task<ActionResult<double>> GetSaleByFlight(string flightNumber)
        {
            Flight? flight = await _context.Flights.FirstOrDefaultAsync(f => f.FlightNo == flightNumber && f.FreeSeats > 0 && f.FlightDate > DateTime.Now);
            return flight?.GetPrice() ?? -1;
        }
        
        //Buying a ticket on a flight
        [HttpPost("{flightNumber}")]
        public async Task<ActionResult> BuyTicket(string flightNumber, [FromBody] BookingRegistrationModel bmodel)
        {
            Flight? flight = await _context.Flights.FirstOrDefaultAsync(f => f.FlightNo == flightNumber && f.FreeSeats > 0 && f.FlightDate > DateTime.Now);

            if (flight!=null)
            {
                Booking booking = bmodel.ConvertToBooking();
                booking.FlightNo = flightNumber;
                booking.PurchaseDate = DateTime.Now;
                booking.Price = flight.GetPrice();
     
                _context.Bookings.Add(booking);
                flight.FreeSeats -= 1;

                await _context.SaveChangesAsync();
                return NoContent();
            }
          
             return BadRequest();
 
        }
        
        //Return the total sale price of all tickets sold for a flight
        [HttpGet("sales/{flightNumber}")]
        public ActionResult<double> GetSalesByFlight(string flightNumber)
        {
            return _context.Bookings.Where(e => e.FlightNo == flightNumber).Sum(e=>e.Price);
        }

        //Return the average sale price of all tickets sold for a destination (multiple flights possible)
        [HttpGet("average/{destination}")]
        public async Task<ActionResult<double>> GetAverageSalesByDestination(string destination)
        {
            ICollection<Flight> flights = await _context.Flights.Where(f => f.Destination.Equals(destination)).ToListAsync();
            ICollection<String> flightsNo = flights.Select(f => f.FlightNo).ToList();
            ICollection<Booking> bookings = await _context.Bookings.Where(b => flightsNo.Contains(b.FlightNo)).ToListAsync();
            double avg = bookings.Average(b => b.Price);

            return Ok(avg);
         }
        
        //Return the list of all tickets sold for a destination 
        //with the first and last name of the travelers and the flight number as well as the sale price of each ticket
        [HttpGet("ticket/{destination}")]
        public async Task<ActionResult<ICollection<BookingModel>>> GetTicketsByDestination(string destination)
        {
            ICollection<Booking> bookings = await _context.Bookings.Where(e => e.Flight.Destination == destination).ToListAsync();
            return Ok(bookings.ConvertToBookingModels());
        }
        
    }
}