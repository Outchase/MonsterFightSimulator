using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
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
            ASCIISIGN sign = new();
            Monster[] playerTurn = new Monster[2];
            int rounds = 0;
            bool fightOver = false;
            string tmpMessage;
            bool confirmMonsterSetStats = false;
            player1.printColor = ConsoleColor.Red;
            player2.printColor = ConsoleColor.Cyan;


            PrintInColor(sign.title + "\n" + "Press Enter to Start\n", ConsoleColor.Yellow, true);
            OnPressContinue(true);


            while (player1.race[player1.raceValue] == player2.race[player2.raceValue])
            {
                bool confirmMonsterChoice = false;
                while (!confirmMonsterChoice)
                {
                    ShowListOfMonsters(player1);

                    string message = "To simulate a combat, choose a Monster: ";

                    VerifySelectedMonster(false, message, player1);

                    message = "Choose a second Monster: ";

                    VerifySelectedMonster(false, message, player2);

                    if (player1.race[player1.raceValue] == player2.race[player2.raceValue])
                    {
                        Console.Clear();
                        PrintInColor("It is not allow monsters of the same race to fight one other\n", ConsoleColor.Red, true);
                    }

                    PrintInColor("\nAre you sure with this choice? [Y/n]\n", ConsoleColor.Green, true);
                    confirmMonsterChoice = OnPressYesOrNo(true);

                }
            }

            while (!confirmMonsterSetStats)
            {
                SetMonsterStats(player1);
                Console.WriteLine();
                ShowMonsterStats(player1);
                PrintInColor("Are you sure with these stats? [Y/n]\n", ConsoleColor.Green, true);
                confirmMonsterSetStats = OnPressYesOrNo(true);
            }

            confirmMonsterSetStats = false;

            while (!confirmMonsterSetStats)
            {
                SetMonsterStats(player2);
                Console.WriteLine();
                ShowMonsterStats(player2);
                PrintInColor("Are you sure with these stats? [Y/n]\n", ConsoleColor.Green, true);
                confirmMonsterSetStats = OnPressYesOrNo(true);
            }

            PrintInColor(player1.race[player1.raceValue] + " vs. " + player2.race[player2.raceValue] + "\n", ConsoleColor.Green, true);

            if (player1.stats["S"] == player2.stats["S"])
            {
                Console.Write("Lets flip a coin...   ");
                PrintInColor("(Press enter to continue)\n", ConsoleColor.Yellow, true);
                OnPressContinue(false);

                //Console.ReadKey(true); // replace confirm choice funtion

                bool canPlayer2Start = FlipCoin(random);

                if (canPlayer2Start)
                {
                    PrintInColor(player2.race[player2.raceValue], player2.printColor, true);
                    playerTurn[0] = player2;
                    playerTurn[1] = player1;
                }
                else
                {
                    PrintInColor(player1.race[player1.raceValue], player1.printColor, true);
                    playerTurn[0] = player1;
                    playerTurn[1] = player2;
                }

            }
            else if (player1.stats["S"] > player2.stats["S"])
            {
                PrintInColor(player1.race[player1.raceValue], player1.printColor, true);
                playerTurn[0] = player1;
                playerTurn[1] = player2;
            }
            else
            {
                PrintInColor(player2.race[player2.raceValue], player2.printColor, true);
                playerTurn[0] = player2;
                playerTurn[1] = player1;
            }
            Console.WriteLine(" starts first!\n");

            while (!fightOver)
            {
                PrintInColor("\nPress enter to continue...", ConsoleColor.Yellow, true);
                OnPressContinue(true);

                PrintInColor("Round " + (rounds+1) + "\n", ConsoleColor.Yellow, true);

                for (int i = 0; i < playerTurn.Length; i++)
                {

                    if (player1.stats["HP"] == 0 || player2.stats["HP"] == 0)
                    {
                        fightOver = true;
                        break;
                    }

                    if (i == 0)
                    {
                        playerTurn[i].Attack(playerTurn[i + 1]);
                    }
                    else
                    {
                        playerTurn[i].Attack(playerTurn[i - 1]);

                    }

                    if (player1.stats["HP"] == 0 || player2.stats["HP"] == 0)
                    {
                        fightOver = true;
                        break;
                    }
                }

                rounds++;
            }

            Console.WriteLine("battle over...\n");
            PrintInColor("Press enter to continue...", ConsoleColor.Yellow, true);
            OnPressContinue(true);

            if (player1.stats["HP"] == 0)
            {
                PrintInColor(player1.race[player1.raceValue], player1.printColor, true);
                Console.WriteLine(" got deafeated!");

                PrintInColor(player2.race[player2.raceValue], player2.printColor, true);
                Console.WriteLine(" won the fight!");
            }
            else
            {
                Console.WriteLine(player2.race[player2.raceValue] + " got deafeated!");
                Console.WriteLine(player1.race[player1.raceValue] + " won the fight!");
            }

            Console.Write("\nThe battle lasted ");


            if (rounds > 1)
            {
                tmpMessage = " rounds";
            }
            else
            {
                tmpMessage = " round";
            }
            PrintInColor(rounds + tmpMessage +"\n", ConsoleColor.Yellow, true);


            PrintInColor("\nDo you want to try again? [Y/n]\n", ConsoleColor.Green, true);
            return OnPressYesOrNo(true);
        }

        //Display stats of given monster as parameter
        public static void ShowMonsterStats(Monster monster)
        {
            PrintInColor(monster.race[monster.raceValue], ConsoleColor.Yellow, true);

            Console.WriteLine();

            foreach (KeyValuePair<string, float> kvp in monster.stats)
            {
                PrintInColor(kvp.Key + ": ", ConsoleColor.Cyan, true);

                Console.WriteLine(kvp.Value);
            }

            Console.WriteLine();
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
                PrintInColor(message, ConsoleColor.Green, false);
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
                Console.ResetColor();
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

        public static void PrintInColor(string message, ConsoleColor color, bool resetColor)
        {
            Console.ForegroundColor = color;
            Console.Write(message);
            if (resetColor)
            {
                Console.ResetColor();
            }
        }

        public static bool FlipCoin(Random random)
        {
            int coinFlipvalue = random.Next(1, 21);

            if (coinFlipvalue > 10)
            {
                return true;
            }
            else
            {
                return false;
            }


        }

        public static void OnPressContinue(bool clearConsole)
        {
            ConsoleKeyInfo userKeyInput;
            bool keyPressedRight = false;

            while (!keyPressedRight)
            {

                userKeyInput = Console.ReadKey(true);

                if (userKeyInput.Key == ConsoleKey.Enter)
                {
                    keyPressedRight = true;
                }
            }

            if (clearConsole)
            {
                Console.Clear();
            }
        }

        public static bool OnPressYesOrNo(bool clearConsole)
        {
            ConsoleKeyInfo userKeyInput;
            bool keyPressedRight = false;
            bool isAYes = false;

            while (!keyPressedRight)
            {

                userKeyInput = Console.ReadKey(true);

                if (userKeyInput.Key == ConsoleKey.Y)
                {
                    keyPressedRight = true;
                    isAYes = true;
                }
                else if (userKeyInput.Key == ConsoleKey.N)
                {
                    keyPressedRight = true;
                }
            }
            if (clearConsole)
            {
                Console.Clear();
            }
            return isAYes;

        }
    }
}

