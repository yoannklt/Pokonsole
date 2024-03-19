namespace Pokonsole.Source.Core
{
    internal class GameManager
    {
        // CONSTRUCTOR
        public GameManager() {}

        // METHODS
        public void HandleEvent()
        {
            Console.SetCursorPosition(0, _Map._Size + 2);
            ConsoleKeyInfo key = Console.ReadKey();
            
            switch (key.KeyChar)
            {
                case 'q':
                    _Player.Move(-1, 0, ref _Map); 
                    break;

                case 's':
                    _Player.Move(0, 1, ref _Map);
                    break; 

                case 'd':
                    _Player.Move(1, 0, ref _Map);
                    break;

                case 'z':
                    _Player.Move(0, -1, ref _Map);
                    break;

                case 'e':
                    Console.SetCursorPosition(0, _Map._Size + 3);
                    Console.Write(_Player.Interact(ref _Map));
                    break;

                default:
                    break;
            }

            Console.Write(" ");
        }
        public void Update()
        {
            _Map.Update();
        }
        public void Draw()
        {
        }
        public void Quit() { }

        // VARIABLES MEMBRES
        public bool _Running = true;

        // CLASSES
        public Player.Player _Player = new();
        private Pokemon.PokemonManager _PokemonManager = new();
        public Map.Map _Map = new(20);
    }
}
