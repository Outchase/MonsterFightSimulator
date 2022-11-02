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

        public void Attack(Monster monster)
        {

            Console.WriteLine(race[raceValue] + " attacks " + monster.race[monster.raceValue] + " with " + stats["AP"] + " AP!");
            float damage = stats["AP"] - monster.stats["DP"];
            Console.ReadKey(true);

            Console.WriteLine(monster.race[monster.raceValue] + " recieve -" + damage + " damage");
            monster.stats["HP"] -= damage;
            Console.ReadKey(true);

            if (monster.stats["HP"] < 0)
            {
                monster.stats["HP"] = 0;
            }
            Console.WriteLine(monster.race[monster.raceValue] + " HP = " + monster.stats["HP"]);
            Console.ReadKey(true);
        }
    }
}
