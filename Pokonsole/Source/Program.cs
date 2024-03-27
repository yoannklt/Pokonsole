using Pokonsole.Source.Core;
using Pokonsole.Source.Core.GameState;
using Pokonsole.Source.Map;
using Pokonsole.Source.Pokemon;

public class Program
{
    // ENTRY POINT
    public static void Main(string[] args)
    {
        Console.CursorVisible = false;
        GameManager game = new GameManager();
        GameState State = new();

        game._Map.LoadMap();
        game._Map.PlaceTile(TileType.PLAYER, game._Player._PosX, game._Player._PosY);

        //game._Map.Draw();

        while(game._Running)
        {
            GameManager gameManager = new GameManager();
            CapacityManager cm = new CapacityManager();
            Capacity DanseLame = new Capacity("Danse Lame", POKEMON_TYPE.NORMAL, 50, 50);
            
            cm.addDico("Danse Lame", DanseLame);



            


            
            State.GameStateCheck();

            //game.HandleEvent();
            //game.Update();
            //game.Draw();

        }
        game.Quit();
    }
}