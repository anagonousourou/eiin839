using System;
using System.Diagnostics;
using System.IO;
using ExternalExeCall;
using Webserver.Generic;

class Program
{
    static void Main()
    {

        IAnswerMaker maker = new ExeAnswerMaker();//implémentation de IAnswerMaker qui utilise un executable pour generer la réponse
        WebServer server = new WebServer(maker);//injection de dépendances dans le WebServer;

        server.Launch( new string[]{ "http://localhost:8080/"  });//on lance le server;
    }
}