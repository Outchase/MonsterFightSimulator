using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MonsterKampfSimulator.Properties;




namespace MonsterKampfSimulator
{
    internal class GameManager
    {

        public static bool StartGame()
        {
            Monster player1 = new();
            Monster player2 = new();

            Console.WriteLine("start game");

            while () { 
            
            }

            ShowListOfMonsters(player1);

            string message = "To simulate a combat, choose a Monster: ";

            player1.raceValue = VerifySelectedMonster(false, message, player1);

            message = "Choose a second Monster: ";

            player2.raceValue = VerifySelectedMonster(false, message, player2);

            Console.WriteLine(player1.race[player1.raceValue] + " vs. " + player2.race[player2.raceValue]);



            player1.stats["HP"] = 20;

            ShowMonsterStats(player1);


            return true;
        }

        //Display stats of given monster as parameter
        public static void ShowMonsterStats(Monster monster)
        {
            Console.WriteLine(monster.race[monster.raceValue]);

            foreach (KeyValuePair<string, float> kvp in monster.stats)
            {
                Console.WriteLine(kvp.Key + " " + kvp.Value);
            }
        }

        //Display list of monsters
        public static void ShowListOfMonsters(Monster monster)
        {

            for (int i = 0; i < monster.race.Length; i++)
            {
                Console.WriteLine(i + 1 + "." + monster.race[i]);
            }
        }

        public static int VerifySelectedMonster(bool isNumber, string message, Monster monster)
        {
            int numericValue = 0;
            //int numberOfTries = 0; set random after too many tries
            while (!isNumber)
            {
                Console.Write(message);
                string userInput = Console.ReadLine();
                if (int.TryParse(userInput, out numericValue) && numericValue > 0 &&  numericValue <= monster.race.Length)
                {
                    isNumber = true;
                    numericValue--;
                }
                /* else
                 {
                     numberOfTries++;
                 }*/
            }
            return numericValue;

        }

        public static void SetMonsterStats(Monster monster)
        {

        }
    }
}
