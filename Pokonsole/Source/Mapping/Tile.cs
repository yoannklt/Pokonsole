using System.Security.AccessControl;

namespace Pokonsole.Source.Mapping
{
    public enum TileType
    {
        None = 0,
        ANGULAR_WALL,
        BUSH,
        DOOR,
        EMPTY,
        ENEMY,
        HORIZONTAL_WALL,
        HOUSE_WALL,
        FLOOR,
        ITEM,
        TREE,
        PLAYER,
        POKEMON,
        ROOF,
        SECOND_ROOF,
        WALL,
        WATER,
        TOTAL_TILE_TYPE
    }

    internal class Tile
    {
        public Tile(TileType tileType) => Type = tileType;

        public string GetString()
        {
            switch (Type)
            {
                case TileType.EMPTY:
                    Console.BackgroundColor = ConsoleColor.Green;
                    return " ";

                case TileType.WALL:
                    Console.BackgroundColor = ConsoleColor.White;
                    return " ";

                case TileType.FLOOR:
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    return " ";

                case TileType.POKEMON:
                    Console.BackgroundColor = ConsoleColor.Red;
                    return " ";

                case TileType.ROOF:
                    Console.BackgroundColor = ConsoleColor.Red;
                    return " ";

                case TileType.SECOND_ROOF:
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    return " ";

                case TileType.HOUSE_WALL:
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    return " ";

                case TileType.DOOR:
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    return " ";

                case TileType.PLAYER:
                    Console.BackgroundColor = ConsoleColor.Magenta;
                    return " ";

                default:
                    return " ";
            }
        }

        public void ChangeColor(ConsoleColor color)
        {
            Console.BackgroundColor = color;
        }

        public TileType TileType { get => Type; set { Type = value; } }

        private TileType Type;
    }
}
