using EntityFramework_WebAPI_VSFlyProject.Entity;

namespace WebApi_VSFlyProject.Models
{
    public class BookingRegistrationModel
    {
        public string GivenName { get; set; }
        public string Surname { get; set; }
        public string FullName { get; set; }
        public DateTime Birthday { get; set; }
        public string EMail{ get; set; }
        public string City{ get; set; }
        public string Street{ get; set; }
        public string Country{ get; set; }
        public string PostCode{ get; set; }
    }
}
