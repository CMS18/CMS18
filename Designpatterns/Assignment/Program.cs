using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using CameraAPI;
using Singleton;
using Menu;
using Factory;
using Observer;


// 
// This program is a badly written one. It has strong coupling between objects, no interfaces and no apparent designpatterns implemented.
// The program simulates a command-central, which can start and stop the surveillance cameras connected to it.
// Every camera is represented by a camera class, and in this program there are two types, indoor cameras and outdoor cameras.
// The cameras itself has different implementations, the outdoor cameras also has an lamp that must be handled. 
// 
//
// Camera settings:
//
// #Indoors 
// - Sound ON
// - Light OFF
// - Motion detect OFF
// - Filter OFF
//
// #Outdoors
// - Sound OFF
// - Light ON
// - Motion detect ON
// - Filter ON
//
// ASSIGNMENT
// -----------------------------
//  The goal is to redo the classes below - EXCEPT the camera-API!
//  You need to find a way to use design-patterns that decouple the strong relationship these classes have. 
//  *The user wants an convenient way (maybe by user input) to pick what cameras to use (camera - TYPE) and attach them to the Monitor system. 
//  *The user only need one type of camera, indoor or outdoor
//  *The user want the feature to add and remove cameras
//  *The user want to be able to send an signal to start or stop the cameras
//
//
// A possible solution will be provided 20/1 2019 23:59 
// If you can not submit a solution by this date and time, you need to contact me.

namespace Assignment
{

    public class Program
    {
        static void Main(string[] args)
        {
            // Print menu
            PrintMenu print = new PrintMenu();
            Console.WriteLine(print.MenuItems());
            Console.Write("Enter your selection: ");
            var choice = int.Parse(Console.ReadLine());
            var camera = print.BuildMenu(choice);
            //print.TypeMenu();

            // An instance of the monitor system
            CameraMonitor mon = new CameraMonitor();
            // Add them to the monitor
            mon.AttachCamera(camera);
            

            // Start
            mon.StartCamera();
        }
    }    
}


