using System;
using Webserver.Generic;

namespace AppelScript
{
    class Program
    {
        static void Main(string[] args)
        {
            IAnswerMaker maker = new ScriptAnswerMaker();
            WebServer server = new WebServer(maker);

            server.Launch(new string[] { "http://localhost:8080/" });
        }
    }
}
