using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterKampfSimulator
{
    internal class Features
    {
        readonly Random random = new();

        //Display stats of given monster as parameter //add to diffrent class
        public void ShowMonsterStats(Monster monster)
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

        //add to diffrent class
        public void PrintInColor(string message, ConsoleColor color, bool resetColor)
        {
            Console.ForegroundColor = color;
            Console.Write(message);
            if (resetColor)
            {
                Console.ResetColor();
            }
        }

        //add to diffrent class
        public bool FlipCoin(bool isPlayerTurn)
        {
            int coinFlipvalue = random.Next(1, 21);
            bool tmpReturnValue = false;


            if (isPlayerTurn)
            {
                if (coinFlipvalue > 10)
                {
                    tmpReturnValue = true;
                }
                
            }
            else
            {
                int randomPlayerGuess = random.Next(1, 21);
                if (randomPlayerGuess == coinFlipvalue)
                {
                    tmpReturnValue = true;
                }
            }

            return tmpReturnValue;
        }

    }
}
