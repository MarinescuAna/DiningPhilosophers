using System;
using System.Collections.Generic;
using System.Text;

namespace DiningPhilosophers.Implementation.ThirdStrategy
{
  
    public static class StringsForThirdStrategy
    {
        public static readonly string PickUpChopstick = "{0} picks up {1} and {2}. [{3}s]";
        public static readonly string PutDownChopstick = "{0} puts down {1} and {2}.";
        public static readonly string Eat = "{0} is eating ... [{1} left]";
        public static readonly string Think = "{0} is thinking ...";
    }
}
