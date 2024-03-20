namespace Pokonsole.Source.Map
{
    public enum TileType
    {
        EMPTY = 0,
        WALL,
        HORIZONTAL_WALL,
        TREE,
        ENEMY,
        PLAYER,
        OBJECT,
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
                    return " ";

                case TileType.WALL:
                    return "|";

                case TileType.TREE:
                    return "T";

                case TileType.ENEMY:
                    return "E";

                case TileType.PLAYER:
                    return "P";

                    case TileType.OBJECT:
                        return "O";

                case TileType.HORIZONTAL_WALL:
                    return "_";

                default:
                    return " ";
            }
        }

        public TileType _TileType { get => Type; set { Type = value; } }

        private TileType Type;
    }
}
