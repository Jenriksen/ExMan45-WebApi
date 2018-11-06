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
                _dbContext.cities.Add(new City { name = "Odense", id = 1, description = "Her bor du" });
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

        //[HttpPost]


    }
}