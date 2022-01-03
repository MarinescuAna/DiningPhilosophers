using DinningPhilosophersConsoleApp.Strategies.Strategy1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace DinningPhilosophersConsoleApp
{
    class Table
    {
        internal static Chopstick Platinum = new Chopstick() { ForkID = "Platinum Fork", State = ForkState.OnTheTable };
        internal static Chopstick Gold = new Chopstick() { ForkID = "Gold Fork", State = ForkState.OnTheTable };
        internal static Chopstick Silver = new Chopstick() { ForkID = "Silver Fork", State = ForkState.OnTheTable };
        internal static Chopstick Wood = new Chopstick() { ForkID = "Wood Fork", State = ForkState.OnTheTable };
        internal static Chopstick Plastic = new Chopstick() { ForkID = "Plastic Fork", State = ForkState.OnTheTable };
    }
    class Program
    {
        static void Main(string[] args)
        {
            var max = 5;
            var philosophers = new List<Philosopher>();
            var chopsticks = new Dictionary<Chopstick,bool>();
            var threads = new List<Thread>();

            Enumerable.Range(0, 5).ToList().ForEach(index =>
            {
                chopsticks.Add(new Chopstick { ForkID =$"Chopstick {index}"},false);
            });
            var all = new AllChopsticks(chopsticks);

            Enumerable.Range(0, 5).ToList().ForEach(index =>
            {
                philosophers.Add(new Philosopher(all, $"Philosopher {index}", max));
            });

            Enumerable.Range(0, 5).ToList().ForEach(index =>
            {
                var thread = new Thread(philosophers[index].run);
                threads.Add(thread);
                thread.Start();
            });

            Console.ReadKey();
        }
    }
}
