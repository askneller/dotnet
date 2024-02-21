using AirlinesApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace AirlinesApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DayFlightController : Controller
    {

        private readonly ILogger<DayFlightController> _logger;
        private readonly AirlineContext _context;

        public DayFlightController(AirlineContext context, ILogger<DayFlightController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<Models.DayFlight>> Get()
        {
            if (_context.Day_Flight == null)
            {
                _logger.LogError("Entity set 'AirlineContext.DayFlight' is null");
                return Enumerable.Empty<Models.DayFlight>();
            }

            var flights = from a in _context.Day_Flight
                          select a;
            var list = await flights.ToListAsync();
            Console.WriteLine("day flights size " + list.Count);
            
            return list;
        }
    }
}
