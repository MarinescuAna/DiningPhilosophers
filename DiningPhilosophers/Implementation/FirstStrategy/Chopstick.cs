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
        private int counter = 0;
        public string Name { get; private set; }
        public Chopstick(int index, Philosopher leftPhilosopher, Philosopher rightPhilosopher, int numberOfUses)
        {
            counter = numberOfUses;
            Name = $"Chopstick {index}";
            _leftPhilosopher = leftPhilosopher;
            _rightPhilosopher = rightPhilosopher;
        }

        public void Run()
        {
            while (counter != 0)
            {
                if (new Random().Next() % 2 == 0)
                {
                    GoToLeftPhilosopher();
                }
                else
                {
                    GoToRightPhilosopher();
                }
                counter--;
            }
        }
        private void GoToRightPhilosopher()
        {
            if (_rightPhilosopher.Chopsticks.Count() != 2)
            {
                _semaphore.WaitOne();

                Console.WriteLine($"{Name} go to {_rightPhilosopher.Name} (right).");

                _rightPhilosopher.Chopsticks.Add(this);

                while (!_rightPhilosopher.Eat())
                {
                    Thread.Sleep(100);
                }

                PutOnTheTable();
            }

        }
        public void PutOnTheTable()
        {
            _rightPhilosopher.Chopsticks.Remove(this);

            Console.WriteLine($"{Name} get back on the table.");

            _semaphore.Release();
        }
        private void GoToLeftPhilosopher()
        {
            if (_leftPhilosopher.Chopsticks.Count() != 2)
            {
                _semaphore.WaitOne();

                Console.WriteLine($"{Name} go to {_leftPhilosopher.Name} (left).");

                _leftPhilosopher.Chopsticks.Add(this);

                while (!_leftPhilosopher.Eat())
                {
                    Thread.Sleep(100);
                }

                PutOnTheTable();
            }
        }
    }
}
