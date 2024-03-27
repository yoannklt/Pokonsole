using Pokonsole.Source.Player;
using Pokonsole.Source.Map;
using Pokonsole;
using System.Numerics;

namespace Pokonsole.Source.Core.GameState
{
    internal class GameState
    {
        private readonly bool PausedMenu;
        bool MainmenuF;

        Menu MainMenu;
        int Selected = 0;

        public GameState()
        {
            MainmenuF = true;
            MainMenu = new();
            MainMenu.init();
            PausedMenu = false;
        }

        public void GameStateCheck()
        {
            Update();
            while (MainmenuF == true)

            {
                HandleEvent();
                Update();
            }

            while (PausedMenu == true)

            {

            }
        }
        public void HandleEvent()
        {

            Console.SetCursorPosition(0, MainMenu.buttons.Count + 1);
            ConsoleKeyInfo key = Console.ReadKey();

            switch (key.Key)
            {
                case ConsoleKey.S:
                    Selected += 1;
                    if (Selected > MainMenu.buttons.Count -1)
                    {
                        Selected = 0;
                    }
                    break;

                case ConsoleKey.Z:
                    Selected -= 1;
                    if (Selected < 0)
                    {
                        Selected = MainMenu.buttons.Count -1;
                    }
                    break;

                case ConsoleKey.Enter:
                    switch (MainMenu.buttons[Selected].mText)
                    {
                        case "New Game":
                            MainmenuF = false;
                            // lancer jeu 
                            break;

                        case "Parameters ":
                            
                            // ouvrir parametre ? 
                            break;

                        case "Load Game":
                            MainmenuF = false;
                            // charger save
                            break;

                        default:
                            break;

                    }
                    
                    break;

                default:
                    break;
            }
        }

        public void Update()
        {
            MainMenu.Draw(Selected);
        }

    }
}
