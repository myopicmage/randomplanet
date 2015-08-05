using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomPlanetGenerator.Models
{
    public class City
    {
        public int Id { get; set; }
        public int PlanetId { get; set; }
        
        public string Name { get; set; }
        public long Population { get; set; }
        public string MainIndustry { get; set; }
        public string MainExport { get; set; }
        public bool Spaceport { get; set; }
    }
}
