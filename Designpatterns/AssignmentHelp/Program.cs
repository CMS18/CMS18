using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CameraAPI;



// This file is an update for the assignment. For the original file,look at the projekt "Assignment" in this solution.
// Look at the comments in this file for more help with the assignment. The new comments is in swedish.
// Sammy Lundqvist
// 0702634744
// sammy_lundqvist@outlook.com

namespace Assignment
{

    public class Program
    {

        // För ni som vill använda själva loggern samt använda er av ett textbaserat UI (user interface) för t.ex val av olika typer av kameror
        // kan prova att implementera MVC pattern
        static void Main(string[] args)
        {
            //EXAMPLE

            // An instance of the monitor system

            CameraMonitor mon = new CameraMonitor();

            // Create two outdoor cameras

            OutDoorCamera out1 = new OutDoorCamera(1);
            OutDoorCamera out2 = new OutDoorCamera(2);

            // Add them to the monitor

            mon.AttachCamera(out1);
            mon.AttachCamera(out2);

            // Just an optional scenario:
            // If time is night(20-07) - start the outdoor cameras

            TimeSpan start = TimeSpan.Parse("20:00");
            TimeSpan end = TimeSpan.Parse("07:00");
            TimeSpan now = DateTime.Now.TimeOfDay;

            if ((now > start) && (now < end))
                mon.StartCameras();
            else
                mon.StopCameras();


        }

    }

    /// <summary>
    /// Look at some designpatterns that solve one-to-many relationships.
    /// 
    /// </summary>
    public class CameraMonitor
    {
        //properties
        public OutDoorCamera OutDoorCamera { get; set; }
        public IndoorCamera IndoorCamera { get; set; }

        //*********
        // De två kameraproperties ovan fyller inte så mycket syfte eftersom de från början endast kopplade ihop en kamera till kamera monitor
        // Programmet utökades senare med två listor för kameraklasserna OutDoorCamera och IndoorCamera
        // Vad händer om vi vill lägga till en ny typ av kamera? Vi måste utöka denna klass, vi behöver ett kamera interface av någon typ
        // likt detta:  private readonly List<ICamera> _cameraList; eller något liknande
        // Vi ser också att klassen har ett en till många förhållande, många objekt skall kunna hanteras i en lista i denna klass
        // Hantera  endast en kamera-typ i denna klass!
        // Bra designpatterns skulle kunna vara : observerpattern, publisher subscriber osv




        private readonly List<OutDoorCamera> _outdoorCameraList;
        private readonly List<IndoorCamera> _indoorCameraList;

        public CameraMonitor()
        {
            this._outdoorCameraList = new List<OutDoorCamera>();
            this._indoorCameraList = new List<IndoorCamera>();
        }

        // Vi vill itne hantera två eller fler kameratyper! 
        public void AttachCamera(OutDoorCamera oc)
        {
            _outdoorCameraList.Add(oc);
        }

        public void AttachCamera(IndoorCamera ic)
        {
            _indoorCameraList.Add(ic);
        }

        // TODO also implement methods to remove cameras

        // Om ni implementerar observer pattern så finns det inget som säger att ni inte kan ha fler metoder i ert "subject"
        // T.ex för att starta och stoppa kameran. Kolla speciellt på PUSH-observerpattern vi gjorde. Kanske kan man skicka in en boolean eller en sträng
        // med information om vad som ska hända 
        public void StartCameras()
        {
            foreach (OutDoorCamera o in _outdoorCameraList)
            {
                o.Start();
            }

            foreach (IndoorCamera i in _indoorCameraList)
            {
                i.Start();
            }

        }

        public void StopCameras()
        {
            foreach (OutDoorCamera o in _outdoorCameraList)
            {
                o.Stop();
            }

            foreach (IndoorCamera i in _indoorCameraList)
            {
                i.Stop();
            }
        }

    }

    /// <summary>
    /// This camera base-class holds references to ALL API-classes for the camera, bad practice.
    /// Look for a pattern that creates an easier interface to subsystems.
    /// Also look for an pattern that may create camera objects when needed. Abstraction is the key.
    /// </summary>
    public class Camera
    {
        /*
         * Undersök facademönstret.
         * Kamera-klassen vill inte hålla direkta associotioner till alla kamera-api klasser
         * Ta ut dom helt ur denna klass!
         * Sedan vid användandet av observerpattern måste du fundera på kameraklassens roll i det mönstret
         *
         */
        protected int Id;
        protected ImageProcessor ImgP;
        protected SoundProcessor SoundP;
        protected CameraDriver CamDriver;
        protected CameraLight CamLight;
        protected MotionSensor MotSensor;


        public Camera(int id)
        {
            this.Id = id;
            ImgP = new ImageProcessor();
            SoundP = new SoundProcessor();
            CamDriver = new CameraDriver();
            CamLight = new CameraLight();
            MotSensor = new MotionSensor();
        }


    }

    /*
     * Fundera på designval här.
     * Kanske vill man bygga ut med mer funktionalitet i kameraklasserna. Försök hitta ett designmönster som bygger kameraobjekt
     * Ett kameraobjekt behöver nödvändigtvis inte heta outdoor och indoor kamera i dess klassnamn, det är ju ansvaret som räknas?
     * Det finns mer avancerade sätt att lösa detta på än vad denna uppgift kräver, tänk såhär: Vi skulle kunna ha olika specifikationer för
     * outdoor kamera för olika företag/omgiovningar/beställare.
     *
     * Denna uppgift är mer inriktad till enklare implementation, finns något designmönster som kan bygga dina objekt.
     *
     *
     *
     */



    public class OutDoorCamera : Camera
    {

        public OutDoorCamera(int id) : base(id) { }

        public void Start()
        {
            CamDriver.ConnectCamera();
            ImgP.StartImageReceiver();
            ImgP.EnableFilter();
            CamLight.StartLight();
            MotSensor.StartMotionSensor();
        }

        public void Stop()
        {
            ImgP.StopImageReceiver();
            CamLight.StopLight();
            MotSensor.StopMotionSensor();
            CamDriver.DisconnectCamera();
        }

    }

    public class IndoorCamera : Camera
    {
        public IndoorCamera(int id) : base(id)
        {
        }

        public void Start()
        {
            CamDriver.ConnectCamera();
            ImgP.StartImageReceiver();
            SoundP.StartSoundReceiver();
            SoundP.SetVolume(0.5f);
        }

        public void Stop()
        {
            ImgP.StopImageReceiver();
            SoundP.StopSoundReceiver();
            CamDriver.DisconnectCamera();
        }


    }

    /// <summary>
    /// This logger class is not in use, but may be so in the future. A system that may use this logger-class may want to use it
    /// in a multithreaded environment.
    /// Look for a pattern that make it safer to write to a specific file. 
    /// </summary>

  
    /*
     * Loggern behöver inte vara trådsäker. Försök finna ett designmönster som ger global access till en och samma instans av ett objekt
     */
    public class Logger
    {
        public string Filename { get; set; }

        public Logger(String filename)
        {
            this.Filename = filename;
        }

        public void Log(DateTime timestamp, int id)
        {
            File.WriteAllText(Filename, "Camera ID: " + id + ", snapshot date: " + timestamp.ToString(CultureInfo.CurrentCulture));
        }

    }

}

// READ!!
// Camera API namespace. Just a "bogus" API - DO NOT CHANGE
// The camera API is already "commercially deployed" =) and tested and can not be modified.
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