using EntityFramework_WebAPI_VSFlyProject.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework_WebAPI_VSFlyProject
{
    public class VSFlyContext :DbContext
    {
        /*
        public VSFlyContext(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("Default");
        }
        */
        public VSFlyContext() { }

        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<PersonDetail> PersonDetails { get; set; }
        public DbSet<Pilot> Pilots { get; set; }

        public static string ConnectionString { get; set; } = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\DB\\VSFLY.MDF;Integrated Security=True;Connect Timeout=30";


        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(ConnectionString);
            builder.UseLazyLoadingProxies();
        }
    }
}
