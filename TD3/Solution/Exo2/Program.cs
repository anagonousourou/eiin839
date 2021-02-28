using TD3.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;

namespace Exo2
{
    class Program
    {
        static readonly JcDecaux jc = new JcDecaux();
        static void Main(string[] args)
        {
            string contractName;
             
            if (args.Length < 2)
            {
                Console.Write("Entrez le nom du contrat dont vous voulez les stations: ");
                contractName = Console.ReadLine();
                
                
            }
            else
            {
                contractName= args[1];
            }

            List<Station>  stations = jc.FindStationsByContract(contractName).Result;
            foreach (var st in stations)
            {
                Console.WriteLine(st.Name);
            }
        }


        
    }
}
