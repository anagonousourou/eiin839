using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Webserver.Generic;

namespace ReflectionSample
{
    class Program
    {
        static void Main(string[] args)
        {
            //
            IAnswerMaker maker = new ReflectionAnswerMaker();
            WebServer server = new WebServer(maker);

            server.Launch(new string[] { "http://localhost:8080/" });
        }
    }

    public class Mymethods
    {
        public string Mult(params string[] par)
        {
            return $"{par.Select(x => Int64.Parse(x)).Aggregate((a, b) => a * b)}";
        }


        public string Add(params string[] par)
        {
            return $"{par.Select(x => Int64.Parse(x)).Aggregate((a, b) => a + b)}";
        }

        public string Xor(params string[] par)
        {
            return $"{par.Select(x => Int64.Parse(x)).Aggregate((a, b) => a ^ b)}";
        }
    }

}
