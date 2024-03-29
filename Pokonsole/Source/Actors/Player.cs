using Pokonsole.Source.Accessories;
using Pokonsole.Source.Items.Balls;
using Pokonsole.Source.Items.Potions;
using Pokonsole.Source.Mapping;
using Pokonsole.Source.Utils;
using Pokonsole.Source.Pokemons;
using Pokonsole.Source.Systems;

namespace Pokonsole.Source.Actors.Player
{
    internal class Player : Actor
    {
        PokemonManager _pkmnManager;
        public List<Pokemon> _myPokemons;
        public Player(ref Map map, PokemonManager pkmnManager) : base(ref map)
        { 
            _pkmnManager = pkmnManager;
            _myPokemons = new List<Pokemon>();
            Inventory = new Inventory();
            Inventory.AddItem(new StandardPotion());
            Inventory.AddItem(new StandardPotion());
            Inventory.AddItem(new Pokeball());
            Position = new MathHelper.Vector2(1, 1);
        }
        public Inventory Inventory { get { return _Inventory; } set => _Inventory = value; }
        private Inventory _Inventory;

        public override string Interact()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            TileType FacingTile = Map.Tile[Position.X + Direction.X, Position.Y + Direction.Y].TileType; 
            Console.Write("                                   ");
            Console.SetCursorPosition(0, Map.Size.Y + 3);

            switch (FacingTile)
            {
                case TileType.EMPTY:
                    return "";

                case TileType.WALL:
                    return "What a cool wall!";

                case TileType.TREE:
                    return "Wsh groot";

                case TileType.ENEMY:
                    CombatSystem combatSystem = new CombatSystem();
                    var random = new Random();
                    combatSystem.CreateNewCombat(this, this._myPokemons[0], _pkmnManager.ListAllPokemons[random.Next(0, _pkmnManager.ListAllPokemons.Count)]) ;
                    return "";
                case TileType.ITEM:
                    return "Object collected: ";

                case TileType.WATER:
                    return "Wotah";

                case TileType.DOOR:
                    if (Map.Version == 1)
                    {
                        Map.LoadSecMap();
                        SetPosition(10, 15);
                    }
                    else
                    {
                        Map.LoadMap();
                        SetPosition(10, 19);
                    }
                    return "";
                case TileType.POKEMON:
                    var randomPokemon = new Random();
                    this._myPokemons.Add(_pkmnManager.ListAllPokemons[randomPokemon.Next(0, _pkmnManager.ListAllPokemons.Count)]);
                    for (int i = 0; i < this._myPokemons.Count(); i++)
                    {
                        Console.SetCursorPosition(this.Map.Size.X * 2 + 4, i + 1);
                        Console.Write(this._myPokemons[i].Name);
                    } ;
                    return "";

                default:
                    return "";
            }
        }

        public void Update()
        {
            
        }
    }

}
