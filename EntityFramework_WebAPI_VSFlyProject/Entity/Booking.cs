using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework_WebAPI_VSFlyProject.Entity;

public class Booking
{
    public int Id { get; set; }
    public double Price { get; set; }

    public DateTime PurchaseDate { get; set; }

    public int PassengerId { get; set; }
    public virtual Passenger Passenger { get; set; }

    public string FlightNo { get; set; }
    public virtual Flight Flight { get; set; }
}
