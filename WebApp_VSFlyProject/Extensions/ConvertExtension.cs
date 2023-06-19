using WebApi_VSFlyProject.Models;
using WebApp_VSFlyProject.Models;

namespace WebApp_VSFlyProject.Extensions
{
    //TODO flight (flight entity _> flightmodel, icollection f entity - icollection f model -> icollection flightmodel => se baser sur la premier methode)
    public static class ConvertExtension
    {
      
        public static BookingRegistrationModel ConvertToBookingRegistrationModel(this BookingViewModel bookingVm)
        {
            return new BookingRegistrationModel()
            {
                Birthday = bookingVm.Birthday,
                City = bookingVm.City,
                Country = bookingVm.Country,
                EMail = bookingVm.EMail,
                FullName = bookingVm.FullName,
                GivenName = bookingVm.GivenName,
                PostCode = bookingVm.PostCode,
                Street = bookingVm.Street,
                Surname = bookingVm.Surname
            };
        }

    }
}
