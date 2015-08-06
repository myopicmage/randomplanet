using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomPlanetGenerator.Models {
    public class Names : Possibility {
        Random r = new Random();

        public string[] Prefixes = new string[] {
            "proto",
            "re",
            "un",
        };

        public string[] Suffixes = new string[] {
            "berg",
            "burg",
            "field",
            "ton",
            "ville"
        };

        public string[] Titles = new string[] {
            "The Kingdom Of",
            "The Prefecture Of",
            "The Most Holy"
        };

        public string[] Post = new string[] {
            "Prime",
            "Alpha",
            "Beta",
            "Gamma",
            "Nation",
            "Planet",
            "Inc.",
            "LLC",
        };

        public string[] Vowels = new string[] {
            "a", "e", "i", "o", "u"
        };

        public string[] Consonants = new string[] {
            "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "n", "p",
            "q", "r", "s", "t", "v", "w", "x", "y", "z"
        };

        public string GenerateRoot() {
            var numpairs = r.Next(4) + 1;
            var str = "";

            for (int i = 0; i < numpairs; i++) {
                str += Consonants[r.Next(Consonants.Length)];
                str += Vowels[r.Next(Vowels.Length)];
            }

            return str;
        }

        public override string GetPossibility(Random r) {
            var name = "";

            if ((r.Next(2) + 1) % 2 == 0) {
                name += Titles[r.Next(Titles.Length)] + " ";
            }

            if ((r.Next(2) + 1) % 2 == 0) {
                name += Prefixes[r.Next(Prefixes.Length)];
            }

            name += GenerateRoot();

            if ((r.Next(2) + 1) % 2 == 0) {
                name += Suffixes[r.Next(Suffixes.Length)] + " ";
            } else {
                name += " ";
            }

            if ((r.Next(2) + 1) % 2 == 0) {
                name += Post[r.Next(Post.Length)];
            }

            return ToTitleCase(name);
        }

        public string GetNPCName() => ToTitleCase(GenerateRoot() + " " + GenerateRoot());

        public string ToTitleCase(string tofix) {
            var pieces = tofix.Split(' ');

            for (int i = 0; i < pieces.Length; i++) { 
                if (string.IsNullOrEmpty(pieces[i])) {
                    continue;
                }

                pieces[i] = pieces[i][0].ToString().ToUpper() + pieces[i].Substring(1);
            }

            return string.Join(" ", pieces);
        }
    }
}
