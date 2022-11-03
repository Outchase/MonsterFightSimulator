using System;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;


namespace MonsterKampfSimulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool wantToPlayAgain = true;
            ASCIISIGN sign = new();

            while (wantToPlayAgain)
            {
                wantToPlayAgain = GameManager.StartGame();
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(sign.outro);
            Console.ResetColor();

            Environment.Exit(0);
        }
    }
}
