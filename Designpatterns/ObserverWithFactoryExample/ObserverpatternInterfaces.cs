using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverWithFactoryExample
{
    // interfaces

    public interface ILampSwitchSupplier
    {
        void Update();
    }

    public interface ILightState //IState
    {
        bool CurrentState { get; set; }
    }

    public interface ILampSwitchCentral // ISubject
    {
        void Notify();
        void Attach(ILampSwitchSupplier o);
        void Detach(ILampSwitchSupplier o);
        ILightState GetState();
        void SetState(ILightState s);
    }



}
