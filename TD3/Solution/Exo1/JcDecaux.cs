
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;



namespace TD3.Common
{
    public class JcDecaux
    {
        private readonly HttpClient client = new HttpClient();
        public async Task<List<Contract>> FindAllContracts()
        {
            
            string responseBody = await client.GetStringAsync($"https://api.jcdecaux.com/vls/v1/contracts?&apiKey={Constants.API_KEY}");

            return JsonSerializer.Deserialize<List<Contract>>(responseBody);

            
        }


        public async Task<List<StationInList>> FindStationsByContract(string contractName)
        {
            string responseBody = await client.GetStringAsync($"https://api.jcdecaux.com/vls/v1/stations?contract={contractName}&apiKey={Constants.API_KEY}");

            return JsonSerializer.Deserialize<List<StationInList>>(responseBody);

        }

        
    }
}
