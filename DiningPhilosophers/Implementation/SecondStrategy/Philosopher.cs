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
        private State _state;
        private string _name;
        private Chopstick _leftChopstick { get; set; }
        private Chopstick _rightChopstick { get; set; }

        public Philosopher(int index,int timesToEat)
        {
            _timesToEat = timesToEat;
            _index = index;
            _name = string.Format(Constants.Philosopher, _index);
            _state = State.Thinking;
           
            _leftChopstick = _leftChopstick ?? new Chopstick();
            _rightChopstick = _rightChopstick ?? new Chopstick();
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
            if (Monitor.TryEnter(_leftChopstick))
            {
                Console.WriteLine(Utility.PickUpLeftChopstick,_name);

                // Now try to pick up the right
                if (Monitor.TryEnter(this._rightChopstick))
                {
                    Console.WriteLine(Utility.PickUpRightChopstick,_name);

                    // Both chopsticks acquired, its now time to eat
                    return true;
                }
                else
                {
                    // Could not get the right chopstick, so put down the left
                    PutDownLeft();
                }
            }

            // Could not acquire chopsticks, try again
            return false;
        }

        private void Eat()
        {
            _state = State.Eating;
            _timesEaten++;
            Console.WriteLine(Utility.PhilosopherEats, _name);
        }

        private void PutDownLeft()
        {
            Monitor.Exit(_leftChopstick);
            Console.WriteLine(Utility.PutDownLeftChopstick, _name);
        }

        private void PutDownRight()
        {
            Monitor.Exit(_rightChopstick);
            Console.WriteLine(Utility.PutDownRightChopstick,_name);
        }

        private void Think()
        {
           _state = State.Thinking;
            Console.WriteLine(Utility.PhilosopherThink, _name);
        }
    }
}
