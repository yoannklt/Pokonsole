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

        //game._Map.PlaceTile(TileType.PLAYER, game._Player._PosX, game._Player._PosY);

        //game.Draw();
        Pokemon pokemon1 = new Pokemon();
        Capacity firstCapa = new Capacity("Charge", POKEMON_TYPE.NORMAL, 40, 100);
        //Capacity secCapa = new Capacity("Poison", POKEMON_TYPE.POISON, 35, 100, POKEMON_STATUS.POISONED);
        Console.WriteLine(firstCapa.Name);
        Console.WriteLine(firstCapa.Type);
        Console.WriteLine(firstCapa.Power);
        Console.WriteLine(firstCapa.Accuracy);
       /* Console.WriteLine(secCapa.Name);
        Console.WriteLine(secCapa.Type);
        Console.WriteLine(secCapa.Power);
        Console.WriteLine(secCapa.Accuracy);
        Console.WriteLine(secCapa.Status);*/

        CapacityManager capaManager = new CapacityManager();
        capaManager.createNewCapacity("Danse Lame", POKEMON_TYPE.NORMAL, 20, 100);
        capaManager.createNewCapacity("Danse Lame", POKEMON_TYPE.NORMAL, 20, 100);
        capaManager.createNewCapacity("Danse Lame", POKEMON_TYPE.NORMAL, 20, 100);
        capaManager.createNewCapacity("Danse Lame", POKEMON_TYPE.NORMAL, 20, 100);
        capaManager.createNewCapacity("Danse Lame", POKEMON_TYPE.NORMAL, 20, 100);
        Console.WriteLine(capaManager.CapacityCreated);

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