using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterKampfSimulator
{

    internal class Monster
    {

        public Dictionary<string, float> stats = new() {
            {"HP", 0},
            {"AP", 0},
            {"DP", 0},
            {"S", 0}
        };

        public int raceValue = 0;

         public string[] race = {
            "Orc",
            "Troll",
            "Goblin",
            "Gremlins",
            "Oni",
            "Bahamut",
            "Fey",
            "Centaur"
        };

        public void Attack()
        {
            Console.WriteLine("attack");
        }
    }
}
