using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ex45Man_WebApi.Models;
using System.Linq;
using System.Collections.Generic;

namespace Ex45Man_WebApi.Controllers
{
    [ApiController]
    [Route("city/poi")]
    public class PointOfInterestController : ControllerBase
    {
        private readonly CityContext _context;

        public PointOfInterestController(CityContext context)
        {
            _context = context;

            if (_context.pointofinterests.Count() == 0)
            {
                _context.pointofinterests.Add(new PointOfInterest { city=, id = 1, name = "HC Andersens hus", description = "..." });
                _context.SaveChanges();
            }

        }

        [HttpGet]
        public ActionResult<List<PointOfInterest>>  Get()
        {
            return _context.pointofinterests.ToList();
        }
    }
}