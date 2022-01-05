using DiningPhilosophers.Abstraction;
using DiningPhilosophers.Common;
using DiningPhilosophers.Implementation.FirstStrategy;
using DiningPhilosophers.Implementation.SecondStrategy;
using DiningPhilosophers.Implementation.ThirdStrategy;
using System;

namespace DiningPhilosophers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Constants.MenuOptions);
            var readed = Console.ReadLine();
            var philosophersNumber = 0;

            switch (readed)
            {
                case "1":
                    Console.WriteLine(Constants.NumberOfPhilosophers);
                    philosophersNumber = int.Parse(Console.ReadLine());

                    Console.WriteLine(Constants.NumberOfUses);
                    var numberOfUses = int.Parse(Console.ReadLine());

                    Console.WriteLine(Constants.WaitingTime);
                    var waitingTime = int.Parse(Console.ReadLine());

                    new FirstStrategy(philosophersNumber, numberOfUses,waitingTime).Main();
                    break;
                case "2":
                    Console.WriteLine(Constants.NumberOfPhilosophers);
                    philosophersNumber = int.Parse(Console.ReadLine());

                    Console.WriteLine(Constants.NumberOfEatingTimes);
                    var eatingTimes = int.Parse(Console.ReadLine());

                    new SecondStrategy(philosophersNumber, eatingTimes).Main();
                    break;
                case "3":
                    Console.WriteLine(Constants.NumberOfPhilosophers);
                    philosophersNumber = int.Parse(Console.ReadLine());

                    Console.WriteLine(Constants.NumberOfEatingTimes);
                    var eatTimes = int.Parse(Console.ReadLine());

                    new ThirdStrategy(philosophersNumber, eatTimes).Main();
                    break;
            }

        }
    }
}
