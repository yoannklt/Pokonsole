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
        pokemonManager.createNewPokemon("Arcanin", POKEMON_TYPE.FIRE, 50, 100, 60, 60, 100, 100, 100, 100);
        pokemonManager.createNewPokemon("Charmander", POKEMON_TYPE.FIRE, 50, 100, 60, 60, 100, 100, 100, 100);
        //pokemonManager.saveJsonPokemons();
        pokemonManager.loadJsonPokemons();
        Console.WriteLine(pokemonManager.ListAllPokemons[0]._Name);

        /* while (game._Running)
         {
             game.HandleEvent();
             game.Update();
             game.Draw();   
         }*/
        game.Quit();
    }
    
    // VARIABLES MEMBRES
}