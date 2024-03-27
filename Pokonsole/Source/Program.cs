using Pokonsole.Source.Core;
using Pokonsole.Source.Map;
using Pokonsole.Source.Pokemons;
using Pokonsole.Source.Systems;
using System.Xml.Linq;

public class Program
{
    // ENTRY POINT
    public static void Main(string[] args)
    {
        GameManager game = new GameManager();
        PokemonManager pokemonManager = new PokemonManager();

        //game._Map.PlaceTile(TileType.PLAYER, game._Player._PosX, game._Player._PosY);

        //game.Draw();
        Pokemon pokemon1 = new Pokemon("Salamèche", 100);
        Pokemon pokemon2 = new Pokemon("Carapuce", 100);
        Capacity secondCapa = new Capacity("Charge", POKEMON_TYPE.NORMAL, 1, 100);
        Capacity firstCapa = new Capacity("Poison", POKEMON_TYPE.POISON, 35, 50, POKEMON_STATUS.POISONED);
        Capacity thirdCapa = new Capacity("nomDefenseBuff", POKEMON_TYPE.NORMAL, 35, 50);

        //Console.WriteLine(firstCapa.Name);
        //Console.WriteLine(firstCapa.Type);
        //Console.WriteLine(firstCapa.Power);
        //Console.WriteLine(firstCapa.Accuracy);

        CapacityManager capaManager = new CapacityManager();
        Capacity Capa1 = capaManager.createNewCapacity("Danse Lame", POKEMON_TYPE.NORMAL, 20, 100);
        capaManager.addDico("Danse Lame", Capa1);
        //Console.WriteLine(capaManager.Capacitys["Danse Lame"].Name);
        /*firstCapa.CapacityDamage(pokemon1);*/
        CombatSystem combatSystem = new CombatSystem();
        combatSystem.CreateNewCombat(pokemon1, pokemon2);
        combatSystem.UseAbility(pokemon1, pokemon2, firstCapa);
        combatSystem.UseAbility(pokemon2, pokemon2, Capa1);
        combatSystem.UseAbility(pokemon1, pokemon1, firstCapa);

        while (game._Running)
        {
            game.HandleEvent();
            game.Update();
            game.Draw();   
        }
        //pokemonManager.CreateNewPokemon("Pikachu", POKEMON_TYPE.ELECTRIC, 35, 1, 55, 40, 90, 50, 50);
        //pokemonManager.SavePokemons();
        pokemonManager.LoadPokemons();
        Console.WriteLine(pokemonManager.ListAllPokemons[0].Name);
        game.Quit();
    }


    // VARIABLES MEMBRES
}