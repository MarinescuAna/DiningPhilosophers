using System;
using System.Collections.Generic;
using System.Text;

namespace DiningPhilosophers.Implementation.SecondStrategy
{
    public enum State
    {
        Thinking = 0,
        Eating = 1
    }
    public static class Utility
    {
        public static readonly string PickUpChopstick= "{0} picks up {1}.";
        public static readonly string PutDownChopstick= "{0} puts down {1}.";
        public static readonly string PhilosopherEats= "{0} eats. [{1} times left]";
        public static readonly string PhilosopherThink= "{0} is thinking.";
    }
}
