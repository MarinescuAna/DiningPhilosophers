using System;
using System.Collections.Generic;
using System.Text;

namespace DiningPhilosophers.Abstraction
{
    public abstract class Strategy
    {
        protected int _max;
        public Strategy(int max)
        {
            _max = max;
        }

        public abstract void Main();
    }
}
