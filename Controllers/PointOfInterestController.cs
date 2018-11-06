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
                _context.pointofinterests.Add(entity: new PointOfInterest { CityId = 1, Name = "HC Andersens hus", Description = "..." });
                _context.pointofinterests.Add(entity: new PointOfInterest { CityId = 1, Name = "Odense Zoo", Description = "..." });
                _context.pointofinterests.Add(entity: new PointOfInterest { CityId = 2, Name = "Bølgen", Description = "..." });
                _context.pointofinterests.Add(entity: new PointOfInterest { CityId = 2, Name = "Skyttehuset", Description = "..." });
                _context.SaveChanges();
            }

        }

        [HttpGet]
        public ActionResult<List<PointOfInterest>> Get()
        {
            return _context.pointofinterests.ToList();
        }

        [HttpGet("{id}", Name = "GetPointOfInterest")]
        public ActionResult<PointOfInterest> GetPointOfInterest(long id)
        {
            var poi = _context.pointofinterests.Find(id);

            if (poi == null)
            {
                return NotFound();
            }

            return poi;
        }

        [HttpGet("{CityId}/poi/{PoiId}")]
        public ActionResult<PointOfInterest> GetPointOfInterestForCity(long CityId, long PoiId)
        {
            var poi = _context.pointofinterests.Find(PoiId);

            return PoiId;
        }

        [HttpPost]
        public IActionResult Create(PointOfInterest pointOfInterest)
        {
            _context.pointofinterests.Add(pointOfInterest);
            _context.SaveChanges();



            return CreatedAtRoute("GetPointOfInterest", new { Id = pointOfInterest.Id }, pointOfInterest);
        }
    }
}