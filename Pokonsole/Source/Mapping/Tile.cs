using System.Security.AccessControl;

namespace Pokonsole.Source.Mapping
{
    public enum TileType
    {
        None = 0,
        ANGULAR_WALL,
        BUSH,
        EMPTY,
        ENEMY,
        HORIZONTAL_WALL,
        ITEM,
        TREE,
        PLAYER,
        POKEMON,
        WALL,
        WATER,
        TOTAL_TILE_TYPE
    }

    internal class Tile
    {
        public Tile(TileType tileType) => Type = tileType;

        public string GetString()
        {
            Console.ForegroundColor = ConsoleColor.White;
            switch (Type)
            {
                case TileType.BUSH:
                    Console.BackgroundColor = ConsoleColor.Green;
                    return " ";

                case TileType.POKEMON:
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    return " ";

                case TileType.EMPTY:
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    return " ";

                case TileType.WALL:
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    return " ";

                case TileType.TREE:
                    Console.BackgroundColor = ConsoleColor.Green;
                    return " ";

                case TileType.ENEMY:
                    Console.BackgroundColor = ConsoleColor.Red;
                    return " ";

                case TileType.PLAYER:
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    return " ";

                case TileType.ITEM:
                    Console.BackgroundColor = ConsoleColor.DarkMagenta;
                    return " ";

                case TileType.HORIZONTAL_WALL:
                    Console.BackgroundColor = ConsoleColor.Black;
                    return " ";

                case TileType.WATER:
                    Console.BackgroundColor = ConsoleColor.Blue;
                    return " ";

                default:
                    return "";
            }
        }

        public TileType TileType { get => Type; set { Type = value; } }

        private TileType Type;
    }
}
