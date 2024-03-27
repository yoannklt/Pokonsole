using Pokonsole.Source.Mapping;
using Pokonsole.Source.Pokemons;
using Pokonsole.Source.Systems;

namespace Pokonsole.Source.Actors.Player
{
    internal class Player : Actor
    {
        PokemonManager _pkmnManager;
        public Player(ref Map map, PokemonManager pkmnManager) : base(ref map)
        { 
            _pkmnManager = pkmnManager;
        }

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
                    combatSystem.CreateNewCombat(_pkmnManager.ListAllPokemons[0], _pkmnManager.ListAllPokemons[random.Next(0, _pkmnManager.ListAllPokemons.Count)]) ;
                    return "";
                case TileType.ITEM:
                    return "Object collected: ";

                case TileType.WATER:
                    return "Wotah";

                default:
                    return "";
            }
        }

        public void Update()
        {
            
        }
    }

}
