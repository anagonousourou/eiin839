using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Web;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;
using Webserver.Generic;

namespace ReflectionSample
{

    class ReflectionAnswerMaker:IAnswerMaker
    {
        public string Make(Uri url)
        {
            if ( url.Segments.Length > 1 &&  ! url.Segments[1].Trim(new char[] { '/' }).Contains("favicon") )
            {
                string methodName = url.Segments[1].Trim(new char[] { '/' });
                List<string> chaines=new List<string>();

                
                var parameters=HttpUtility.ParseQueryString(url.Query);
                foreach(var k in parameters.AllKeys)
                {
                    chaines.Add(parameters.Get(k));
                }

                Type type = typeof(Mymethods);
                MethodInfo method = type.GetMethod(methodName);
                if (method != null)
                {
                    Mymethods c = new Mymethods();
                    return $@"Parametres : {
                        chaines.Aggregate((a, b) => a + ", " + b)
                        } ; Result : {(string)method.Invoke(c, new object[] { chaines.ToArray() })} ";
                    
                    
                }
                else
                {
                    return $"La méthode {methodName} n'existe pas.";
                }
                


            }
            else
            {
                return "Nothing";
            }
        }
    }
   
}
