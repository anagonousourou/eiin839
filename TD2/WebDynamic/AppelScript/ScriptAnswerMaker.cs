using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using Webserver.Generic;

namespace AppelScript
{
    class ScriptAnswerMaker : IAnswerMaker
    {
        public string Make(Uri url)
        {
            if(url.Segments.Length < 1 || (url.Segments.Length >=2 && url.Segments[1].EndsWith(".ico") ))
            {
                return "Vous n'avez pas passé de code Python";
            }
            else
            {
                foreach (var sg in url.Segments)
                {
                    Console.WriteLine(sg);
                }
                ProcessStartInfo start = new ProcessStartInfo
                {
                    FileName = @"../../../script.bat", // CHANGE ME !!!
                    Arguments = @$"""{ ( url.Segments[1].Trim(new char[] { '/' }))}""", // Specify arguments.

                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError=true
                };


                using (Process process = Process.Start(start))
                {
                    //
                    // Read in all the text from the process with the StreamReader.
                    //
                    string answer = string.Empty;
                    using (StreamReader reader = process.StandardOutput)
                    {
                        answer+= reader.ReadToEnd();

                    }
                    using(StreamReader reader1 = process.StandardError)
                    {
                        answer += reader1.ReadToEnd();
                    }

                    return answer;
                }
            }
            
        }
    }
}
