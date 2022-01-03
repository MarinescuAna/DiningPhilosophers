using DiningPhilosophers.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiningPhilosophers.Implementation.ThirdStrategy
{
    public  class Chopstick
    {
        public string Name { get; private set; }
        private string _takenBy;
        private  ChopstickState _state { get; set; }
        public Chopstick(int index)
        {
            Name = string.Format(Constants.Chopstick, index);
            _state = ChopstickState.OnTheTable;
        }
        public bool Take(string takenBy)
        {
            lock (this)
            {
                if (_state == ChopstickState.OnTheTable)
                {
                    _state = ChopstickState.Taken;
                    _takenBy = takenBy;
                    return true;
                }

                else
                {
                    _state = ChopstickState.Taken;
                    return false;
                }
            }
        }

        public void Put()
        {
            _state = ChopstickState.OnTheTable;
            Console.WriteLine(Strings.PutDownChopstick, Name, _takenBy);
            _takenBy = string.Empty;   
        }
    }
}
