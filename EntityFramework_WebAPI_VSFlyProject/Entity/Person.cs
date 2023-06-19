using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework_WebAPI_VSFlyProject.Entity;

public class Person
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Surname { get; set; }
    public string GivenName { get; set; }
    public string EMail { get; set; }
    public virtual PersonDetail PersonDetail { get; set; }
    public DateTime Birthday { get; set; }

}
