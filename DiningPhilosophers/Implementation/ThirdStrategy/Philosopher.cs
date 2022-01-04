using DiningPhilosophers.Common;
using System;
using System.Text;
using System.Threading;

namespace DiningPhilosophers.Implementation.ThirdStrategy
{
    public class Philosopher
    {
        private string _name;
        private int _timesToEat;
        private int _thinkDelay;
        private int _eatDelay;
        private int _left, _right;
        private BunchOfChopsticks _chopsticks;
        public Philosopher(int index, BunchOfChopsticks chopsticks, int timesToEating)
        {
            _timesToEat = timesToEating;
            _name = string.Format(Constants.Philosopher, index);
            _thinkDelay = RandomWaitingTime.WaitingTime;
            _eatDelay = RandomWaitingTime.WaitingTime;
            _chopsticks = chopsticks;
            new Thread(new ThreadStart(Run)).Start();
        }
        public void Run()
        {
            for (; _timesToEat > 0; _timesToEat--)
            {
                try
                { 
                    _chopsticks.Get(ref _left, ref _right, _name);

                    Eat();

                    _chopsticks.Put(_left, _right, _name);

                    Think();
                }
                catch
                {
                    return;
                }
            }
        }

        private void Eat()
        {
            Thread.Sleep(_eatDelay);
            Console.WriteLine(StringsForThirdStrategy.Eat,_name , (_timesToEat - 1));
            Thread.Sleep(_eatDelay);
        }

        private void Think()
        {
            Thread.Sleep(_thinkDelay);
            Console.WriteLine(StringsForThirdStrategy.Think,_name );
            Thread.Sleep(_thinkDelay);
        }
    }
}
