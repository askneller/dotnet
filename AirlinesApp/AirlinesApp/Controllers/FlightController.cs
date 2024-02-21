using AirlinesApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace AirlinesApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FlightController : Controller
    {

        private readonly ILogger<FlightController> _logger;
        private readonly AirlineContext _context;

        public FlightController(AirlineContext context, ILogger<FlightController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<Models.Flight>> Get()
        {
            if (_context.Flight == null)
            {
                _logger.LogError("Entity set 'AirlineContext.Flight' is null");
                return Enumerable.Empty<Models.Flight>();
            }

            var flights = from a in _context.Flight
                         select a;
            var list = await flights.ToListAsync();
            Console.WriteLine("flights size " + list.Count);
            
            return list;
        }
    }
}
