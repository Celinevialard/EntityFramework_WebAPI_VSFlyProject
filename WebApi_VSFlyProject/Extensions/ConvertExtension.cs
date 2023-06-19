using EntityFramework_WebAPI_VSFlyProject.Entity;
using System.Collections.ObjectModel;
using WebApi_VSFlyProject.Models;

namespace WebApi_VSFlyProject.Extensions
{
    //TODO flight (flight entity _> flightmodel, icollection f entity - icollection f model -> icollection flightmodel => se baser sur la premier methode)
    public static class ConvertExtension
    {
        public static Models.FlightModel ConvertToFlightModel(this EntityFramework_WebAPI_VSFlyProject.Entity.Flight f)
        {
            Models.FlightModel flightModel = new Models.FlightModel();
            flightModel.FlightNo = f.FlightNo;
            flightModel.FlightDate = f.FlightDate;
            flightModel.BoardingEndDate = f.BoardingEndDate;
            flightModel.CheckinEndDate = f.CheckinEndDate;
            flightModel.Departure = f.Departure;
            flightModel.Destination = f.Destination;
            flightModel.Price = f.GetPrice();
            flightModel.NonSmokingFlight = f.NonSmokingFlight;
            return flightModel;
        }

        public static ICollection<Models.FlightModel> ConvertToFlightsModel(this ICollection<EntityFramework_WebAPI_VSFlyProject.Entity.Flight> flights)
        {

            ICollection<Models.FlightModel> flightModels = new List<Models.FlightModel>();
            foreach (Flight flight in flights)
            {
                flightModels.Add(ConvertToFlightModel(flight));
            }
           
            return flightModels;
        }


        public static BookingModel ConvertToBookingModel(this Booking booking)
        {
            return new BookingModel()
            {
                Firstname = booking.Passenger.GivenName,
                Lastname = booking.Passenger.Surname,
                FlightNo = booking.FlightNo,
                Price = booking.Price
            };
        }

        public static ICollection<BookingModel> ConvertToBookingModels(this ICollection<Booking> bookings)
        {
            ICollection<BookingModel> bookingModels = new Collection<BookingModel>();

            foreach(Booking booking in bookings)
            {
                bookingModels.Add(booking.ConvertToBookingModel());
            }

            return bookingModels;
        }

        public static Booking ConvertToBooking(this BookingRegistrationModel bookingRM)
        {
            Booking booking = new Booking();
            Passenger passenger = new Passenger();
            PersonDetail personDetail = new PersonDetail();


            passenger.GivenName = bookingRM.GivenName;
            passenger.Surname = bookingRM.Surname;
            passenger.FullName = bookingRM.FullName;
            passenger.Birthday = bookingRM.Birthday;
            passenger.EMail = bookingRM.EMail;

            booking.Passenger = passenger;

            personDetail.City = bookingRM.City;
            personDetail.Steet = bookingRM.Street;
            personDetail.Country = bookingRM.Country;
            personDetail.Postcode = bookingRM.PostCode;
            personDetail.Memo = "vide";

            booking.Passenger.PersonDetail = personDetail;
            
            return booking;
        }

        public static double GetPrice(this Flight flight)
        {
            //If the airplane is more than 80% full regardless of the date:
            //sale price = 150% of the base price
            if ((double)flight.FreeSeats/(double)flight.Seats<0.2)
                return flight.Price * 1.5;

            //If the plane is filled less than 50% less than 1 month before departure:
            //sale price = 70% of the base price
            if ((double)flight.FreeSeats / (double)flight.Seats > 0.5 && flight.FlightDate < DateTime.Now.AddMonths(1))
                return flight.Price * 0.7;

            //If the plane is filled less than 20% less than 2 months before departure:
            //sale price = 80% of the base price
            if ((double)flight.FreeSeats / (double)flight.Seats > 0.8 && flight.FlightDate < DateTime.Now.AddMonths(2))
                return flight.Price * 0.8;

            //In all other cases:
            return flight.Price;
        }
       
    }
}
