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

            Console.CancelKeyPress += delegate
            {
                System.Environment.Exit(0);
            };

            TcpListener ServerSocket = new TcpListener(IPAddress.Any,5000);
            
            ServerSocket.Start();

            Console.WriteLine("Server started..");
            while (true)
            {
                TcpClient clientSocket = ServerSocket.AcceptTcpClient();
                
                
                NetworkStream ns= clientSocket.GetStream();
                BinaryWriter writer = new BinaryWriter(ns);
                
                byte[] data=new byte[4500];
                ns.Read(data);
                Console.WriteLine(Encoding.Default.GetString(data));
                StringBuilder header = new StringBuilder();
                string body = "Salut tout le monde";
                header.Append($"HTTP/1.1 200 OK\r\nContent-Length: {body.Length}\r\nContent-Type: text/html\r\nLast - Modified: Wed, 12 Aug 1998 15:03:50 GMT\r\nAccept - Ranges: bytes\r\nETag: “04f97692cbd1: 377”\r\nDate: Thu, 19 Jun 2008 19:29:07 GMT\r\n\r\n{body}"
                    );


                   

                byte[] hello = Encoding.Default.GetBytes(
                    header.ToString());
                writer.Write(hello);
                //clientSocket.Close();
                
            }


        }
    }

    public class HandleClient
    {
        TcpClient clientSocket;
        public void startClient(TcpClient inClientSocket)
        {
            this.clientSocket = inClientSocket;
            Thread ctThread = new Thread(Echo);
            ctThread.Start();
        }



        private void Echo()
        {
            NetworkStream stream = clientSocket.GetStream();
            BinaryReader reader = new BinaryReader(stream);
            BinaryWriter writer = new BinaryWriter(stream);

            while (true)
            {

                string str = @"<TITLE> L'exemple HTML le plus simple</TITLE> 
<H1> Ceci est un sous-titre de niveau 1</H1>
Bienvenue dans le monde HTML. Ceci est un paragraphe.
<P> Et ceci en est un second. </P>
<A HREF=index.html>cliquez ici</A> pour réafficher";
                Console.WriteLine(str);
                writer.Write(str);
            }
        }



    }

}