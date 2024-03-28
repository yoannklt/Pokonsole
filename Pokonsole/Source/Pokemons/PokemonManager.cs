using System;
using System.Collections.Generic;
using Pokonsole.Source.Pokemons;
using Pokonsole.Source.Utils;

namespace Pokonsole.Source.Pokemons
{
    internal class PokemonManager
    {
        private PokemonParser parser;
        private CapacityManager capacityManager;

        public PokemonManager()
        {
            parser = new PokemonParser();
            capacityManager = new CapacityManager();
            ListAllPokemons = new List<Pokemon>();
        }

        // Charge les Pokémon à partir du fichier PokemonList.json
        public void LoadPokemons()
        {
            ListAllPokemons = parser.LoadPokemons();
        }

        // Charge les Pokémon avec les capacités associées
        // Charge les Pokémon avec les capacités associées
        //public void LoadPokemonsWithCapacities()
        //{
        //    List<Pokemon> pokemons = parser.LoadPokemons();

        //    foreach (Pokemon pokemon in pokemons)
        //    {
        //        List<Capacity> pokemonCapacities = new List<Capacity>();
        //        foreach (int capacityId in pokemon.CapacityList)
        //        {
        //            if (capacityManager.Capacities.ContainsKey(capacityId))
        //            {
        //                pokemonCapacities.Add(capacityManager.Capacities[capacityId]);
        //            }
        //            else
        //            {
        //                Console.WriteLine($"Capacité avec l'ID {capacityId} non trouvée pour le Pokémon {pokemon.Name}");
        //            }
        //        }
        //        pokemon.CapacityList = pokemonCapacities;
        //    }

        //    ListAllPokemons.AddRange(pokemons);
        //}

        public void SavePokemons()
        {
            parser.SavePokemons(ListAllPokemons);
        }

        public List<Pokemon> ListAllPokemons { get; set; }
    }
}
