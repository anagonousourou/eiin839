using GeoCoordinatePortable;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TD3.Common;

namespace Exo4
{
    class Program
    {
        static readonly JcDecaux jc = new JcDecaux();
        static void Main(string[] args)
        {
            string contractName;
            double lat;
            double longitude;
            if(args.Length < 4)
            {
                Console.WriteLine("En cas de FormatException essayez d'utilisez la virgule au lieu du point");
                Console.Write("Nom du contrat: ");
                contractName=Console.ReadLine();
                Console.Write("Latitude recherchée: ");
                lat = double.Parse(Console.ReadLine());
                Console.Write("Longitude recherchée: ");
                longitude = double.Parse(Console.ReadLine());
            }
            else
            {
                contractName = args[1];
                lat = double.Parse(args[2]);
                longitude=double.Parse(args[3]);
            }


            Console.WriteLine($"The closest station is {FindStationByContractNear(contractName, new GeoCoordinate(lat, longitude ))}");
        }

        public static StationInList FindStationByContractNear(string contractName, GeoCoordinate coordinate)
        {
            List<StationInList> stations = jc.FindStationsByContract(contractName).Result;

            StationInList closest = null;

            foreach (var st in stations)
            {
                if (closest == null)
                {
                    closest = st;
                }
                else
                {
                    var stCoord = new GeoCoordinate(st.Position.Latitude, st.Position.Longitude);
                    var closestCoord = new GeoCoordinate(closest.Position.Latitude, st.Position.Longitude);

                    if (stCoord.GetDistanceTo(coordinate) < coordinate.GetDistanceTo(closestCoord))
                    {

                        closest = st;
                    }
                }
            }
            return closest;

        }
    }
}
