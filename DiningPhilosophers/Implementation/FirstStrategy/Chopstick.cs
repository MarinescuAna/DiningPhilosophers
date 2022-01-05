using DiningPhilosophers.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace DiningPhilosophers.Implementation.FirstStrategy
{
    public class Chopstick
    {
        private Philosopher _leftPhilosopher;
        private Philosopher _rightPhilosopher;
        private Semaphore _semaphore = new Semaphore(1, 1);
        private int _counter = 0;
        private int _waitingTime = 0;
        public string Name { get; private set; }
        public Chopstick(int index, Philosopher leftPhilosopher, Philosopher rightPhilosopher, int numberOfUses, int watingtime)
        {
            _waitingTime = watingtime;
            _counter = numberOfUses;
            Name = string.Format(Constants.Chopstick, index);
            _leftPhilosopher = leftPhilosopher;
            _rightPhilosopher = rightPhilosopher;
        }

        public void Run()
        {
            while (_counter != 0)
            {
                if (new Random().Next() % 2 == 0)
                {
                    GoToPhilosopher(_leftPhilosopher);
                }
                else
                {
                    GoToPhilosopher(_rightPhilosopher);
                }
                _counter--;
            }
        }
        private void GoToPhilosopher(Philosopher philosopher)
        {

            if (philosopher.Chopsticks.Count() != 2)
            {
                _semaphore.WaitOne();

                Console.WriteLine(StringsForFirstStrategy.PhilosopherHasChopstickInRightHand, Name, philosopher.Name);

                philosopher.Chopsticks.Add(this);

                var waitingTime = _waitingTime;
                while (!philosopher.Eat() && waitingTime != 0)
                {
                    Thread.Sleep(WaitingTime.WaitingLessTimeProperty);
                    waitingTime--;
                }

                philosopher.Chopsticks.Remove(this);

                Console.WriteLine(StringsForFirstStrategy.ChopstickOnTheTable, Name);

                _semaphore.Release();
            }
        }

    }
}
