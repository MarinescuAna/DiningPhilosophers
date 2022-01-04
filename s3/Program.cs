using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace s3
{
    class BunchOfChopsticks
    {
        private List<(string Name,bool fork)> _chopsticks= new List<(string Name, bool fork)>();

        public void Init(int numberOfChopsticks)
        {
            Enumerable.Range(0, numberOfChopsticks).ToList().ForEach(index => {
                _chopsticks.Add(($"Chopstick {index}", false));
            });
        }
        public void Get(ref int fork1, ref int fork2, string philosopherName)
        {
            lock (this)
            {
                while (!_chopsticks.Any(u => !u.fork)) Monitor.Wait(this);
                fork1 = _chopsticks.IndexOf(_chopsticks.First(u => !u.fork));
                _chopsticks[fork1] = (_chopsticks[fork1].Name, true);

                while (!_chopsticks.Any(u => !u.fork)) Monitor.Wait(this);
                fork2 = _chopsticks.IndexOf(_chopsticks.First(u => !u.fork));
                _chopsticks[fork2] = (_chopsticks[fork2].Name, true);

                Console.WriteLine($"{philosopherName} get forks {_chopsticks[fork1].Name} and {_chopsticks[fork2].Name}.");

            }

        }
        public void Put(int left, int right, string philosopherName)
        {
            lock (this)
            {
                Console.WriteLine($"{philosopherName} put down floks {_chopsticks[left].Name} and {_chopsticks[right].Name}.");
                _chopsticks[left] = (_chopsticks[left].Name,false);
                _chopsticks[right] = (_chopsticks[right].Name,false);
                Monitor.PulseAll(this);
            }
        }
    }
    class Philosopher
    {
       private string _name;
       private int _timesToEat;
       private int _thinkDelay;
       private int _eatDelay;
       private int left, right;
       private BunchOfChopsticks _chopsticks;
        public Philosopher(int index, BunchOfChopsticks chopsticks, int timesToEating)
        {
            _timesToEat = timesToEating;
            _name = $"Philosoper {index}";
            _thinkDelay = new Random().Next(1000,10000);
            _eatDelay = new Random().Next(1000, 10000);
            _chopsticks = chopsticks;
            new Thread(new ThreadStart(Run)).Start();
        }
        public void Run()
        {
            for (; _timesToEat>0; _timesToEat-- )
            {
                try
                {
                    Think();

                    _chopsticks.Get(ref left,ref right,_name);
                    
                    Eat();

                    _chopsticks.Put(left, right,_name);

                }
                catch
                {
                    return;
                }
            }
        }

        private void Eat()
        {
            Thread.Sleep(_eatDelay);
            Console.WriteLine( _name + " is eating... [" + (_timesToEat - 1) + " left ]");
        }

        private void Think()
        {
            Console.WriteLine( _name + " is thinking...");
            Thread.Sleep(_thinkDelay);
        }
    }
    public class philopblm
    {
        public static void Main()
        {
            BunchOfChopsticks philofork = new BunchOfChopsticks();
            philofork.Init(5);
            var timesOfEating = 5;
            new Philosopher(0, philofork,timesOfEating);
            new Philosopher(1, philofork,timesOfEating);
            new Philosopher(2, philofork,timesOfEating);
            new Philosopher(3, philofork,timesOfEating);
            new Philosopher(4, philofork,timesOfEating);
        }
    }
}
