using Pokonsole.Source.Core;
using Pokonsole.Source.Map;

public class Program
{
    // ENTRY POINT
    public static void Main(string[] args)
    {
        GameManager game = new GameManager();

        game._Map.LoadMap();
        game._Map.PlaceTile(TileType.PLAYER, game._Player._PosX, game._Player._PosY);

        game._Map.Draw();

        while(game._Running)
        {
            game.HandleEvent();
            game.Update();
            // game.Draw();   
        }
        game.Quit();
    }
}