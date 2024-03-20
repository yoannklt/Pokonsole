﻿namespace Pokonsole.Source.Mapping
{
    public enum TileType
    {
        None = 0,
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
