using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Factory;
using Menu;

namespace Observer
{
    /// <summary>
    /// Camera Monitor is holding to many references to other classes, its strongly coupled.
    /// Look at some designpatterns that solve one-to-many relationships. 
    /// </summary>
    /// 

    public interface IMonitor
    {
        void StartCamera();
        void StopCamera();
        void AttachCamera(ICamera camera);
        void DetachCamera(ICamera camera);
    }
    public class CameraMonitor : IMonitor
    {
        private readonly List<ICamera> _cameraList;

        public CameraMonitor()
        {
            this._cameraList = new List<ICamera>();
        }

        public void AttachCamera(ICamera c)
        {
            Console.WriteLine($"Attached {c.Name} to monitor");
            _cameraList.Add(c);
        }
        public void DetachCamera(ICamera c)
        {
            _cameraList.Remove(c);
        }

        public void StartCamera()
        {
            foreach (ICamera c in _cameraList)
            {

                Console.WriteLine($"{c.Name}");
                c.Start();
            }    
        }

        public void StopCamera()
        {
            foreach (ICamera c in _cameraList)
            {
                c.Stop();
            }
        }

    }
}
