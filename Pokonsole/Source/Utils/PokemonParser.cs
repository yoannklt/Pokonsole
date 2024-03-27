using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Pokonsole.Source.Pokemons
{
    internal class PokemonParser
    {
        private string FilePath { get; }

        public PokemonParser()
        {
            FilePath = "../../../Source/Data/PokemonList.json";
        }

        public List<Pokemon> LoadPokemons()
        {
            try
            {
                if (File.Exists(FilePath))
                {
                    string jsonString = File.ReadAllText(FilePath);
                    return JsonSerializer.Deserialize<List<Pokemon>>(jsonString);
                }
                else
                {
                    //Console.WriteLine("Pokémon data file not found.");
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine($"Error loading Pokémon data: {ex.Message}");
            }

            return new List<Pokemon>();
        }

        public void SavePokemons(List<Pokemon> pokemons)
        {
            try
            {
                string jsonString = JsonSerializer.Serialize(pokemons);
                File.WriteAllText(FilePath, jsonString);
                //Console.WriteLine("Pokémon data saved successfully.");
            }
            catch (Exception ex)
            {
                //Console.WriteLine($"Failed to save Pokémon data: {ex.Message}");
            }
        }
    }
}
