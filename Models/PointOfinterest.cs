using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Ex45Man_WebApi.Models
{
    public class PointOfInterest
    {
        [Key]
        public long Id {get; set;}
        [StringLength(20)]
        public string Name {get; set;}
        [StringLength(100, MinimumLength=3)]
        public string Description {get; set;}

        [ForeignKey("CityForeignKey")]
        public City City;
        public int CityId;
    }
}