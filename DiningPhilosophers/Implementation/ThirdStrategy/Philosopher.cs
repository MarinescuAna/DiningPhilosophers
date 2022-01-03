using DiningPhilosophers.Common;
using DiningPhilosophers.Implementation.SecondStrategy;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DiningPhilosophers.Implementation.ThirdStrategy
{
    public class Philosopher
    {
        private string _name { get; set; }

        private PhilosopherState _state { get; set; }

        // determines number of continuose thinkings, without being considered starving
        private readonly int _maxThinkingTimes;

        // defines the right and the left side fork of a philosopher
        public readonly Chopstick RightChopstick;
        public readonly Chopstick LeftChopstick;

        private Random _rand = new Random();

        private int _contThinkCount = 0;

        public Philosopher(Chopstick rightFork, Chopstick leftFork, int index, int maxThinkingTimes)
        {
            RightChopstick = rightFork;
            LeftChopstick = leftFork;
            _name = string.Format(Constants.Philosopher, index);
            _state = PhilosopherState.Thinking;
            _maxThinkingTimes = maxThinkingTimes;
        }

        public void Eat()
        {
            while (_maxThinkingTimes >= _contThinkCount)
            {
                // take the fork in the right hand
                if (TakeForkInRightHand())
                {
                    // if got the fork in the right hand immediatley try to take the fork in the left hand
                    if (TakeForkInLeftHand())
                    {
                        // if got both forks then eat
                        this._state = PhilosopherState.Eating;
                        Thread.Sleep(_rand.Next(5000, 10000));

                        // place the forks back
                        RightChopstick.Put();
                        LeftChopstick.Put();
                    }
                    // got the right fork but not the left one
                    else
                    {
                        // wait for a small random period and try agian to get left fork
                        Thread.Sleep(_rand.Next(100, 400));
                        if (TakeForkInLeftHand())
                        {
                            // if got the left fork then eat
                            this._state = PhilosopherState.Eating;
                            Console.WriteLine(Utility.PhilosopherEats, _name);
                            Thread.Sleep(_rand.Next(5000, 10000));

                            RightChopstick.Put();
                            LeftChopstick.Put();
                        }
                        // if couldn't get the fork even after the wait, out the right fork on the table
                        else
                        {
                            RightChopstick.Put();
                        }
                    }
                }
                // if couldn't get fork on the right hand
                else
                {
                    // get a fork the left hand
                    if (TakeForkInLeftHand())
                    {
                        // wait for a small random time period and then try acquire the right one
                        Thread.Sleep(_rand.Next(100, 400));
                        if (TakeForkInRightHand())
                        {
                            // if got the right one then eat
                            this._state = PhilosopherState.Eating;
                            Console.WriteLine(Utility.PhilosopherEats, _name);
                            Thread.Sleep(_rand.Next(5000, 10000));

                            RightChopstick.Put();
                            LeftChopstick.Put();
                        }
                        else
                        {
                            // else put the left fork back on the table
                            LeftChopstick.Put();
                        }
                    }
                }

                Think();
            }
        }

        public void Think()
        {
            this._state = PhilosopherState.Thinking;
            Console.WriteLine(Utility.PhilosopherThink, _name);
            Thread.Sleep(_rand.Next(2500, 20000));
            _contThinkCount++;
        }

        private bool TakeForkInLeftHand()
        {
            Console.WriteLine(Strings.PickUpChopstick, _name,LeftChopstick.Name);
            return LeftChopstick.Take(_name);
        }

        private bool TakeForkInRightHand()
        {
            Console.WriteLine(Strings.PickUpChopstick, _name, RightChopstick.Name);
            return RightChopstick.Take(_name);
        }
    }
}
