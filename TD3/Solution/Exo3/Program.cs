using System;
using System.Net.Http;
using TD3.Common;
using System.Text.Json;
using System.Threading.Tasks;

namespace Exo3
{
    class Program
    {
        static readonly HttpClient client = new HttpClient();
        static void Main(string[] args)
        {
            string contractName;
            string id;
            if(args.Length < 3)
            {
                Console.Write("Nom du contract: ");
                contractName = Console.ReadLine();
                Console.Write("Numéro de la station: ");
                id = Console.ReadLine();

                
            }
            else
            {
                contractName = args[1];
                id = args[2];
            }

            Console.WriteLine(GetStationByIdAndContractName(id, contractName).Result);
        }


        private async static Task<Station> GetStationByIdAndContractName(string id,string contractName)
        {

           string stationJson= await client.GetStringAsync($"https://api.jcdecaux.com/vls/v3/stations/{id}/?apiKey={Constants.API_KEY}&contract={contractName}");

            return JsonSerializer.Deserialize<Station>(stationJson);


        }
    }
}
