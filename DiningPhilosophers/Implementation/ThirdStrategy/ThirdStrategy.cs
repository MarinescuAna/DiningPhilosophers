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
        private int _maxThinkingTimes;
        public ThirdStrategy(int max, int maxThinkingTimes) : base(max) => _maxThinkingTimes = maxThinkingTimes;
        public override void Main()
        {
            var philosophers = new List<Philosopher>(_max);
            var chopsticks = new List<Chopstick>(_max);

            Enumerable.Range(1, _max).ToList().ForEach(index =>
            {
                chopsticks.Add(new Chopstick(index));
            });
            Enumerable.Range(1, _max).ToList().ForEach(index =>
            {
                philosophers.Add(new Philosopher(chopsticks[index==0?_max-1:index-1],chopsticks[index==_max-1?0:index+1],index, _maxThinkingTimes));
            });

            // Start dinner
            Console.WriteLine(Constants.DinnerIsStart);

            // Spawn threads for each philosopher's eating cycle
            var philosopherThreads = new List<Thread>();
            foreach (var philosopher in philosophers)
            {
                var philosopherThread = new Thread(new ThreadStart(philosopher.Eat));
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
