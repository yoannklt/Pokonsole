using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Pokonsole.Source.Pokemons;

namespace Pokonsole.Source.Pokemons
{
    internal class CapacityManager
    {
        private string FilePath { get; }
        private Dictionary<int, Capacity> capacities; // Utilisez un int comme clé pour l'identifiant unique de la capacité

        public IReadOnlyDictionary<int, Capacity> Capacities { get => capacities; }

        public CapacityManager()
        {
            FilePath = "../../../Source/Data/Capacities.json";
            capacities = new Dictionary<int, Capacity>(); // Utilisez un int comme clé pour l'identifiant unique de la capacité
            //LoadCapacities();
        }

        //private void LoadCapacities()
        //{
        //    try
        //    {
        //        if (File.Exists(FilePath))
        //        {
        //            string jsonString = File.ReadAllText(FilePath);
        //            List<Capacity> capacityList = JsonSerializer.Deserialize<List<Capacity>>(jsonString);

        //            foreach (Capacity capacity in capacityList)
        //            {
        //                capacities.Add(capacity.Id, capacity); // Utilisez l'identifiant unique comme clé
        //            }
        //        }
        //        else
        //        {
        //            Console.WriteLine("Capacities data file not found.");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Error loading capacities data: {ex.Message}");
        //    }
        //}

        public Capacity CreateNewCapacity(string Name, POKEMON_TYPE type, int Power, int Precision)
        {
            // Générez un identifiant unique pour la nouvelle capacité
            int newId = capacities.Count + 1;
            Capacity c = new Capacity(newId, Name, type, Power, Precision);
            capacities.Add(newId, c);
            return c;
        }

        public Capacity CreateNewCapacity(string Name, POKEMON_TYPE type, int Power, int Precision, POKEMON_STATUS status)
        {
            // Générez un identifiant unique pour la nouvelle capacité
            int newId = capacities.Count + 1;
            Capacity c = new Capacity(newId, Name, type, Power, Precision, status);
            capacities.Add(newId, c);
            return c;
        }
    }
}
