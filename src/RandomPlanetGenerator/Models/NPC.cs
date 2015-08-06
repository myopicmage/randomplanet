using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomPlanetGenerator.Models {
    public class NPC {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Job { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public bool Friendly { get; set; }
    }

    public class Jobs : Possibility {
        public Jobs() {
            Possibilities = new string[] {
                "Dock Worker",
                "Politician",
                "Drug Dealer",
                "Farmer",
                "Scientist",
                "Hooker",
                "Ditch Digger",
                "Comedian",
                "Manager",
                "Psychic",
                "Psychic Mentor",
                "Weapons Specialist",
                "Secret Agent",
                "DESTROYER OF WORLDS",
                "Nurse",
                "Doctor",
                "Engineer",
                "Lawyer",
                "Professional Nuisance",
                "Professional Beach Bully",
                "Model",
                "Babysitter",
                "Welder",
                "Shipsmith",
                "Ship Builder",
                "Captain",
                "First Mate",
                "Retired",
                "Entrepeneur",
                "Blogger",
                "Singer",
                "Writer",
                "Butcher",
                "Baker", 
                "Candlestick Maker",
                "Hater"
            };
        }
    }
}
