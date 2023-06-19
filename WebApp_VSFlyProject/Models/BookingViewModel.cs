using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebApp_VSFlyProject.Models
{
    public class BookingViewModel
    {
        [Required]
        public string GivenName { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; } = new DateTime(1900, 1, 1, 0, 0, 0);
        [Required]
        public string EMail { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string PostCode { get; set; }
        [HiddenInput]
        public string FlightNo{ get; set; }
    }
}
