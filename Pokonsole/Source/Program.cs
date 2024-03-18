using Pokonsole.Source.Core;

public class Program
{
    // ENTRY POINT
    public static void Main(string[] args)
    {
        GameManager game = new GameManager();

        while(game.Running)
        {
            game.HandleEvent();
            game.Update();
            game.Draw();   
        }
        game.Quit();
    }
    
    // VARIABLES MEMBRES
}