using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Ex45Man_WebApi.Models 
{
    public class City 
    {
        [Key]
        [Required]
        public long Id {get; set;}

        [Required]
        public string Name {get; set;}
        
        public string Description {get; set;}

        public List<PointOfInterest> Poi {get; set;}

    }

}