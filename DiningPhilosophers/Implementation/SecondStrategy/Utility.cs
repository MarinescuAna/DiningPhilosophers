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
        public static readonly string PickUpLeftChopstick= "{0} picks up left chopstick.";
        public static readonly string PickUpRightChopstick= "{0} picks up right chopstick.";
        public static readonly string PutDownLeftChopstick= "{0} puts down left chopstick.";
        public static readonly string PutDownRightChopstick= "{0} puts down right chopstick.";
        public static readonly string PhilosopherEats= "{0} eats.";
        public static readonly string PhilosopherThink= "{0} is thinking.";
    }
}
