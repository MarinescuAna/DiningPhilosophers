using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace DiningPhilosophers.Implementation.FirstStrategy
{
    public class Philosopher
    {
        public List<Chopstick> Chopsticks = new List<Chopstick>(2);
        public string Name { get; private set; }
        public Philosopher(int index)
        {
            Name = $"Philosopher {index}";
        }

        public bool Eat()
        {
            if (Chopsticks.Count() == 2)
            {
                Console.WriteLine($"{Name} is eating with {Chopsticks[0].Name} and {Chopsticks[1].Name}.");

                Thread.Sleep(2000);

                Console.WriteLine($"{Name} is back to thinking.");

                return true;
            }

            return false;
        }
    }
}
