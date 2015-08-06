using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomPlanetGenerator.Models {
    public class PoliticalLeaning : Possibility {
        public PoliticalLeaning() {
            Possibilities = new string[] {
                "Left",
                "Right",
                "Center",
                "Libertarian",
                "Anti-reestablishmentist",
                "Theocratic",
                "ANARCHY IN THE UK"
            };
        }
    }
}
