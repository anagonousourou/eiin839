using System;

namespace ExeTest
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 1)
                Console.WriteLine(args[0]);
            else
                Console.WriteLine($"<HTML><BODY> Hello I am the executable <br> {args[0]} + {args[1]} = {Int32.Parse(args[0]) + Int32.Parse( args[1])} </BODY></HTML>");
        }
    }
}
