using Pokonsole.Source.Actors;
using Pokonsole.Source.Mapping;
using Pokonsole;
using System.Numerics;

namespace Pokonsole.Source.Core.GameState
{
    internal class GameState
    {

        public enum GAMESTATE
        {
            MAIN_MENU,
            GAME,
            COMBAT,
            INVENTORY,
            PAUSE,
            GAME_OVER
        }

        private readonly bool PausedMenu;
        bool MainmenuF;

        Menu MainMenu;
        public GAMESTATE _flag;
        int Selected = 0;

        public GameState()
        {
            _flag = GAMESTATE.MAIN_MENU;
            MainMenu = new();
            MainMenu.init();
            
        }

        public void GameStateCheck()
        {
            Update();
            HandleEvent();

        }
        public void HandleEvent()
        {

            Console.SetCursorPosition(0, MainMenu.buttons.Count + 1);
            ConsoleKeyInfo key = Console.ReadKey();

            switch (key.Key)
            {
                case ConsoleKey.S:
                    Selected += 1;
                    if (Selected > MainMenu.buttons.Count - 1)
                    {
                        Selected = 0;
                    }
                    break;

                case ConsoleKey.Z:
                    Selected -= 1;
                    if (Selected < 0)
                    {
                        Selected = MainMenu.buttons.Count - 1;
                    }
                    break;

                case ConsoleKey.Enter:
                    switch (MainMenu.buttons[Selected].mText)
                    {
                        case "NewGame":
                            MainmenuF = false;
                            // lancer jeu 
                            _flag = GAMESTATE.GAME;
                            Console.WriteLine("new game");
                            break;

                        case "Parameters":

                            // ouvrir parametre ? 
                            Console.WriteLine("param");
                            break;

                        case "LoadGame":
                            MainmenuF = false;
                            // charger save
                            
                            Console.WriteLine("chargement de la save");
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