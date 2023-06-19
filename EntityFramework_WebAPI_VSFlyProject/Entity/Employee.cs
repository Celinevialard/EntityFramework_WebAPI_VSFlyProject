using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework_WebAPI_VSFlyProject.Entity;

public class Employee : Person
{
    public string PassportNumber { get; set; }

    public double Salary { get;set; }

    public virtual Employee? Supervisor { get; set; }
}
