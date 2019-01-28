using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverWithFactoryExample
{
    
    class Program
    {

        static void Main(string[] args)
        {
            ILampSwitchCentral lampSwitchCentral = new LampSwitchCentral();


            //example
            ILampSwitchSupplier observerSwitch1 = ConcreteSwitchFactory.CreateProductFromFactory("C1", lampSwitchCentral); // type C1
            ILampSwitchSupplier observerSwitch2 = ConcreteSwitchFactory.CreateProductFromFactory("C2",lampSwitchCentral); // type C2
            ILampSwitchSupplier observerSwitch3 = ConcreteSwitchFactory.CreateProductFromFactory("C1",lampSwitchCentral);

            lampSwitchCentral.Attach(observerSwitch1);
            lampSwitchCentral.Attach(observerSwitch2);
            lampSwitchCentral.Attach(observerSwitch3);


            ILightState lightState = new LightState();
            lightState.CurrentState = false; // off

            lampSwitchCentral.SetState(lightState);
            lampSwitchCentral.Notify();

            lightState.CurrentState = true; // on

            lampSwitchCentral.SetState(lightState);
            lampSwitchCentral.Notify();

            // remove two lampswitches

            lampSwitchCentral.Detach(observerSwitch1);
            lampSwitchCentral.Detach(observerSwitch2);


            // lights off! only one observer left, lets update it!

            lightState.CurrentState = false; // off
            lampSwitchCentral.Notify();
        }
    }
}
