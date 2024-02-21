using AirlinesApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace AirlinesApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AirlineController : Controller
    {

        private readonly ILogger<AirlineController> _logger;
        private readonly AirlineContext _context;

        public AirlineController(AirlineContext context, ILogger<AirlineController> logger)
        {
            _context = context;
            _logger = logger;
        }


        [HttpGet]
        public async Task<IEnumerable<Airlines>> Get()
        {
            if (_context.Airlines == null)
            {
                _logger.LogError("Entity set 'AirlineContext.Airlines' is null");
                return Enumerable.Empty<Airlines>();
            }

            var airlines = from a in _context.Airlines
                           select a;
            var list = await airlines.ToListAsync();
            Console.WriteLine("list size " + list.Count);

            return list;
        }
    }
}
