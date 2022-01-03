using System;
using System.Collections.Generic;
using System.Text;

namespace DiningPhilosophers.Implementation.FirstStrategy
{
    public static class StringConstants
    {
        public static readonly string PhilosopherIsEating= "{0} is eating with {1} and {2}.";
        public static readonly string PhilosopherIsBackToThinking= "{0} is back to thinking.";
        public static readonly string PhilosopherHasChopstickInRightHand= "{0} go to {1} (right).";
        public static readonly string PhilosopherHasChopstickInLeftHand= "{0} go to {1} (left).";
        public static readonly string ChopstickOnTheTable= "{0} get back on the table. {0} still has {1} uses.";
    }
}
