using CameraAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{       
    public interface ICamera
    {
        string Name { get; set; }
        int Id { get; set; }
        void Start();
        void Stop();
    }

    public abstract class Camera : ICamera
    {
        protected IController controller;
        public Camera(IController controller)
        {
            controller = controller;
        }

        public string Name { get; set; }
        public int Id { get; set; }
        public abstract void Start();
        public abstract void Stop();

    }

    public class CameraFactory
    {
        public ICamera CreateCamera(int choice)
        {
            string c = "";
            ICamera camera = null;

            bool done = false;
            while (!done)
            {
                switch (choice)
                {
                    case 1:
                        c = "indoor";
                        camera = new IndoorCamera(new IndoorController());
                        done = true;
                        break;
                    case 2:
                        c = "outdoor";
                        camera = new OutdoorCamera(new OutdoorController());
                        done = true;
                        break;

                    default:
                        Console.Write("Please pick a valid number: ");
                        choice = int.Parse(Console.ReadLine());
                        break;
                }
            }
            Console.WriteLine($"Created new {c} camera");
            return camera;

        }

    }

    public class OutdoorCamera : Camera
    {
        static int SId = 0;
        public OutdoorCamera(IController controller) : base(controller)
        {
            SId++;
            Id = SId;
            this.Name = "outdoor " + Id;

        }

        public override void Start()
        {
            controller.Start();
        }

        public override void Stop()
        {
            controller.Stop();
        }
    }

    public class IndoorCamera : Camera
    {
        static int SId = 0;
        public IndoorCamera(IController controller) : base(controller)
        {
            SId++;
            Id = SId;
            this.Name = "indoor " + Id;
        }

        public override void Start()
        {
            controller.Start();
        }

        public override void Stop()
        {
            controller.Stop();
        }
    }

    public interface IController
    {
        void Start();
        void Stop();
    }
    public abstract class Controller : IController
    {
        protected ImageProcessor ImgP;
        protected SoundProcessor SoundP;
        protected CameraDriver CamDriver;
        protected CameraLight CamLight;
        protected MotionSensor MotSensor;

        public abstract void Start();

        public abstract void Stop();

    }
    public class IndoorController : Controller
    {
        public IndoorController()
        {
            CamDriver = new CameraDriver();
            ImgP = new ImageProcessor();
            SoundP = new SoundProcessor();
        }

        public override void Start()
        {
            CamDriver.ConnectCamera();
            ImgP.StartImageReceiver();
            SoundP.StartSoundReceiver();
            SoundP.SetVolume(0.5f);
        }

        public override void Stop()
        {
            ImgP.StopImageReceiver();
            SoundP.StopSoundReceiver();
            CamDriver.DisconnectCamera();
        }
    }

    public class OutdoorController : Controller
    {
        public override void Start()
        {
            CamDriver.ConnectCamera();
            ImgP.StartImageReceiver();
            ImgP.EnableFilter();
            CamLight.StartLight();
            MotSensor.StartMotionSensor();
        }

        public override void Stop()
        {
            ImgP.StopImageReceiver();
            CamLight.StopLight();
            MotSensor.StopMotionSensor();
            CamDriver.DisconnectCamera();
        }
    }
}
