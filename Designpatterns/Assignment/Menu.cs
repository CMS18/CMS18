using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Factory;

namespace Menu
{
    public class PrintMenu
    {

        public async Task PrintCenter(string print)
        {
            Console.SetCursorPosition((Console.WindowWidth - print.Length) / 2, Console.CursorTop);
            foreach (var item in print)
            {
                await Task.Delay(40);
                Console.Write(item);
            }
        }
        public async Task Print(string print)
        {
            foreach (var item in print)
            {
                await Task.Delay(40);
                Console.Write(item);
            }
        }
        public ICamera TypeMenu()
        {
            var name = "CCTV Inc.";
            var start = "We see what you do 24/7";
            string menu = MenuItems();

            Task.Run(() => PrintCenter(name)).Wait();
            Console.WriteLine();
            Task.Run(() => PrintCenter(start)).Wait();
            Console.WriteLine();
            Task.Run(() => Print(menu)).Wait();
            Console.Write("\n");
            var selection = "Enter your selection: ";
            Task.Run(() => Print(selection)).Wait();


            var choice = int.Parse(Console.ReadLine());
            var camera = BuildMenu(choice);

            return camera;
        }

        public ICamera BuildMenu(int choice)
        {
            CameraFactory factory = new CameraFactory();
            bool done = false;
            ICamera camera = null;
            while (!done)
            {
                switch (choice)
                {
                    case 1:
                        Console.Write(SubMenu());
                        choice = int.Parse(Console.ReadLine());
                        camera = factory.CreateCamera(choice);

                        done = true;
                        break;
                    case 2:
                        GetCameraList();
                        done = true;
                        break;
                    case 3:
                        RemoveCamera();
                        done = true;
                        break;
                    case 9:
                        Console.WriteLine("Exiting...");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.Write("Please pick a valid number: ");
                        choice = int.Parse(Console.ReadLine());
                        break;
                }

            }
            return camera;


        }

        public string MenuItems()
        {
            return $"MENU\n" +
                $"1) Add new camera\n" +
                $"2) See camera list\n" +
                $"3) Remove cameras\n" +
                $"9) Exit\n";
        }

        private void RemoveCamera()
        {
            Console.WriteLine("Camera removed");
        }

        private void GetCameraList()
        {
            Console.WriteLine("This is a camera list");
        }

        public string SubMenu()
        {
            return $"1) Create indoor camera\n" +
                $"2) Create outdoor camera\n" +
                $"Enter your selection: ";
        }
        
    }
}
