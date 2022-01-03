using DiningPhilosophers.Abstraction;
using DiningPhilosophers.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace DiningPhilosophers.Implementation.FirstStrategy
{
    public class FirstStrategy: Strategy
    {
        private int _numberOfUses;
        private List<Philosopher> _philosophers = new List<Philosopher>();
        private List<Chopstick> _chopsticks = new List<Chopstick>();
        private List<Thread> _chopsticksThreads = new List<Thread>();
        public FirstStrategy(int max, int numberOfUses) : base(max)
                => _numberOfUses = numberOfUses;
               
        
        public override void Main()
        {
            Init();

            Console.WriteLine(Constants.DinnerIsStart);

            Enumerable.Range(0, _max).ToList().ForEach(index =>
            {
                var thread = new Thread(new ThreadStart(_chopsticks[index].Run));
                _chopsticksThreads.Add(thread);
                thread.Start();
            });

            Enumerable.Range(0, _max).ToList().ForEach(index =>
            {
                _chopsticksThreads[index].Join();
            });

            Console.WriteLine(Constants.DinnerIsOver);
        }
        private void Init()
        {
            Enumerable.Range(0, _max).ToList().ForEach(index => _philosophers.Add(new Philosopher(index)));
            Enumerable.Range(0, _max).ToList().ForEach(
                index => _chopsticks.Add(
                    new Chopstick(
                        index,
                        index == 0 ? _philosophers[_max - 1] : _philosophers[index - 1],
                        index == _max - 1 ? _philosophers[0] : _philosophers[index + 1],
                        _numberOfUses
                        )));
        }
    }
}
