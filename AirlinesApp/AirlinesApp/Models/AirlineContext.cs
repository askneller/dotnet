using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace AirlinesApp.Models
{
    public class AirlineContext : DbContext
    {
        public AirlineContext(DbContextOptions<AirlineContext> options) : base(options) 
        {
            Console.WriteLine("options");
            Console.WriteLine(options.ToString());
        }

        public DbSet<AirlinesApp.Models.Airlines> Airlines { get; set; } = default!;
        public DbSet<AirlinesApp.Models.Airport> Airport { get; set; } = default!;
        public DbSet<AirlinesApp.Models.Route> Route { get; set; } = default!;
        public DbSet<AirlinesApp.Models.Flight> Flight { get; set; } = default!;
        public DbSet<AirlinesApp.Models.DayFlight> Day_Flight { get; set; } = default!;
    }
}
