using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Ex45Man_WebApi.Models 
{
    public class City 
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Added to auto-increment Id
        public int Id {get; set;}

        [Required]
        public string Name {get; set;}
        
        public string Description {get; set;}

        public List<PointOfInterest> PointOfInterests {get; set;}

    }

}