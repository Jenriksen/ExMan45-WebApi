using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Ex45Man_WebApi.Models 
{
    public class City 
    {
        public long id {get; set;}
        public string name {get; set;}
        public string description {get; set;}

        public List<PointOfInterest> poi {get; set;}

    }

}