
using Pokonsole.Source.Mapping;
using Pokonsole.Source.Actors.Player;
using Pokonsole.Source.Accessories;
using Pokonsole.Source.Items.Potions;
using Pokonsole.Source.Items.Balls;
using Pokonsole.Source.Pokemons;

namespace Pokonsole.Source.Core
{
    internal class GameManager
    {

        PokemonManager _pokemonManager;
        // CONSTRUCTOR
        public GameManager() 
        {
            _pokemonManager = new PokemonManager();
            _pokemonManager.LoadPokemons();
            //Console.WriteLine(pokemonManager.ListAllPokemons[0].Name);

            Map = new Map(20, 20);
            Player = new Player(ref rMap, _pokemonManager);
            Inventory = new Inventory();
           
        }

        // METHODS
        public void HandleEvent()
        {
            Console.SetCursorPosition(0, Map.Size.Y + 2);
            ConsoleKeyInfo key = Console.ReadKey();
            
            switch (key.KeyChar)
            {
                case 'q':
                    Player.Move(-1, 0); 
                    break;

                case 's':
                    Player.Move(0, 1);
                    break; 

                case 'd':
                    Player.Move(1, 0);
                    break;

                case 'z':
                    Player.Move(0, -1);
                    break;

                case 'e':
                    Console.SetCursorPosition(0, Map.Size.Y + 3);
                    Console.Write(Player.Interact());
                    break;

                default:
                    break;
            }
            Console.SetCursorPosition(0, Map.Size.Y + 2);
            Console.Write(" ");
        }
        public void Update()
        {
            Map.Update();
            Player.Update();
        }
        public void Draw()
        {
            Map.Draw();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(0, Map.Size.Y + 4);
            //Console.WriteLine(Inventory.Items[0].ItemData.Name + " " + Inventory.Items[0].Amount);
            //Console.WriteLine(Inventory.Items[1].ItemData.Name + " " + Inventory.Items[1].Amount);
        }
        public void Quit() { }

        // VARIABLES MEMBRES
        public bool _Running = true;

        // CLASSES
        private Map? _Map;
        private Player? _Player;
        public Map Map { get { return _Map; } set => _Map = value; }
        public ref Map rMap { get { return ref _Map; }}
        public Player Player { get { return _Player; } set => _Player = value; }
        private Inventory? _Inventory;
        public Inventory Inventory { get { return _Inventory; } set => _Inventory = value; }
    }
}
