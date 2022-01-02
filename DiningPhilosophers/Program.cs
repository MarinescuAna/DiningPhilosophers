using DiningPhilosophers.Abstraction;
using DiningPhilosophers.Implementation.FirstStrategy;
using System;

namespace DiningPhilosophers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("~~~~~Hello World!~~~~~~~~~");
            var continueToRun = true;
            var readed = string.Empty;
            while (continueToRun)
            {
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine("Press: \n1 -> [strategy 1] \n0 -> [exit] ");
                readed = Console.ReadLine();
                switch (readed)
                {
                    case "1":
                        Console.WriteLine("\n_______________________\nWrite the number of philosophers:");
                        var philosophersNumber = int.Parse(Console.ReadLine());

                        Console.WriteLine("\nWrite the number of uses:");
                        var numberOfUses = int.Parse(Console.ReadLine());
                        
                        new FirstStrategy(philosophersNumber,numberOfUses).Main();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
