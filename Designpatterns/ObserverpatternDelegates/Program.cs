using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ObserverpatternDelegates
{



    class Program
    {
        static void Main(string[] args)
        {
            Timer timer = new Timer();
            TimerSubscriber sub = new TimerSubscriber();

            timer.TimerEvent += sub.OnTimerEnd;

            timer.FireEvent();

        }

    }

    //----------------------------------
    // publisher (like the subject in the observer pattern)

    public class Timer
    {
        public delegate void TimerClock(object src, EventArgs args);

        public event TimerClock TimerEvent;

        // Publish 
        public void FireEvent()
        {
            while (true)
            {
                Thread.Sleep(5000);

                OnTimerEnd();
            }
        }

        protected virtual void OnTimerEnd()
        {
            if(TimerEvent != null)
                TimerEvent(this, EventArgs.Empty);
        }
    }




    //----------------------------------
    // subscriber pattern (like the observer in the observer pattern)


    public class TimerSubscriber
    {
        // this method must match the delegate type AND
        // follow naming convention (Microsoft)
        public void OnTimerEnd(object obj, EventArgs e)
        {
            Console.WriteLine("Event triggered!");
        }

    }











}
