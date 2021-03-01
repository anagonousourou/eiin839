using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Diagnostics;
using System.IO;
using Webserver.Generic;

namespace ExternalExeCall
{
    class ExeAnswerMaker : IAnswerMaker
    {
        public string Make(Uri url)
        {

            if (url.Segments[1].Trim(new char[] { '/' }).Equals("add"))
            {
                var aug1 = HttpUtility.ParseQueryString(url.Query).Get("aug1");
                var aug2 = HttpUtility.ParseQueryString(url.Query).Get("aug2");
                var args = new string[] { aug1, aug2 };
                ProcessStartInfo start = new ProcessStartInfo
                {
                    FileName = @"../../../ExecTest/bin/Debug/ExecTest.exe", // Specify exe name.
                    Arguments = args.Aggregate<string>((a, b) => a + " " + b), // Specify arguments.

                    UseShellExecute = false,
                    RedirectStandardOutput = true
                };


                using (Process process = Process.Start(start))
                {
                    //
                    // Read in all the text from the process with the StreamReader.
                    //
                    using (StreamReader reader = process.StandardOutput)
                    {
                        return reader.ReadToEnd();

                    }
                }

            }
            else
            {
                return "Nothing";
            }
        }
    }
}
