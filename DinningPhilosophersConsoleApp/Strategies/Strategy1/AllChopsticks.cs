using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace DinningPhilosophersConsoleApp.Strategies.Strategy1
{
    class AllChopsticks
    {
        private Dictionary<Chopstick, bool> _chopsticks = new Dictionary<Chopstick, bool>();
        private Semaphore semaphore = new Semaphore(1, 1);
        public AllChopsticks(Dictionary<Chopstick, bool> chopsticks)
        {
            _chopsticks = chopsticks;
        }

        public Chopstick GetChopstick()
        {
            semaphore.WaitOne();

            while (!_chopsticks.Any(u => !u.Value))
            {
                Thread.Sleep(new Random().Next(100, 1500));
            }

            var freeChopstick = _chopsticks.First(u => !u.Value);
            _chopsticks[freeChopstick.Key] = true;

            semaphore.Release();
            return freeChopstick.Key;
        }

        public void PutChopstickOnTheTable(Chopstick chopstick)
        {
            semaphore.WaitOne();

            _chopsticks[chopstick] = false;

            semaphore.Release();
        }
    }
}
