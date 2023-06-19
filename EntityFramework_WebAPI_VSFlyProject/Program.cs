// Startup to create DB with some data
using EntityFramework_WebAPI_VSFlyProject;
using EntityFramework_WebAPI_VSFlyProject.Entity;

using (var ctx = new VSFlyContext())
{
    var DBCreated = ctx.Database.EnsureCreated();
    if (DBCreated)
        Console.WriteLine("Database created");
    else
        Console.WriteLine("Database already exist");

    Console.WriteLine("Done");

    seeder();

    void seeder()
    {
        
        Employee emp1 = new Employee()
        {
            GivenName = "Albert",
            FullName = "Einstein",
            Surname = "Bidule",
            Birthday = DateTime.Now,
            EMail = "toto@test.com",
            PassportNumber = "CH2022",
            Salary = 1000,
            PersonDetail = new PersonDetail()
            {
                City = "Martigny",
                Country = "Suiss",
                Postcode = "1920",
                Steet = "Chemin du milieu",
                Memo = "test"
            }
        };

        Employee emp2 = new Employee()
        {
            GivenName = "Toto",
            FullName = "test",
            Surname = "truc",
            Birthday = DateTime.Now,
            EMail = "toto@test.com",
            PassportNumber = "CH2023",
            Salary = 3000,
            PersonDetail = new PersonDetail()
            {
                City = "Martigny",
                Country = "Suiss",
                Postcode = "1920",
                Steet = "Avenu de la gare",
                Memo = "test"
            }
        };

        Passenger pass1 = new Passenger()
        {
            GivenName = "Tim",
            FullName = "Test",
            Surname = "Berners Lee",
            Birthday = DateTime.Now,
            EMail = "tim.bernerslee@internet.com",
            PersonDetail = new PersonDetail()
            {
                City="Sion",
                Country="Suiss",
                Postcode = "1950",
                Steet = "Avenu de la gare",
                Memo="test"
            }
        };
        
        Flight avion1 = new Flight()
        {
            FlightDate = DateTime.Now.AddMonths(1),
            BoardingEndDate = DateTime.Now,
            CheckinEndDate = DateTime.Now,
            Departure = "Geneva",
            Destination = "Amsterdam",
            FreeSeats = 2,
            LastChange = DateTime.Now,
            Price = 55,
            Seats = 180,
            NonSmokingFlight = true,
            Memo = "ceci est un memo.",
            FlightNo = "EZY11",
        };

        Flight avion2 = new Flight()
        {
            FlightDate = DateTime.Now.AddMonths(2),
            BoardingEndDate = DateTime.Now,
            CheckinEndDate = DateTime.Now,
            Departure = "Geneva",
            Destination = "London City",
            FreeSeats = 50,
            LastChange = DateTime.Now,
            Price = 150,
            Seats = 180,
            NonSmokingFlight = true,
            Memo = "ceci est un memo.",
            FlightNo = "LX342",
        };
        
        Booking booking1 = new Booking()
        {
            Price = 50,
            Passenger = pass1,
            Flight = avion1,
            PurchaseDate = DateTime.Now,
            FlightNo = avion1.FlightNo,
            PassengerId = pass1.Id,
        };
        

        ctx.Employees.AddRange(emp1, emp2);
        ctx.Passengers.Add(pass1);
        ctx.Flights.Add(avion1);
        ctx.Flights.Add(avion2);
        ctx.Bookings.Add(booking1);
        ctx.SaveChanges();

    }
}



    
    