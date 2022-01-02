using DiningPhilosophers.Abstraction;
using DiningPhilosophers.Common;
using System;
using System.Collections.Generic;
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
            for (int i = 0; i < _max; i++)
            {
                philosophers.Add(new Philosopher(i,_maxEatingTimes));
            }

            // Start dinner
            Console.WriteLine(Constants.DinnerIsStart);

            // Spawn threads for each philosopher's eating cycle
            var philosopherThreads = new List<Thread>();
            foreach (var philosopher in philosophers)
            {
                var philosopherThread = new Thread(new ThreadStart(philosopher.EatAll));
                philosopherThreads.Add(philosopherThread);
                philosopherThread.Start();
            }

            // Wait for all philosopher's to finish eating
            foreach (var thread in philosopherThreads)
            {
                thread.Join();
            }

            // Done
            Console.WriteLine(Constants.DinnerIsOver);
        }
    }
}
