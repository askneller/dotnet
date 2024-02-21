using AirlinesApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace AirlinesApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AirportController : Controller
    {

        private readonly ILogger<AirportController> _logger;
        private readonly AirlineContext _context;

        public AirportController(AirlineContext context, ILogger<AirportController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<Airport>> Get()
        {
            if (_context.Airport == null)
            {
                _logger.LogError("Entity set 'AirlineContext.Airport' is null");
                return Enumerable.Empty<Airport>();
            }

            var airports = from a in _context.Airport
                            select a;
            var list = await airports.ToListAsync();
            Console.WriteLine("list2 size " + list.Count);
            
            return list;
        }
    }
}
