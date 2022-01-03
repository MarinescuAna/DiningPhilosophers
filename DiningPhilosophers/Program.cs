using DiningPhilosophers.Abstraction;
using DiningPhilosophers.Implementation.FirstStrategy;
using DiningPhilosophers.Implementation.SecondStrategy;
using System;

namespace DiningPhilosophers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press: \n1 -> [strategy 1] \n2 -> [strategy 2] \n3 -> [strategy 3]");
            var readed = Console.ReadLine();
            var philosophersNumber = 0;

            switch (readed)
            {
                case "1":
                    Console.WriteLine("\n_______________________\nWrite the number of philosophers:");
                    philosophersNumber = int.Parse(Console.ReadLine());

                    Console.WriteLine("\nWrite the number of uses:");
                    var numberOfUses = int.Parse(Console.ReadLine());

                    new FirstStrategy(philosophersNumber, numberOfUses).Main();
                    break;
                case "2":
                    Console.WriteLine("\n_______________________\nWrite the number of philosophers:");
                    philosophersNumber = int.Parse(Console.ReadLine());

                    Console.WriteLine("\nWrite the number of eating times:");
                    var eatingTimes = int.Parse(Console.ReadLine());

                    new SecondStrategy(philosophersNumber, eatingTimes).Main();
                    break;
                case "3":
                    Console.WriteLine("\n_______________________\nWrite the number of philosophers:");
                    philosophersNumber = int.Parse(Console.ReadLine());

                    Console.WriteLine("\nWrite the number of thinking times:");
                    var thinkingTimes = int.Parse(Console.ReadLine());

                    new SecondStrategy(philosophersNumber, thinkingTimes).Main();
                    break;
            }

        }
    }
}
