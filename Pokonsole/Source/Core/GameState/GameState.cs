using Pokonsole.Source.Actors.Player;
using Pokonsole.Source.Mapping;

namespace Pokonsole.Source.Core.GameState
{
    internal class GameState
    {
        private readonly bool PausedMenu;
        private readonly bool MainMenu;
        private readonly bool GameLoop;

        protected GameState() 
        {
            MainMenu = true;
            PausedMenu = false;
            GameLoop = false;
        }

        protected void GameStateCheck()
        {
            if (MainMenu == true ) 
            
            {
                
            }   
        }
        protected void Mainmenu()
        {
            while (MainMenu)
            {


                Console.SetCursorPosition(0, 0);
                ConsoleKeyInfo key = Console.ReadKey();

                switch (key.KeyChar)
                {
                    case 's':
                        Player.Move(0, 1);
                        break;

                    case 'z':
                        Player.Move(0, -1);
                        break;

                    case "":
                        Console.SetCursorPosition(0, Map.Size.Y + 3);
                        Console.Write(Player.Interact());
                        break;

                    default:
                        break;
                }
                Console.SetCursorPosition(0, Map.Size.Y + 2);
                Console.Write(" ");
                

            }
        }

        protected void MainMenudraw()
        {

        }

    }
}
