using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace BasicServerHTTPlistener
{
    internal class Program
    {
        /**
            On affiche le logo du navigateur d'où l'application est appelée.
            Seuls Firefox, Edge, et Opera sont utilisés
         */

        static string firefox_logo_url = "https://upload.wikimedia.org/wikipedia/commons/d/d2/Firefox_Logo%2C_2017.png";
        static string edge_logo_url = "https://149366088.v2.pressablecdn.com/wp-content/uploads/2019/11/microsoft-edge-new-logo.jpeg";
        static string opera_logo_url = "https://logos-download.com/wp-content/uploads/2016/03/Opera_logo_icon.png";
        private static void Main(string[] args)
        {
            if (!HttpListener.IsSupported)
            {
                Console.WriteLine("A more recent Windows version is required to use the HttpListener class.");
                return;
            }
 
 
            // Create a listener.
            HttpListener listener = new HttpListener();

            // Add the prefixes.
            if (args.Length != 0)
            {
                foreach (string s in args)
                {
                    listener.Prefixes.Add(s);
                    // don't forget to authorize access to the TCP/IP addresses localhost:xxxx and localhost:yyyy 
                    // with netsh http add urlacl url=http://localhost:xxxx/ user="Tout le monde"
                    // and netsh http add urlacl url=http://localhost:yyyy/ user="Tout le monde"
                    // user="Tout le monde" is language dependent, use user=Everyone in english 

                }
            }
            else
            {
                Console.WriteLine("Syntax error: the call must contain at least one web server url as argument");
            }
            listener.Start();
            foreach (string s in args)
            {
                Console.WriteLine("Listening for connections on " + s);
            }

            while (true)
            {
                // Note: The GetContext method blocks while waiting for a request.
                HttpListenerContext context = listener.GetContext();
                HttpListenerRequest request = context.Request;
                IDictionary<string, string> collection = new Dictionary<string,string>();

                string documentContents;
                
                foreach(var k in request.Headers.Keys)
                {
                    
                    collection.Add((string)k, request.Headers.Get((string)k));
                    

                }

                Header h = new Header(collection);

                Console.WriteLine(h.GetHeader("User-Agent"));


                string language = string.Empty;

                string logo_url = string.Empty;

                if (h.GetHeader("User-Agent").Contains("Firefox"))
                {
                    logo_url = firefox_logo_url;
                }
                if (h.GetHeader("User-Agent").Contains("Edg"))
                {
                    logo_url = edge_logo_url;
                }

                if (h.GetHeader("User-Agent").Contains("OPR"))
                {
                    logo_url = opera_logo_url;
                }
                if (h.GetHeader("Accept-Language")!=null && h.GetHeader("Accept-Language").Contains("fr"))
                {
                    language += $@"Salut, Votre navigateur supporte le français 
";

                }

                if (h.GetHeader("Accept-Language")!=null && h.GetHeader("Accept-Language").Contains("en"))
                {
                    language += $@"Hello, Your browser accepts English language";
                }

                string responseString = $@" <!DOCTYPE html>
<html lang=""en""> 
         
{language}
<img width=300 height=300 src=""{logo_url}"">

         
         </ html > ";

                

                
                
                
                
                
                

                using (Stream receiveStream = request.InputStream)
                {
                    using (StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8))
                    {
                        documentContents = readStream.ReadToEnd();
                    }
                }
                Console.WriteLine($"Received request for {request.Url}");
                Console.WriteLine(documentContents);

                // Obtain a response object.
                HttpListenerResponse response = context.Response;

                // Construct a response.
               
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
                // Get a response stream and write the response to it.
                response.ContentLength64 = buffer.Length;
                response.ContentType = "text/html";
                System.IO.Stream output = response.OutputStream;
                output.Write(buffer, 0, buffer.Length);
                // You must close the output stream.
                output.Close();
            }
            // Httplistener neither stop ...
            // listener.Stop();
        }
    }
}