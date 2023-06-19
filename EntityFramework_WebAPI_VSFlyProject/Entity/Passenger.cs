using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework_WebAPI_VSFlyProject.Entity;

public class Passenger :Person
{
    public DateTime CustomerSince { get;set;}
    
    public virtual ICollection<Booking> Bookings { get; set; }
}
