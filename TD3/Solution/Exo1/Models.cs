using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
namespace TD3.Common
{

    public class Constants
    {
        public static string API_KEY = "506ea36334c773ea47580c2a68150a6ad298e269";

    }

    
    public class Contract
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("commercial_name")]
        public string CommercialName { get; set; }
        [JsonPropertyName("cities")]
        public List<string> Cities { get; set; }
        [JsonPropertyName("country_code")]
        public string CountryCode { get; set; }

        public override string ToString()
        {
            return $@"Contract {Name} {CommercialName} {Cities} {CountryCode}";
        }
    }

    public class Position
    {
        [JsonPropertyName("latitude")]
        
        public double Latitude { get; set; }

        [JsonPropertyName("longitude")]
        public double Longitude { get; set; }

        public override string ToString()
        {
            return $"Position (Lat: {Latitude}, Long: {Longitude} )";
        }


    }

    public class PositionInList
    {
        [JsonPropertyName("lat")]

        public double Latitude { get; set; }

        [JsonPropertyName("lng")]
        public double Longitude { get; set; }

        public override string ToString()
        {
            return $"Position (Latitude: {Latitude}, Longitude: {Longitude} )";
        }
    }

    public class Shape
    {

    }

    /*
     {"number":5,"contractName":"rouen","name":"05- HOTEL DE VILLE","address":"RUE DE L HOPITAL",
    "position":{"latitude":49.44250558644192,"longitude":1.098266338219107},
    "banking":true,"bonus":false,"status":"OPEN","lastUpdate":"2021-02-23T13:30:27Z","connected":true,
    "overflow":false,"shape":null,"totalStands":
    {"availabilities":{"bikes":16,"stands":4,"mechanicalBikes":16,"electricalBikes":0,"electricalInternalBatteryBikes":0,
    "electricalRemovableBatteryBikes":0},"capacity":20},
    "mainStands":{"availabilities":{"bikes":16,"stands":4,"mechanicalBikes":16,"electricalBikes":0,
    "electricalInternalBatteryBikes":0,"electricalRemovableBatteryBikes":0},"capacity":20},"overflowStands":null}
     */

    public class StationInList
    {
        [JsonPropertyName("number")]
        public int Number { get; set; }
        [JsonPropertyName("contractName")]
        public string ContractName { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
        

        [JsonPropertyName("position")]
        public PositionInList Position { get; set; }

        public override string ToString()
        {
            return $@"Station ( 
                Numéro: {Number}
                Nom: {Name}
                Nom du contrat: {ContractName}
                Position: {Position}
               )

            ";
        }
    }
    public class Station
    {
        [JsonPropertyName("number")]
        public int Number { get; set; }
        [JsonPropertyName("contractName")]
        public string ContractName { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("address")]
        public string Address { get; set; }

        [JsonPropertyName("position")]
        public Position Position { get; set; }

        [JsonPropertyName("banking")]

        public bool Banking { get; set; }

        [JsonPropertyName("bonus")]
        public bool Bonus { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("lastUpdate")]
        public string LastUpdate { get; set; }

        [JsonPropertyName("connected")]
        public bool Connected { get; set; }

        [JsonPropertyName("overflow")]

        public bool Overflow { get; set; }

        public override string ToString()
        {
            return $@"Station ( 
                Numéro: {Number}
                Nom: {Name}
                Nom du contrat: {ContractName}
                Adresse: {Address}
                Position: {Position}
               )

            ";
        }
    }
}