using Pokonsole.Source.Core;
using Pokonsole.Source.Core.GameState;
using Pokonsole.Source.Mapping;
using Pokonsole.Source.Pokemons;
using System.Media;

public class Program
{
    // ENTRY POINT
    public static void Main(string[] args)
    {

        Console.CursorVisible = false;
        GameManager game = new GameManager();
        SoundPlayer mainMusic = new SoundPlayer("../../../Source/Utils/main_music.wav");
        GameState gameState = new GameState();
        game.Map.LoadMap();
        game.Map.PlaceTile(TileType.PLAYER, game.Player.Position.X, game.Player.Position.Y);
        game.Draw();

        while (gameState._flag != GameState.GAMESTATE.GAME_OVER)
        {
            switch (gameState._flag)
            {
                case GameState.GAMESTATE.MAIN_MENU:
                    gameState.GameStateCheck();
                    break;

                case GameState.GAMESTATE.GAME:

                        mainMusic.Play();
                    do
                    {
                        game.Update();
                        game.HandleEvent();
                    }
                    while (game._Running);
                    game.Quit();
                    break;

                case GameState.GAMESTATE.COMBAT:

                    break;

                case GameState.GAMESTATE.INVENTORY:

                    break;

                case GameState.GAMESTATE.PAUSE:

                    break;

                case GameState.GAMESTATE.GAME_OVER:

                    break;
            }
        }
        
    }
}