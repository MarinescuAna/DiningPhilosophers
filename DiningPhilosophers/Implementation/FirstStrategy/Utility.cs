using System;
using System.Collections.Generic;
using System.Text;

namespace DiningPhilosophers.Implementation.FirstStrategy
{
    public static class WaitingTime
    {
        public static int WaitingTimeProperty
        {
            get => new Random().Next(1000, 1500);
        }
        public static int WaitingLessTimeProperty
        {
            get => new Random().Next(100, 500);
        }
    }
    public static class StringsForFirstStrategy
    {
        public static readonly string PhilosopherIsEating= "{0} is eating with {1} and {2}.";
        public static readonly string PhilosopherIsBackToThinking= "{0} is back to thinking.";
        public static readonly string PhilosopherHasChopstickInRightHand= "{0} go to {1} (right). [{2} times left]";
        public static readonly string PhilosopherHasChopstickInLeftHand= "{0} go to {1} (left). [{2} times left]";
        public static readonly string ChopstickOnTheTable= "{0} get back on the table.";
    }
}
