using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomPlanetGenerator.Models {
    public abstract class Possibility {
        public string[] Possibilities { get; set; }
        public virtual string GetPossibility(Random r) => Possibilities[r.Next(Possibilities.Length)];
    }
}
