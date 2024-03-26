using Pokonsole.Source.Core;
using Pokonsole.Source.Map;
using Pokonsole.Source.Pokemon;
using System.Xml.Linq;

public class Program
{
    // ENTRY POINT
    public static void Main(string[] args)
    {
        GameManager game = new GameManager();
        PokemonManager pokemonManager = new PokemonManager();

        pokemonManager.CreateNewPokemon("Squirtel", POKEMON_TYPE.WATER, 35, 1, 55, 40, 90, 50, 50, 120);
        pokemonManager.SavePokemons();
        Console.WriteLine(pokemonManager.ListAllPokemons[0].Name);
        game.Quit();
    }


    // VARIABLES MEMBRES
}