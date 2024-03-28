using Pokonsole.Source.Mapping;
using Pokonsole.Source.Utils;

namespace Pokonsole.Source.Actors.Player
{
    internal class Player : Actor
    {
        public Player(ref Map map) : base(ref map)
        {
            Position = new MathHelper.Vector2(1, 1);
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
                    return "AKHAAAAAAAAAAA!!";

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

                default:
                    return "";
            }
        }

        public void Update()
        {
            
        }
    }

}
