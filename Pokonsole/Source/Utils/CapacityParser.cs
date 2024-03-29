using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Pokonsole.Source.Pokemons;

//namespace Pokonsole.Source.Utils
//{
//    internal class CapacityParser
//    {
//        private string FilePath { get; }

//        public CapacityParser()
//        {
//            FilePath = "../../../Source/Data/Capacities.json";
//        }

//        public List<Capacity> LoadCapacities()
//        {
//            try
//            {
//                if (File.Exists(FilePath))
//                {
//                    string jsonString = File.ReadAllText(FilePath);
//                    return JsonSerializer.Deserialize<List<Capacity>>(jsonString);
//                }
//                else
//                {
//                    Console.WriteLine("Capacities data file not found.");
//                }
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"Error loading capacities data: {ex.Message}");
//            }

//            return new List<Capacity>();
//        }
//    }
//}
