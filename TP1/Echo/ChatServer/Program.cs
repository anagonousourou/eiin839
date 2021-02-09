using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using System.IO;
using System.Net;

namespace Echo
{
    class EchoServer
    {
        [Obsolete]
        static void Main(string[] args)
        {

            int counter = 0;
            var routes = new Dictionary<string, string>();

            routes["/"] = "../../../www/pub/index.html";
            routes["/about"] = "../../../www/pub/about.html";

            Console.CancelKeyPress += delegate
            {
                System.Environment.Exit(0); 
            };

            TcpListener ServerSocket = new TcpListener(IPAddress.Any, 5000);

            ServerSocket.Start();

            Console.WriteLine("Server started..");
            while (true)
            {
                TcpClient clientSocket = ServerSocket.AcceptTcpClient();
                counter++;
                Console.WriteLine($"Accepting client {counter}");
                new Thread(() =>
                {
                    int number = counter;
                    NetworkStream ns = clientSocket.GetStream();
                    BinaryWriter writer = new BinaryWriter(ns);

                    byte[] data = new byte[4500];
                    ns.Read(data);
                    string requestHeader = Encoding.Default.GetString(data);
                    string body = "Not Found";
                    string urlpath = requestHeader.Split(' ')[1];

                    if (routes.ContainsKey(urlpath))
                    {
                        body = System.IO.File.ReadAllText(routes[urlpath]);
                    }
                    else
                    {

                    }


                    StringBuilder template = new StringBuilder();

                    template.Append(
                        $"HTTP/1.1 200 OK\r\nContent-Length: {body.Length}\r\nContent-Type: text/html\r\nLast-Modified: {DateTime.Now.ToString("F")}\r\nAccept-Ranges: bytes\r\nETag: “04f97692cbd1: 377”\r\nDate: {DateTime.Now.ToString("F")}\r\n\r\n{body}"
                        );


                    byte[] hello = Encoding.Default.GetBytes(
                        template.ToString());
                    writer.Write(hello);
                    Console.WriteLine($"Finish with client {number}");

                    //clientSocket.Close();

                }).Start();
            }
        }


    }
}