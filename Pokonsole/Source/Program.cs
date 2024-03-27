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

        //pokemonManager.CreateNewPokemon("Pikachu", POKEMON_TYPE.ELECTRIC, 35, 1, 55, 40, 90, 50, 50);
        //pokemonManager.SavePokemons();
        pokemonManager.LoadPokemons();
        Console.WriteLine(pokemonManager.ListAllPokemons[0].Name);
        game.Quit();
    }


    // VARIABLES MEMBRES
}