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
        public bool Government { get; set; }

        public virtual ICollection<City> Cities { get; set; }
        public virtual ICollection<Quest> Quests { get; set; }
        public virtual ICollection<NPC> NPCs { get; set; }


        public Planet Generate() {
            var generator = new Random();
            var planet = new Planet();
            var names = new Names();
            var beliefs = new Beliefs();
            var exports = new Exports();
            var people = new People();
            var types = new PlanetTypes();
            var leanings = new PoliticalLeaning();
            var objectives = new QuestObjective();
            var qtypes = new QuestTypes();
            var jobs = new Jobs();

            planet.TechLevel = generator.Next(5) + 1;
            planet.Population = generator.Next();
            planet.Belief = beliefs.GetPossibility(generator);
            planet.PeopleType = people.GetPossibility(generator);
            planet.PlanetType = types.GetPossibility(generator);
            planet.MainExport = exports.GetPossibility(generator);
            planet.Cities = new List<City>();
            planet.Quests = new List<Quest>();
            planet.NPCs = new List<NPC>();
            planet.AllianceMember = generator.Next() % 2 == 0 ? true : false;
            planet.Government = generator.Next() % 2 == 0 ? true : false;
            planet.PoliticalLeaning = leanings.GetPossibility(generator);
            planet.Name = names.GetPossibility(generator);

            var numcities = generator.Next(10) + 1;
            var numquests = generator.Next(5) + 1;
            var numnpcs = generator.Next(10) + 5;

            for (int i = 0; i < numcities; i++) {
                planet.Cities.Add(new City {
                    Name = names.GetPossibility(generator),
                    MainExport = exports.GetPossibility(generator),
                    Population = generator.Next(planet.Population / numcities),
                    Spaceport = generator.Next() % 2 == 0 ? true : false
                });
            }

            for (int i = 0; i < numquests; i++) {
                planet.Quests.Add(new Quest {
                    Objective = objectives.GetPossibility(generator),
                    Quantity = generator.Next(10) + 1,
                    Type = qtypes.GetPossibility(generator)
                });
            }

            for (int i = 0; i < numnpcs; i++) {
                planet.NPCs.Add(new NPC {
                    Name = names.GetNPCName(),
                    Age = generator.Next(50) + 15,
                    Gender = generator.Next() % 2 == 0 ? "male" : "female",
                    Job = jobs.GetPossibility(generator),
                    Friendly = generator.Next() % 2 == 0 ? true : false
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
