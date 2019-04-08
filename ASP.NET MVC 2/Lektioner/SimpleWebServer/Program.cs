using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace SimpleWebServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting web server...");

            IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Any, 34567);
            Socket listener = new Socket(IPAddress.Any.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            listener.Bind(localEndPoint);
            listener.Listen(100);

            Console.WriteLine("Waiting for a connection...");

            Socket handler = listener.Accept();

            var ns = new NetworkStream(handler);
            var reader = new StreamReader(ns);
            var writer = new StreamWriter(ns);

            var command = reader.ReadLine();
            Console.WriteLine($"Command {command}");

            var headers = new List<string>();
            var header = reader.ReadLine();
            while (!string.IsNullOrEmpty(header))
            {
                headers.Add(header);
                Console.WriteLine($"Header _> {header}");
                header = reader.ReadLine();
            }

            Console.WriteLine("Got command and headers in REQUEST!");
            Console.WriteLine("Writing RESPONSE!");

            writer.WriteLine("HTTP/1.1 200 OK");
            writer.WriteLine("");
            writer.WriteLine("<h1>Hello World!</h1>");
            writer.WriteLine("<p>CMS 18 is Awesome!</p>");
            writer.Flush();



            Console.ReadLine();
            handler.Shutdown(SocketShutdown.Both);
            handler.Close();

        }
    }
}
