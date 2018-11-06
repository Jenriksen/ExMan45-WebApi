using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Ex45Man_WebApi.Models
{
    public class PointOfInterest
    {
        [Key]
        public long id {get; set;}
        [StringLength(20)]
        public string name {get; set;}
        [StringLength(100, MinimumLength=3)]
        public string description {get; set;}

        public City city;
        public int CityId;
        public PointOfInterest PointOfInterests { get; set; }
    }
}