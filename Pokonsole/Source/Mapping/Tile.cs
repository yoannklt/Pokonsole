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
        TOTAL_TILE_TYPE
    }

    internal class Tile
    {
        public Tile(TileType tileType) => Type = tileType;

        public string GetString()
        {
            switch (Type)
            {
                case TileType.BUSH:
                    return "B";

                case TileType.POKEMON:
                    return "P";

                case TileType.EMPTY:
                    return ".";

                case TileType.WALL:
                    return "|";

                case TileType.TREE:
                    return "T";

                case TileType.ENEMY:
                    return "E";

                case TileType.PLAYER:
                    return "P";

                case TileType.ITEM:
                    return "O";

                case TileType.HORIZONTAL_WALL:
                    return "_";

                default:
                    return " ";
            }
        }

        public TileType TileType { get => Type; set { Type = value; } }

        private TileType Type;
    }
}
