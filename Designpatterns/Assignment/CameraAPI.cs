using System;

// READ
// Camera API namespace. Just a bogus API - DO NOT CHANGE
// The camera API is already commercially launched =) and tested and can not be modified.

namespace CameraAPI
{

    public class CameraDriver
    {

        public void ConnectCamera()
        {
            Console.WriteLine("Camera connected");
        }

        public void DisconnectCamera()
        {
            Console.WriteLine("Camera disconnected");
        }

        public void RunFailCheck()
        {
            Console.WriteLine("Running fail check...");
        }

    }

    public class ImageProcessor
    {
        public void StartImageReceiver()
        {
            Console.WriteLine("Image receiver enabled");
        }

        public void StopImageReceiver()
        {
            Console.WriteLine("Image receiver disabled");
        }

        public void EnableFilter()
        {
            Console.WriteLine("Filter enabled");
        }

    }

    public class SoundProcessor
    {
        public float Volume { get; private set; }


        public void StartSoundReceiver()
        {
            Console.WriteLine("Sound receiver enabled");
        }

        public void StopSoundReceiver()
        {
            Console.WriteLine("Sound receiver disabled");
        }

        public void SetVolume(float v)
        {
            Volume = v;
            Console.WriteLine("Volume set to: " + v);
        }

    }

    public class CameraLight
    {

        public void StartLight()
        {
            Console.WriteLine("Light enabled");
        }

        public void StopLight()
        {
            Console.WriteLine("Light disabled");
        }

    }

    public class MotionSensor
    {

        public void StartMotionSensor()
        {
            Console.WriteLine("Motion sensor started");
        }

        public void StopMotionSensor()
        {
            Console.WriteLine("Motion sensor stopped");
        }

    }

}
