using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RandomPlanetGenerator.Models {
    public class Planet {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TechLevel { get; set; }
        public string MainExport { get; set; }
        public int Population { get; set; }
        public string PlanetType { get; set; }
        public string Belief { get; set; }
        public string PeopleType { get; set; }
        public string Image { get; set; }
        public bool AllianceMember { get; set; }
        public string PoliticalLeaning { get; set; }

        public virtual ICollection<City> Cities { get; set; }

        public Planet Generate() {
            var generator = new Random();
            var planet = new Planet();
            var names = new Names();

            planet.TechLevel = generator.Next(5) + 1;
            planet.Population = generator.Next();
            planet.Belief = Beliefs.Possibilities[generator.Next(Beliefs.Possibilities.Length)];
            planet.PeopleType = People.Possibilities[generator.Next(People.Possibilities.Length)];
            planet.PlanetType = PlanetTypes.Possibilities[generator.Next(PlanetTypes.Possibilities.Length)];
            planet.MainExport = Exports.Possibilities[generator.Next(Exports.Possibilities.Length)];
            planet.Cities = new List<City>();
            planet.AllianceMember = generator.Next() % 2 == 0 ? true : false;
            planet.PoliticalLeaning = Models.PoliticalLeaning.Possibilities[generator.Next(Models.PoliticalLeaning.Possibilities.Length)];
            planet.Name = names.GetName();

            var numcities = generator.Next(11) + 1;

            for (int i = 0; i < numcities; i++) {
                planet.Cities.Add(new City {
                    Name = names.GetName(),
                    MainExport = Exports.Possibilities[generator.Next(Exports.Possibilities.Length)],
                    Population = generator.Next(planet.Population / numcities),
                    Spaceport = generator.Next() % 2 == 0 ? true : false
                });
            }

            return planet;
        }

        public override string ToString() {
            var vowels = new char[] { 'a', 'e', 'i', 'o', 'u' };
            var first = "A";

            if (vowels.Contains(PlanetType.ToLower().First())) {
                first = "An";
            }

            return string.Format("{4} {0} populated by {1}, who believe that {2}, and whose main export is {3}", PlanetType, PeopleType, Belief, MainExport, first);
        }
    }
}
