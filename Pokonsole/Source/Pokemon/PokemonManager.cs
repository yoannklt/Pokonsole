using Pokonsole.Source.Pokemon;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Collections.Generic;


namespace Pokonsole.Source.Pokemon
{
    internal class PokemonManager
    {
        public PokemonManager()
        {
            ListAllPokemons = new List<Pokemon>();
        }

        public void createNewPokemon(string name, POKEMON_TYPE type, int hp, int level, int attack, int defense, int speed, int specialAttack, int specialDefense, int accuracy)
        {
            Pokemon Name = new Pokemon(name, type, hp, level, attack, defense, speed, specialAttack, specialDefense, accuracy);
            ListAllPokemons.Add(Name);
        }

        public void saveJsonPokemons()
        {
            string jsonString = JsonSerializer.Serialize(ListAllPokemons);
            System.IO.File.WriteAllText("../../../Source/Data/PokemonList.json", jsonString);
        }

        public void loadJsonPokemons()
        {
            string jsonString1 = System.IO.File.ReadAllText("../../../Source/Data/PokemonList.json");
            ListAllPokemons = JsonSerializer.Deserialize<List<Pokemon>>(jsonString1);

        }


        //METHODES GETTER / SETTER
        public List<Pokemon> ListAllPokemons { get => _listAllPokemons; set => _listAllPokemons = value; }
        //VARIABLES PRIVEES
        private List<Pokemon> _listAllPokemons;

    }
}
