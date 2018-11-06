using System.Collections.Generic;
using System.Linq;
using Ex45Man_WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ex45Man_WebApi
{
    [Route("city")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly CityContext _context;

        public CityController(CityContext Context)
        {
            _context = Context;

            if (_context.cities.Count() == 0)
            {
                _context.cities.Add(new City { Name = "Odense", Id = 1, Description = "Her bor du" });
                _context.cities.Add(new City { Name = "Vejle", Id = 2, Description = "Her burde du bo" });

                _context.pointofinterests.Add(new PointOfInterest { CityId = 1, Name = "HC Andersens hus", Description = "..." });
                _context.pointofinterests.Add(new PointOfInterest { CityId = 1, Name = "Odense Zoo", Description = "..." });
                _context.pointofinterests.Add(new PointOfInterest { CityId = 2, Name = "Bølgen", Description = "..." });
                _context.pointofinterests.Add(new PointOfInterest { CityId = 2, Name = "Skyttehuset", Description = "..." });

                _context.SaveChanges();
            }
        }

        [HttpGet]
        public IEnumerable<City> Get()
        {

            return _context.cities.Include(x => x.PointOfInterests);
        }

        [HttpGet("{id}", Name = "GetCity")]
        public ActionResult<City> GetCity(long id)
        {
            var city = _context.cities.Find(id);

            if (city == null)
            {
                return NotFound();
            }

            return city;
        }

        [HttpGet("{id}/withpoi")]
        public ActionResult<City> GetCityWithPoi(long id){
            var city = _context.cities.Find(id);

            if(city==null){
                return NotFound();
            }

            return city;
        }

        [HttpPost]
        public IActionResult Create (City city){
            _context.cities.Add(city);
            _context.SaveChanges();

            return CreatedAtRoute("GetCity", new { Id = city.Id }, city);
        }


    }
}