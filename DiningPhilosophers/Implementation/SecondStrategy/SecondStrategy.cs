using DiningPhilosophers.Abstraction;
using DiningPhilosophers.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace DiningPhilosophers.Implementation.SecondStrategy
{
    public class SecondStrategy : Strategy
    {
        private int _maxEatingTimes;
        public SecondStrategy(int max, int maxEatingTimes) : base(max) => _maxEatingTimes = maxEatingTimes;
        public override void Main()
        {
            var philosophers = new List<Philosopher>(_max);

            Enumerable.Range(0, _max).ToList().ForEach(i => {
                philosophers.Add(new Philosopher(philosophers, i, _maxEatingTimes));
            });
            
            philosophers.ForEach(philosopher => {
                philosopher.LeftChopstick = philosopher.LeftPhilosopher.RightChopstick ?? new Chopstick();
                philosopher.RightChopstick = philosopher.RightPhilosopher.LeftChopstick ?? new Chopstick();
            });

            var philosopherThreads = new List<Thread>();
            foreach (var philosopher in philosophers)
            {
                var philosopherThread = new Thread(new ThreadStart(philosopher.EatAll));
                philosopherThreads.Add(philosopherThread);
                philosopherThread.Start();
            }

            philosopherThreads.ForEach(thread => {
                thread.Join();
            });
        }
    }
}
