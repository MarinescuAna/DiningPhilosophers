using System;
using System.Collections.Generic;
using System.Text;

namespace DiningPhilosophers.Common
{
    public static class RandomWaitingTime
    {
        public static int WaitingTime
        {
            get => new Random().Next(1000, 5000);
        }
    }
    public static class Constants
    {
        public static readonly string Philosopher = "Philosopher {0}";
        public static readonly string Chopstick = "Chopstick {0}";
        public static readonly string MenuOptions = "Press: \n1 -> [strategy 1] \n2 -> [strategy 2] \n3 -> [strategy 3]";
        public static readonly string NumberOfPhilosophers = "\n_______________________\nHow many philosophers/chopsticks do you want to have?";
        public static readonly string NumberOfEatingTimes = "How many times do you want a philosopher to be able to eat?";
        public static readonly string NumberOfUses = "How many times do you want a chopstick to be used?";
        public static readonly string WaitingTime = "How long do you want the chopstick to wait for the philosopher to eat?";

    }
}
