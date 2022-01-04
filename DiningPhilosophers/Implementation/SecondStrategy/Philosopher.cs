using DiningPhilosophers.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DiningPhilosophers.Implementation.SecondStrategy
{
    public class Philosopher
    {
        private int _timesToEat;
        private int _timesEaten = 0;
        private readonly int _index;
        private readonly List<Philosopher> _allPhilosophers;
        private State _state;
        private string _name;
        public Chopstick LeftChopstick { get; set; }
        public Chopstick RightChopstick { get; set; }
        public Philosopher LeftPhilosopher
        {
            get
            {
                if (_index == 0)
                    return _allPhilosophers[_allPhilosophers.Count - 1];
                else
                    return _allPhilosophers[_index - 1];
            }
        }

        public Philosopher RightPhilosopher
        {
            get
            {
                if (_index == _allPhilosophers.Count - 1)
                    return _allPhilosophers[0];
                else
                    return _allPhilosophers[_index + 1];
            }
        }
        public Philosopher(List<Philosopher> allPhilosophers, int index,int timesToEat)
        {
            _allPhilosophers = allPhilosophers;
            _timesToEat = timesToEat;
            _index = index;
            _name = string.Format(Constants.Philosopher, _index);
            _state = State.Thinking;
        }

        public void EatAll()
        {
            // Cycle through thinking and eating until done eating.
            while (_timesEaten < _timesToEat)
            {
                Think();

                if (PickUp())
                {
                    // Chopsticks acquired, eat up
                    Eat();

                    // Release chopsticks
                    PutDownLeft();
                    PutDownRight();
                }

            }
        }

        private bool PickUp()
        {
            // Try to pick up the left chopstick
            if (Monitor.TryEnter(LeftChopstick))
            {
                var watch = System.Diagnostics.Stopwatch.StartNew();

                Console.WriteLine(Utility.PickUpChopstick,_name,LeftChopstick.Name);
                // Now try to pick up the right
                if (Monitor.TryEnter(RightChopstick))
                {
                    watch.Stop();
                    Console.WriteLine(Utility.PickUpChopstick,_name,RightChopstick.Name, watch.ElapsedMilliseconds);

                    // Both chopsticks acquired, its now time to eat
                    return true;
                }
                else
                {
                    // Could not get the right chopstick, so put down the left
                    PutDownLeft();
                }

                watch.Stop();
            }

            // Could not acquire chopsticks, try again
            return false;
        }

        private void Eat()
        {
            Thread.Sleep(RandomWaitingTime.WaitingTime);
            _state = State.Eating;
            _timesEaten++;
            Console.WriteLine(Utility.PhilosopherEats, _name,_timesToEat -_timesEaten);
            Thread.Sleep(RandomWaitingTime.WaitingTime);
        }

        private void PutDownLeft()
        {
            Monitor.Exit(LeftChopstick);
            Console.WriteLine(Utility.PutDownChopstick, _name,LeftChopstick.Name);
        }

        private void PutDownRight()
        {
            Monitor.Exit(RightChopstick);
            Console.WriteLine(Utility.PutDownChopstick,_name,RightChopstick.Name);
        }

        private void Think()
        {
            Thread.Sleep(RandomWaitingTime.WaitingTime);
            _state = State.Thinking;
            Console.WriteLine(Utility.PhilosopherThink, _name);
            Thread.Sleep(RandomWaitingTime.WaitingTime);
        }
    }
}
