using DiningPhilosophers.Abstraction;
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
        public FirstStrategy(int max, int numberOfUses) : base(max)
                => _numberOfUses = numberOfUses;
               
        
        public override void Main()
        {
            var philosophers = new List<Philosopher>();
            var chopsticks = new List<Chopstick>();

            Enumerable.Range(0, _max).ToList().ForEach(index => philosophers.Add(new Philosopher(index)));
            Enumerable.Range(0, _max).ToList().ForEach(
                index => chopsticks.Add(
                    new Chopstick(
                        index,
                        index == 0 ? philosophers[_max - 1] : philosophers[index - 1],
                        index == _max - 1 ? philosophers[0] : philosophers[index + 1],
                        _numberOfUses
                        )));

            var chopsticksThreads = new List<Thread>();

            Console.WriteLine("Dinner is start!");

            Enumerable.Range(0, _max).ToList().ForEach(index =>
            {
                var thread = new Thread(new ThreadStart(chopsticks[index].Run));
                chopsticksThreads.Add(thread);
                thread.Start();
            });


            Enumerable.Range(0, _max).ToList().ForEach(index =>
            {
                chopsticksThreads[index].Join();
            });

            Console.WriteLine("Dinner is over!");
        }
    }
}
