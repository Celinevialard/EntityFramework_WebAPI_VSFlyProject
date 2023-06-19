using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework_WebAPI_VSFlyProject.Entity;

public class Pilot:Employee
{
    public double FlightHours { get; set; }

    public string FlightSchool { get; set; }

    public DateTime LicenseDate { get; set; }

    [InverseProperty("Pilot")]
    [ForeignKey("PilotId")]
    public virtual ICollection<Flight> PilotFlights { get; set; }
    [InverseProperty("Copilot")]
    [ForeignKey("CopilotId")]
    public virtual ICollection<Flight> CopilotFlights { get; set; }
}
