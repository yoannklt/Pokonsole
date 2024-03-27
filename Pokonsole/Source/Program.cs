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
        pokemon1.AddCapacity(firstCapa);
        pokemon1.AddCapacity(secondCapa);
        //pokemon1.AddCapacity(Capa1);
        //pokemon1.AddCapacity(thirdCapa);
        //pokemon1.AddCapacity("Charge");
        //pokemon1.AddCapacity("Flamèche");
        //pokemon1.AddCapacity("Vive attaque");
        //Console.WriteLine(capaManager.Capacitys["Danse Lame"].Name);
        /*firstCapa.CapacityDamage(pokemon1);*/
        CombatSystem combatSystem = new CombatSystem();
        combatSystem.CreateNewCombat(pokemon1, pokemon2);
        //combatSystem.UseAbility(pokemon1, pokemon2, firstCapa);
        //combatSystem.UseAbility(pokemon2, pokemon2, capaManager.Capacitys["Danse Lame"]);
        //combatSystem.UseAbility(pokemon1, pokemon1, firstCapa);

        while (game._Running)
        {
            game.HandleEvent();
            game.Update();
            game.Draw();   
        }
        game.Quit();
    }
    
    // VARIABLES MEMBRES
}