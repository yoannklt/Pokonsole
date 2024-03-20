using Pokonsole.Source.Mapping;

namespace Pokonsole.Source.Actors.Player
{
    internal class Player : Actor
    {
        public Player(ref Map map) : base(ref map)
        { 
        
        }

        public override string Interact()
        {
            TileType FacingTile = Map.Tile[Position.X + Direction.X, Position.Y + Direction.Y]._TileType;
            Console.Write("                                   ");
            Console.SetCursorPosition(0, Map.Size.Y + 3);

            switch (FacingTile)
            {
                case TileType.EMPTY:
                    return "There is nothing there";

                case TileType.WALL:
                    return "What a cool wall!";

                case TileType.TREE:
                    return "Wsh groot";

                case TileType.ENEMY:
                    return "AKHAAAAAAAAAAA!!";

                case TileType.ITEM:
                    return "Object collected: ";

                default:
                    return "";
            }
        }

        public void Update()
        {
            
        }
    }

}
