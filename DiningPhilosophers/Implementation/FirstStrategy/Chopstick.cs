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
        public string Name { get; private set; }
        public Chopstick(int index, Philosopher leftPhilosopher, Philosopher rightPhilosopher, int numberOfUses)
        {
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
                    GoToLeftPhilosopher();
                }
                else
                {
                    GoToRightPhilosopher();
                }
                _counter--;
            }
        }
        private void GoToRightPhilosopher()
        {
            if (_rightPhilosopher.Chopsticks.Count() != 2)
            {
                _semaphore.WaitOne();

                Console.WriteLine(StringsForFirstStrategy.PhilosopherHasChopstickInRightHand, Name, _rightPhilosopher.Name);

                _rightPhilosopher.Chopsticks.Add(this);

                while (!_rightPhilosopher.Eat())
                {
                    Thread.Sleep(WaitingTime.WaitingLessTimeProperty);
                }

                PutOnTheTable();
            }

        }
        public void PutOnTheTable()
        {
            _rightPhilosopher.Chopsticks.Remove(this);

            Console.WriteLine(StringsForFirstStrategy.ChopstickOnTheTable, Name);

            _semaphore.Release();
        }
        private void GoToLeftPhilosopher()
        {
            if (_leftPhilosopher.Chopsticks.Count() != 2)
            {
                _semaphore.WaitOne();

                Console.WriteLine(StringsForFirstStrategy.PhilosopherHasChopstickInLeftHand, Name, _leftPhilosopher.Name);

                _leftPhilosopher.Chopsticks.Add(this);

                while (!_leftPhilosopher.Eat())
                {
                    Thread.Sleep(WaitingTime.WaitingLessTimeProperty);
                }

                PutOnTheTable();
            }
        }
    }
}
