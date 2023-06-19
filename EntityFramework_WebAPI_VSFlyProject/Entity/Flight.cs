using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework_WebAPI_VSFlyProject.Entity;

public class Flight
{
    [Key]
    public string FlightNo { get; set; }

    public virtual Pilot? Pilot { get; set; }

    public int? PilotId { get; set; }

    public virtual Pilot? Copilot { get; set; }

    public int? CopilotId { get; set; }

    public DateTime FlightDate { get; set; }

    public DateTime BoardingEndDate { get; set; }

    public DateTime CheckinEndDate { get; set; }

    public string Departure { get; set; }

    public string Destination { get; set; }

    public double Price { get; set; }

    public int FreeSeats { get;set; }

    public int Seats { get; set; }

    public string Memo { get; set; }

    public bool NonSmokingFlight { get; set; }

    public DateTime LastChange { get; set; }

    [ForeignKey("FlightNo")]
    [InverseProperty("Flight")]
    public virtual ICollection<Booking> Bookings { get; set; }
}
