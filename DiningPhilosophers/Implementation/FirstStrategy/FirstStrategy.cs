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
        private int _waitingTime;
        private List<Philosopher> _philosophers = new List<Philosopher>();
        private List<Chopstick> _chopsticks = new List<Chopstick>();
        private List<Thread> _chopsticksThreads = new List<Thread>();
        public FirstStrategy(int max, int numberOfUses, int waitingTime) : base(max)
        {
            _numberOfUses = numberOfUses;
            _waitingTime = waitingTime;
        }
        public override void Main()
        {
            Init();

            Enumerable.Range(0, _max).ToList().ForEach(index =>
            {
                var thread = new Thread(new ThreadStart(_chopsticks[index].Run));
                _chopsticksThreads.Add(thread);
                thread.Start();
            });
        }
        private void Init()
        {
            Enumerable.Range(0, _max).ToList().ForEach(index => _philosophers.Add(new Philosopher(index)));
            Enumerable.Range(0, _max).ToList().ForEach(
                index => _chopsticks.Add(
                    new Chopstick(
                        index,
                        _philosophers[index],
                        index == _max - 1 ? _philosophers[0] : _philosophers[index + 1],
                        _numberOfUses,
                        _waitingTime
                        )));
        }
    }
}
