using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Pokonsole.Source.Pokemon
{
    internal class PokemonJsonParser
    {
        public List<Dictionary<string, object>> ParsePokemonList(string filePath)
        {
            List<Dictionary<string, object>> pokemonList = new List<Dictionary<string, object>>();

            try
            {
                string jsonContent = File.ReadAllText(filePath);

                JsonDocument doc = JsonDocument.Parse(jsonContent);
                JsonElement root = doc.RootElement;
                JsonElement pokemonListElement = root.GetProperty("PokemonList");

                foreach (JsonElement pokemonElement in pokemonListElement.EnumerateArray())
                {
                    Dictionary<string, object> pokemonData = ParsePokemon(pokemonElement);
                    if (pokemonData != null)
                    {
                        pokemonList.Add(pokemonData);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de l'analyse du fichier JSON : " + ex.Message);
            }

            return pokemonList;
        }

        private Dictionary<string, object> ParsePokemon(JsonElement pokemonElement)
        {
            Dictionary<string, object> pokemonData = null;

            try
            {

                string name = pokemonElement.GetProperty("name").GetString();
                JsonElement typeElement = pokemonElement.GetProperty("type");
                List<string> types = new List<string>();
                foreach (JsonElement type in typeElement.EnumerateArray())
                {
                    types.Add(type.GetString());
                }

                JsonElement statsElement = pokemonElement.GetProperty("statistics");
                Dictionary<string, object> stats = new Dictionary<string, object>();
                foreach (JsonProperty stat in statsElement.EnumerateObject())
                {
                    stats.Add(stat.Name, stat.Value);
                }

                pokemonData = new Dictionary<string, object>()
                {
                    { "name", name },
                    { "type", types },
                    { "statistics", stats }
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de l'analyse des données d'un Pokémon : " + ex.Message);
            }

            return pokemonData;
        }
    }
}
