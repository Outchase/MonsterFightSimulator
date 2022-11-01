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
            Random random = new();
            object[] playerTurn = new object[2];

            // bool fightOver = false;

            Console.WriteLine("start game");

            while (player1.race[player1.raceValue] == player2.race[player2.raceValue])
            {
                ShowListOfMonsters(player1);

                string message = "To simulate a combat, choose a Monster: ";

                VerifySelectedMonster(false, message, player1);

                message = "Choose a second Monster: ";

                VerifySelectedMonster(false, message, player2);

                if (player1.race[player1.raceValue] == player2.race[player2.raceValue])
                {
                    Console.Clear();
                    Console.WriteLine("It is not allow monsters of the same race to fight one other"); //Print it red
                }
            }

            SetMonsterStats(player1);

            ShowMonsterStats(player1);

            SetMonsterStats(player2);

            ShowMonsterStats(player2);




            Console.WriteLine(player1.race[player1.raceValue] + " vs. " + player2.race[player2.raceValue]);

            //Console.WriteLine(player2.stats["S"]);

            if (player1.stats["S"] == player2.stats["S"])
            {
                Console.WriteLine("Lets flip a coin");

                int coinFlipvalue = random.Next(1, 21);

                //Console.WriteLine(coinFlipvalue); //debugging

                if (coinFlipvalue > 10)
                {
                    Console.WriteLine(player2.race[player2.raceValue] + " starts first");
                    playerTurn[0] = player2;
                    playerTurn[1] = player1;
                }
                else
                {
                    Console.WriteLine(player1.race[player1.raceValue] + " starts first");
                    playerTurn[0] = player1;
                    playerTurn[1] = player2;
                }

            }
            else if (player1.stats["S"] > player2.stats["S"])
            {
                Console.WriteLine(player1.race[player1.raceValue] + " starts first");
                playerTurn[0] = player1;
                playerTurn[1] = player2;

            }
            else
            {
                Console.WriteLine(player2.race[player2.raceValue] + " starts first");
                playerTurn[0] = player2;
                playerTurn[1] = player1;
            }

            Console.WriteLine(playerTurn[1]);


            /* for (int i = 0; i < playerTurn.Length; i++)
             {
                 Console.WriteLine(playerTurn[i]);
             }*/
            /*while (!fightOver)
            {

            }*/
            //player1.stats["HP"] = 20;

            //ShowMonsterStats(player1, true);


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

        public static void VerifySelectedMonster(bool isNumber, string message, Monster monster)
        {
            int numericValue = 0;
            //int numberOfTries = 0; set random after too many tries
            while (!isNumber)
            {
                Console.Write(message);
                string userInput = Console.ReadLine();
                if (int.TryParse(userInput, out numericValue) && numericValue > 0 && numericValue <= monster.race.Length)
                {
                    isNumber = true;
                    numericValue--;
                }
                /* else
                 {
                     numberOfTries++;
                 }*/
            }
            monster.raceValue = numericValue;
        }

        public static void SetMonsterStats(Monster monster)
        {
            foreach (KeyValuePair<string, float> kvp in monster.stats)
            {
                bool isNumber = false;

                while (!isNumber)
                {
                    Console.Write("Set " + kvp.Key + " value of " + monster.race[monster.raceValue] + ": ");

                    string userInput = Console.ReadLine();
                    if (float.TryParse(userInput, out float numericValue))
                    {
                        monster.stats[kvp.Key] = numericValue;

                    }
                    else
                    {
                        monster.stats[kvp.Key] = 0;
                    }
                    isNumber = true;
                }
            }
        }


    }
}

