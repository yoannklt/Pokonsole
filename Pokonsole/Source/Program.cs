using Pokonsole.Source.Core;
using Pokonsole.Source.Map;
using Pokonsole.Source.Pokemon;

public class Program
{
    // ENTRY POINT
    public static void Main(string[] args)
    {
        GameManager game = new GameManager();

        game._Map.PlaceTile(TileType.PLAYER, game._Player._PosX, game._Player._PosY);

        game.Draw();

        while(game._Running)
        {
            GameManager gameManager = new GameManager();
            CapacityManager cm = new CapacityManager();
            Capacity DanseLame = new Capacity("Danse Lame", POKEMON_TYPE.NORMAL, 50, 50);
            
            cm.addDico("Danse Lame", DanseLame);

 

            game.HandleEvent();
            game.Update();
            game.Draw();   
        }
        game.Quit();
    }
    
    // VARIABLES MEMBRES
}