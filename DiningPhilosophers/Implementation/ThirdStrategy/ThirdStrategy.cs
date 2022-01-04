using DiningPhilosophers.Abstraction;
using DiningPhilosophers.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace DiningPhilosophers.Implementation.ThirdStrategy
{
    public class ThirdStrategy : Strategy
    {
        private int _maxEatingTimes;
        public ThirdStrategy(int max, int maxEatTimes) : base(max) => _maxEatingTimes = maxEatTimes;
        public override void Main()
        {
            var chopsticks = new BunchOfChopsticks();
            chopsticks.Init(_maxEatingTimes);

            Enumerable.Range(0, _max).ToList().ForEach(index => {
                new Philosopher(index+1, chopsticks, _maxEatingTimes);
            });
        }
        
    }
}
