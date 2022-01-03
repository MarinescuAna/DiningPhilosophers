using DiningPhilosophers.Common;
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
            Name = string.Format(Constants.Philosopher, index);
        }

        public bool Eat()
        {
            if (Chopsticks.Count() == 2)
            {
                Console.WriteLine(StringConstants.PhilosopherIsEating, Name, Chopsticks[0].Name, Chopsticks[1].Name);

                Thread.Sleep(new Random().Next(2000, 2500));

                Console.WriteLine(StringConstants.PhilosopherIsBackToThinking, Name);

                return true;
            }

            return false;
        }
    }
}
