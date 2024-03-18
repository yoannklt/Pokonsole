namespace Pokonsole.Source.Map
{
    public enum TileType
    {
        EMPTY = 0,
        WALL,
        TREE,
        ENEMY,
        PLAYER,
        TOTAL_TILE_TYPE
    }

    internal class Tile
    {
        public Tile(TileType tileType) => _TileType = tileType;

        public string GetString()
        {
            switch (_TileType)
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

                default:
                    return " ";
            }
        }

        private TileType _TileType;
    }
}
