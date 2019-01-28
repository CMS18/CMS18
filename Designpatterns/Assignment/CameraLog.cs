using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    /// <summary>
    /// This logger class is not in use, but may be so in the future. A system that may use this logger-class may want to use it
    /// in a multithreaded environment.
    /// Look for a pattern that make it safer to write to a specific file. 
    /// </summary>
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

    public sealed class Singleton
    {
        private static Singleton _instance = null;
        private static readonly object Mutex = new object();
        private static readonly object PrintMutex = new object();

        private Singleton() { }

        public static Singleton Instance
        {
            get
            {
                lock (Mutex)
                {
                    if (_instance == null)
                        _instance = new Singleton();

                    return _instance;
                }
            }
        }

        public void Print()
        {
            lock (PrintMutex)
                Console.WriteLine("Singleton works great!");
        }

    }

}
