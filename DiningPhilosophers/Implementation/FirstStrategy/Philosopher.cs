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
        private bool _isEating = false;

        public Philosopher(int index)
        {
            Name = string.Format(Constants.Philosopher, index);
        }

        public bool EatAndThink()
        {
            if (Chopsticks.Count() == 2)
            {
                if (!_isEating)
                {
                    _isEating = true;
                    Console.WriteLine(StringsForFirstStrategy.PhilosopherIsEating, Name, Chopsticks[0].Name, Chopsticks[1].Name);

                    Thread.Sleep(WaitingTime.WaitingTimeProperty);

                    Console.WriteLine(StringsForFirstStrategy.PhilosopherIsBackToThinking, Name);

                    Thread.Sleep(WaitingTime.WaitingTimeProperty);
                }

                return true;
            }

            _isEating = false;
            return false;
        }
    }

}
