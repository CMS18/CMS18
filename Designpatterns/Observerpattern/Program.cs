using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observerpattern
{
    // about - PULL mec.
    // interfaces

    interface ILightState //IState
    {
        bool CurrentState { get; set; }
    }

    interface ILampSwitchCentral // ISubject
    {
        void Notify();
        void Attach(ILampSwitch o);
        void Detach(ILampSwitch o);
        ILightState GetState();
        void SetState(ILightState s);
    }

    interface ILampSwitch // IObserver
    {
        void Update(ILampSwitchCentral s);
    }


    //***********************
    class LightState:ILightState
    {
        public bool CurrentState { get; set; }
    }

    class LampSwitch : ILampSwitch
    {
        private readonly int _id;

        public LampSwitch(int id)
        {
            _id = id;
        }

        public void Update(ILampSwitchCentral s)
        {
            if (s.GetState().CurrentState)
            {
                Console.WriteLine("LampSwitch " + _id + ": On");
            }
            else
            {
                Console.WriteLine("LampSwitch " + _id + ": Off");
            }
        }
    }

    class LampSwitchCentral : ILampSwitchCentral
    {
        private readonly List<ILampSwitch> _observers;

        private LightState _lightState;

        public LampSwitchCentral()
        {
            _observers = new List<ILampSwitch>();
            _lightState = new LightState();
        }

        public void Notify()
        {
            foreach (var o in _observers)
            o.Update(this);
        }

        public void Attach(ILampSwitch o)
        {
            _observers.Add(o);
        }

        public void Detach(ILampSwitch o)
        {
            _observers.Remove(o);
        }

        public ILightState GetState()
        {
            return _lightState;
        }

        public void SetState(ILightState s)
        {
            _lightState = s as LightState;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            ILampSwitchCentral lampSwitchCentral = new LampSwitchCentral();

            lampSwitchCentral.Attach(new LampSwitch(1));
            lampSwitchCentral.Attach(new LampSwitch(2));
            lampSwitchCentral.Attach(new LampSwitch(3));

            ILightState lightState = new LightState();
            lightState.CurrentState = false; // off

            lampSwitchCentral.SetState(lightState);
            lampSwitchCentral.Notify();

            lightState.CurrentState = true; // on

            lampSwitchCentral.SetState(lightState);
            lampSwitchCentral.Notify();
        }

    }
}
