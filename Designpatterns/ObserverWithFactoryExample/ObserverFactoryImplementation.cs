using System;
using System.Collections.Generic;

namespace ObserverWithFactoryExample
{

    public abstract class AbstractSwitch : ILampSwitchSupplier
    {
        protected readonly int Id;
        protected readonly ILampSwitchCentral LampCentral;

        public AbstractSwitch(int id, ILampSwitchCentral c)
        {
            Id = id;
            LampCentral = c;
        }

        public abstract void Update();
    }


    public class ConcreteSwitch1 : AbstractSwitch
    {
        public ConcreteSwitch1(int id, ILampSwitchCentral c) : base(id, c)
        {
        }

        public override  void Update()
        {
            if (LampCentral.GetState().CurrentState)
            {
                Console.WriteLine("Some awesome lamp ID " + Id + ": On");
            }
            else
            {
                Console.WriteLine("Some awesome lamp ID " + Id + ": Off");
            }
        }

   
    }


    public class ConcreteSwitch2 : AbstractSwitch
    {
        public ConcreteSwitch2(int id, ILampSwitchCentral c) : base(id, c)
        {
        }

        public override void Update()
        {
            if (LampCentral.GetState().CurrentState)
            {
                Console.WriteLine("Some ugly lamp ID " + Id + ": On");
            }
            else
            {
                Console.WriteLine("Some ugly lamp ID " + Id + ": Off");
            }
        }


    }

    public class ConcreteSwitchFactory
    {

        private static int _id;

        public static ILampSwitchSupplier CreateProductFromFactory(string fac, ILampSwitchCentral lampSwitchCentral)
        {
            if (fac.Equals("C1"))
                return new ConcreteSwitch1(_id++, lampSwitchCentral);
            if (fac.Equals("C2"))
                return new ConcreteSwitch2(_id++, lampSwitchCentral);

            return null;
        }
    }

    class LightState : ILightState
    {
        public bool CurrentState { get; set; }
    }


    class LampSwitchCentral : ILampSwitchCentral
    {
        private readonly List<ILampSwitchSupplier> _observers;

        private LightState _lightState;

        public LampSwitchCentral()
        {
            _observers = new List<ILampSwitchSupplier>();
            _lightState = new LightState();
        }

        public void Notify()
        {
            foreach (var o in _observers)
                o.Update();
        }

        public void Attach(ILampSwitchSupplier o)
        {
            _observers.Add(o);
        }

        public void Detach(ILampSwitchSupplier o)
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

}
