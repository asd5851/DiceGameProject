using System;
namespace DiceAdventure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            View view = new View();
            //start point x=5
            //pixed point y=5

            //int opening_count = 10;
            view.BlingStartView();
            Console.Clear();

            view.RollDiceOne(110, 10);
            Console.ReadLine();

            view.RollDiceThree(110, 10);
            Console.ReadLine();

            view.RollDiceSix(110, 10);
            Console.ReadLine();
            view.ShowMap(11,18,110);

        }
    }
}