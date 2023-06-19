using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework_WebAPI_VSFlyProject.Entity
{
    public class PersonDetail
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Postcode { get; set; }
        public string Steet { get; set; }
        public string Memo { get; set; }
    }
}
