using System;
using System.Collections.Generic;

namespace SimpleObserverPattern
{

    // interfaces

    interface ISubject // ISubject
    {
        void Notify();
        void Attach(IObserver o);
        void Detach(IObserver o);
    }

    interface IObserver // IObserver
    {
        void Update();
    }


    //***********************

    class DigitalAlarm : IObserver
    {
        public void Update()
        {
            Console.WriteLine("Digital alarm is ringing!");
        }
    }

    class AnalogAlarm : IObserver
    {
        public void Update()
        {
            Console.WriteLine("Analog alarm is ringing!");
        }
    }

    class Subject : ISubject
    {
        private readonly List<IObserver> _observers;

        public Subject()
        {
            _observers = new List<IObserver>();
        }

        public void Notify()
        {
            foreach (var o in _observers)
                o.Update();
        }

        public void Attach(IObserver o)
        {
            _observers.Add(o);
        }

        public void Detach(IObserver o)
        {
            _observers.Remove(o);
        }

    }


    class Program
    {
        static void Main(string[] args)
        {
            ISubject subject = new Subject();

            IObserver alarm1 = new DigitalAlarm();
            IObserver alarm2 = new AnalogAlarm();
            IObserver alarm3 = new AnalogAlarm();

            subject.Attach(alarm1);
            subject.Attach(alarm2);
            subject.Attach(alarm3);

            // Ring the alarm!
            subject.Notify();

            Console.WriteLine(); // just for some space separation

            // lets remove two alarms

            subject.Detach(alarm1);

            // Ring the alarm!
            subject.Notify();

        }

    }
}
