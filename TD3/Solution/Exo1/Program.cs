using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TD3.Common;
namespace Exo1
{

    

    class Program
    {
        static readonly JcDecaux jc = new JcDecaux();

        static void Main()
        {
                List<Contract> contracts = jc.FindAllContracts().Result;
                foreach(var contract in contracts)
                {
                    Console.WriteLine(contract.Name);
                }

            
            
        }
    
    }
}
