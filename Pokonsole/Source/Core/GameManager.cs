
using Pokonsole.Source.Map;

namespace Pokonsole.Source.Core
{
    internal class GameManager
    {
        // CONSTRUCTOR
        public GameManager() {}

        // METHODS
        public void HandleEvent()
        {
            ConsoleKeyInfo key = Console.ReadKey();
            switch (key.KeyChar)
            {
                case 'Z':
                    _Map.ClearTile(_Player._PosX, _Player._PosY + 1); 
                    _Player.Move(0, -1, _Map._Size); 
                    break;

                case 'Q':
                    _Map.ClearTile(_Player._PosX + 1, _Player._PosY);
                    _Player.Move(-1, 0, _Map._Size);
                    break; 

                case 'S':
                    _Map.ClearTile(_Player._PosX, _Player._PosY - 1);
                    _Player.Move(0, 1, _Map._Size);
                    break;

                case 'D':
                    _Map.ClearTile(_Player._PosX - 1, _Player._PosY - 1);
                    _Player.Move(1, 0, _Map._Size);
                    break;

                default:
                    break;
            }
        }
        public void Update()
        {
            _Map.PlaceTile(Map.TileType.PLAYER, _Player._PosX, _Player._PosY);
        }
        public void Draw()
        {
            _Map.Draw();        
        }
        public void Quit() { }
        public bool IsRunning() { return _Running; }
        // VARIABLES MEMBRES
        public bool _Running = true;

        // CLASSES
        public Player.Player _Player = new();
        //Pokemon.PokemonManager _PokemonManager = new();
        public Map.Map _Map = new(20);
    }
}
