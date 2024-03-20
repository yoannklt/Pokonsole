using Pokonsole.Source.Core;
using Pokonsole.Source.Mapping;

public class Program
{
    // ENTRY POINT
    public static void Main(string[] args)
    {
        Console.CursorVisible = false;
        GameManager game = new GameManager();

        game.Map.LoadMap();
        game.Map.PlaceTile(TileType.PLAYER, game.Player.Position.X, game.Player.Position.Y);
        game.Draw();

        while(game._Running)
        {
            game.HandleEvent();
            game.Update();  
        }
        game.Quit();
    }
}