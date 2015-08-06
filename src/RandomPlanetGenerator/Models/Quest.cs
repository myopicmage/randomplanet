using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomPlanetGenerator.Models {
    public class Quest {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Objective { get; set; }
        public int Quantity { get; set; }
    }

    public class QuestTypes : Possibility {
        public QuestTypes() {
            Possibilities = new string[] {
                "Kill",
                "Collect"
            };
        }
    }

    public class QuestObjective : Possibility {
        public QuestObjective() {
            Possibilities = new string[] {
                "people",
                "talismans",
                "pieces of information",
                "political prisoners",
                "asylum seekers"
            };
        }
    }
}