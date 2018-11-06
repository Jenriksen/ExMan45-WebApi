using Ex45Man_WebApi.Controllers;
using Microsoft.EntityFrameworkCore;

namespace Ex45Man_WebApi.Models
{
    public class CityContext : DbContext
    {
        public CityContext(DbContextOptions<CityContext> options) : base(options)
        {
            
        }
        public DbSet<City> cities {get;set;}
        public DbSet<PointOfInterest> pointofinterests {get;set;}
    }
}