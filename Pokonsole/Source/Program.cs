using Pokonsole.Source.Core;
using Pokonsole.Source.Map;
using Pokonsole.Source.Pokemons;
using System.Xml.Linq;

public class Program
{
    // ENTRY POINT
    public static void Main(string[] args)
    {
        GameManager game = new GameManager();

        //game._Map.PlaceTile(TileType.PLAYER, game._Player._PosX, game._Player._PosY);

        //game.Draw();
        Pokemon pokemon1 = new Pokemon();
        //Capacity firstCapa = new Capacity("Charge", POKEMON_TYPE.NORMAL, 1, 100);
        Capacity firstCapa = new Capacity("Poison", POKEMON_TYPE.POISON, 35, 50, POKEMON_STATUS.POISONED);
        Console.WriteLine(firstCapa.Name);
        Console.WriteLine(firstCapa.Type);
        Console.WriteLine(firstCapa.Power);
        Console.WriteLine(firstCapa.Accuracy);

        CapacityManager capaManager = new CapacityManager();
        Capacity Capa1 = capaManager.createNewCapacity("Danse Lame", POKEMON_TYPE.NORMAL, 20, 100);
        capaManager.addDico("Danse Lame", Capa1);
        Console.WriteLine(capaManager.Capacitys["Danse Lame"].Name);
        firstCapa.CapacityDamage(pokemon1);

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