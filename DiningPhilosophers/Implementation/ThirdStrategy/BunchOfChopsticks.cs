using DiningPhilosophers.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace DiningPhilosophers.Implementation.ThirdStrategy
{
    public  class BunchOfChopsticks
    {
        private List<(string name, bool isTaken)> _chopsticks = new List<(string name, bool isTaken)>();

        public void Init(int numberOfChopsticks)
        {
            Enumerable.Range(0, numberOfChopsticks).ToList().ForEach(index => {
                _chopsticks.Add((string.Format(Constants.Chopstick, index + 1), false));
            });
        }
        public void Get(ref int chopstick1, ref int chopstick2, string philosopherName)
        {
            lock (this)
            {
                var watch = System.Diagnostics.Stopwatch.StartNew();

                while (!_chopsticks.Any(u => !u.isTaken)) Monitor.Wait(this);
                chopstick1 = _chopsticks.IndexOf(_chopsticks.First(u => !u.isTaken));
                _chopsticks[chopstick1] = (_chopsticks[chopstick1].name, true);

                while (!_chopsticks.Any(u => !u.isTaken)) Monitor.Wait(this);
                chopstick2 = _chopsticks.IndexOf(_chopsticks.First(u => !u.isTaken));
                _chopsticks[chopstick2] = (_chopsticks[chopstick2].name, true);

                watch.Stop();
                Console.WriteLine(StringsForThirdStrategy.PickUpChopstick,philosopherName,_chopsticks[chopstick1].name,_chopsticks[chopstick2].name, watch.Elapsed.Seconds);

            }

        }
        public void Put(int left, int right, string philosopherName)
        {
            lock (this)
            {
                Console.WriteLine(StringsForThirdStrategy.PutDownChopstick,philosopherName,_chopsticks[left].name,_chopsticks[right].name);
                _chopsticks[left] = (_chopsticks[left].name, false);
                _chopsticks[right] = (_chopsticks[right].name, false);
                Monitor.PulseAll(this);
            }
        }
    }
}
