using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace DinningPhilosophersConsoleApp.Strategies.Strategy1
{
    class Philosopher
    {
        public string Name { get; set; }

        public PhilosopherState State { get; set; }

        // determines number of continuose thinkings, without being considered starving
        readonly int StarvationThreshold;

        // defines the right and the left side fork of a philosopher
        public Chopstick RightFork;
        public Chopstick LeftFork;
        private AllChopsticks AllChopsticks;
        Random rand = new Random();

        int _contThinkCount = 0;

        public Philosopher(AllChopsticks allChopsticks, string name, int contThinkCount)
        {
            AllChopsticks = allChopsticks;
            Name = name;
            State = PhilosopherState.Thinking;
            _contThinkCount = contThinkCount;
        }
        public void run()
        {
            while (_contThinkCount > 0)
            {
                Eat();
                Think();
            }
            Console.WriteLine("{0} has finished!", Name);
        }
        public void Eat()
        {
            // take the fork in the right hand
            if (TakeForkInRightHand())
            {
                // if got the fork in the right hand immediatley try to take the fork in the left hand
                if (TakeForkInLeftHand())
                {
                    // if got both forks then eat
                    this.State = PhilosopherState.Eating;
                    Console.WriteLine("{0} is eating!", Name);
                    Thread.Sleep(rand.Next(5000, 7000));


                    // place the forks back
                    PutDownRightChopstick();
                    PutDownLeftChopstick();
                }
                // got the right fork but not the left one
                else
                {
                    // wait for a small random period and try agian to get left fork
                    if (TakeForkInLeftHand())
                    {
                        // if got the left fork then eat
                        this.State = PhilosopherState.Eating;
                        Console.WriteLine("{0} is eating!", Name);
                        Thread.Sleep(rand.Next(5000, 7000));

                        PutDownRightChopstick();
                        PutDownLeftChopstick();
                    }
                    // if couldn't get the fork even after the wait, out the right fork on the table
                    else
                    {
                        PutDownRightChopstick();
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
                    if (TakeForkInRightHand())
                    {
                        // if got the right one then eat
                        this.State = PhilosopherState.Eating;
                        Console.WriteLine("{0} is eating!", Name);
                        Thread.Sleep(rand.Next(5000, 7000));

                        PutDownRightChopstick();
                        PutDownLeftChopstick();
                    }
                    else
                    {
                        // else put the left fork back on the table
                        PutDownLeftChopstick();
                    }
                }
            }

            Think();

        }
        private void PutDownLeftChopstick()
        {
            AllChopsticks.PutChopstickOnTheTable(LeftFork);
            Console.WriteLine("{0} put down {1}!(left)", Name, LeftFork.ForkID);
            LeftFork.Put();
        }
        private void PutDownRightChopstick()
        {
            AllChopsticks.PutChopstickOnTheTable(RightFork);
            Console.WriteLine("{0} put down {1}!(right)", Name, RightFork.ForkID);
            RightFork.Put();
        }
        public void Think()
        {
            this.State = PhilosopherState.Thinking;
            Console.WriteLine("{0} is thinking! [{1} times left]", Name, _contThinkCount);
            Thread.Sleep(rand.Next(2500, 4000));
            _contThinkCount--;

        }

        private bool TakeForkInLeftHand()
        {
            LeftFork = AllChopsticks.GetChopstick();
            Console.WriteLine("{0} pick up {1}!(left)", Name, LeftFork.ForkID);
            return LeftFork.Take(Name);
        }

        private bool TakeForkInRightHand()
        {
            RightFork = AllChopsticks.GetChopstick();
            Console.WriteLine("{0} pick up {1}!(right)", Name, RightFork.ForkID);
            return RightFork.Take(Name);
        }

    }
}
