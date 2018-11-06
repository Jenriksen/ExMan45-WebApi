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
        private readonly CityContext _dbContext;

        public CityController(CityContext dbContext)
        {
            _dbContext = dbContext;

            if (_dbContext.cities.Count() == 0)
            {
                _dbContext.cities.Add(new City { Name = "Odense", Id = 1, Description = "Her bor du" });
                _dbContext.cities.Add(new City { Name = "Vejle", Id = 2, Description = "Her burde du bo" });
                _dbContext.SaveChanges();
            }
        }

        [HttpGet]
        public ActionResult<List<City>> Get()
        {

            return _dbContext.cities.ToList();
        }

        [HttpGet("{id}", Name = "GetCity")]
        public ActionResult<City> GetCity(long id)
        {
            var city = _dbContext.cities.Find(id);

            if (city == null)
            {
                return NotFound();
            }

            return city;
        }

        [HttpGet("{id}/withpoi")]
        public ActionResult<City> GetCityWithPoi(long id){
            var city = _dbContext.cities.Find(id);

            if(city==null){
                return NotFound();
            }

            return city;
        }

        [HttpPost]
        public IActionResult Create (City city){
            _dbContext.cities.Add(city);
            _dbContext.SaveChanges();

            return CreatedAtRoute("GetCity", new { Id = city.Id }, city);
        }


    }
}