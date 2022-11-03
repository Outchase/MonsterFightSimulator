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
        public ConsoleColor printColor = 0;

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

        public void Attack(Monster monster, Features feature)
        {

            feature.PrintInColor(race[raceValue], printColor, true);
            Console.Write(" attacks ");
            feature.PrintInColor(monster.race[monster.raceValue], monster.printColor, true);
            Console.WriteLine(" with " + stats["AP"] + " AP!");

            //flipcoin high crit chance
            bool isCritHit = feature.FlipCoin(false);
            float damage = stats["AP"] - monster.stats["DP"];
            Console.ReadKey(true);

            if (isCritHit)
            {
                damage *= 2f;
                feature.PrintInColor("Critical hit!\n", ConsoleColor.Yellow, true);
                Console.ReadKey(true);
            }

            //flip coin to perfect dodge
            bool didDodged = feature.FlipCoin(false);
            if (didDodged)
            {
                damage = 0;
                feature.PrintInColor(monster.race[monster.raceValue] + " dodged!\n", ConsoleColor.Yellow, true);
                Console.ReadKey(true);
            }

            feature.PrintInColor(monster.race[monster.raceValue], monster.printColor, true);
            Console.WriteLine(" takes -" + damage + " damage");
            monster.stats["HP"] -= damage;
            Console.ReadKey(true);

            if (monster.stats["HP"] < 0)
            {
                monster.stats["HP"] = 0;
            }
            feature.PrintInColor(monster.race[monster.raceValue], monster.printColor, true);
            Console.WriteLine(" has " + monster.stats["HP"] + " HP left");
            Console.WriteLine();
            Console.ReadKey(true);
        }
    }
}
