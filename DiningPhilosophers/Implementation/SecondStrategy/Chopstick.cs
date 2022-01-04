using DiningPhilosophers.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiningPhilosophers.Implementation.SecondStrategy
{
    public class Chopstick
    {
        private static int _count = 1;
        public string Name { get; private set; }

        public Chopstick()
        {
            Name = string.Format(Constants.Chopstick,_count++);
        }
    }
}
