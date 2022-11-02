using System;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;


namespace MonsterKampfSimulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool wantToPlayAgain = false;

            while (!wantToPlayAgain)
            {
                wantToPlayAgain = GameManager.StartGame();
            }

            Console.WriteLine("Thanks for Playing!");
            Environment.Exit(0);
        }
    }
}
