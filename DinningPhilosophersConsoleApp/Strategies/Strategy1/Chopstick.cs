using System;
using System.Collections.Generic;
using System.Text;

namespace DinningPhilosophersConsoleApp.Strategies.Strategy1
{
    class Chopstick
    {
        public string ForkID { get; set; }
        public ForkState State { get; set; }
        public string TakenBy { get; set; }

        public Chopstick()
        {
            State = ForkState.OnTheTable;
        }
        public bool Take(string takenBy)
        {
            lock (this)
            {
                if (this.State == ForkState.OnTheTable)
                {
                    State = ForkState.Taken;
                    TakenBy = takenBy;
                    return true;
                }

                else
                {
                    State = ForkState.Taken;
                    return false;
                }
            }
        }

        public void Put()
        {
            State = ForkState.OnTheTable;
            Console.WriteLine("{0} is place on the table by {1}", ForkID, TakenBy);
            TakenBy = String.Empty;
        }
    }



}
