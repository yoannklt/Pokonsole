using System;
using System.Collections.Generic;

namespace Pokonsole.Source.Pokemon
{
    internal class PokemonManager
    {
        private PokemonParser parser;

        public PokemonManager()
        {
            parser = new PokemonParser();
            ListAllPokemons = new List<Pokemon>();
        }

        public void CreateNewPokemon(string pokemonName, POKEMON_TYPE type, int hp, int level, int attack, int defense, int speed, int specialAttack, int specialDefense, int accuracy)
        {
            Pokemon newPokemon = new Pokemon(pokemonName, type, hp, level, attack, defense, speed, specialAttack, specialDefense, accuracy);
            ListAllPokemons.Add(newPokemon);
        }

        public void RemovePokemon(string pokemonName)
        {
            Pokemon pokemonToRemove = ListAllPokemons.Find(p => p.Name == pokemonName);

            if (pokemonToRemove != null)
            {
                ListAllPokemons.Remove(pokemonToRemove);
                //Console.WriteLine($"Pokemon '{pokemonName}' removed successfully.");
            }
            else
            {
                //Console.WriteLine($"Pokemon '{pokemonName}' not found.");
            }
        }

        public void SavePokemons()
        {
            parser.SavePokemons(ListAllPokemons);
        }

        public void LoadPokemons()
        {
            ListAllPokemons = parser.LoadPokemons();
        }

        public List<Pokemon> ListAllPokemons { get; set; }
    }
}
