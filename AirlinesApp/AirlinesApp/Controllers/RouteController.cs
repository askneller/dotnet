using AirlinesApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace AirlinesApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RouteController : Controller
    {

        private readonly ILogger<RouteController> _logger;
        private readonly AirlineContext _context;

        public RouteController(AirlineContext context, ILogger<RouteController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<Models.Route>> Get()
        {
            if (_context.Route == null)
            {
                _logger.LogError("Entity set 'AirlineContext.Route' is null");
                return Enumerable.Empty<Models.Route>();
            }

            var routes = from a in _context.Route
                         select a;
            var list = await routes.ToListAsync();
            Console.WriteLine("routes size " + list.Count);
            
            return list;
        }
    }
}
