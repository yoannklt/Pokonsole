﻿using Pokonsole.Source.Utils;

namespace Pokonsole.Source.Mapping
{
    internal class Map
    {
        public Map(int x, int y)
        {
            Size = new MathHelper.Vector2(x, y);
            Tile = new Tile[Size.X, Size.Y];
        }

        public void LoadMap()
        {

            ClearMap();

            PlaceTile(TileType.ENEMY, 9, 4);
            for (int i = 0; i < 4; i++)
            {
                PlaceTile(TileType.WALL, 5, i);
            }
            for (int i = 6; i < 9; i++)
            {
                PlaceTile(TileType.HORIZONTAL_WALL, i, 3);
            }
            PlaceTile(TileType.TREE, 18, 7);
            PlaceTile(TileType.ITEM, 19, 4);
        }

        public void PlaceTile(TileType type, int x, int y)
        {
            if (x > Size.X - 1 || y > Size.Y - 1) return; 
            Tile[x, y] = new Tile(type);
        }

        public void Draw()
        {
            for (int i = 0; i < Size.X; i++)
            {
                for (int j = 0; j < Size.Y; j++)
                {
                    Console.Write(Tile[j, i].GetString() + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public void Update()
        {
            for (int i = 0; i < Size.X; i++)
            {
                for (int j = 0; j < Size.Y; j++)
                {
                    if (Tile[j, i]._TileType != TileType.EMPTY)
                    {
                        Console.SetCursorPosition(j * 2, i);
                        Console.Write(_Tile[j, i].GetString());
                        Console.SetCursorPosition(0, Size.Y + 1);
                    }
                    else
                    {
                        Console.SetCursorPosition(j * 2, i);
                        Console.Write(" ");
                    }
                }
            }
        }

        public void ClearTile(int x, int y)
        {
            Tile[x, y] = new Tile(TileType.EMPTY);
        }

        public void ClearMap()
        {
            for (int i = 0; i < Size.X; i++)
            {
                for (int j = 0; j < Size.Y; j++)
                {
                    Tile[j, i] = new Tile(TileType.EMPTY);
                }
            }
        }

        private Tile[,]? _Tile;
        public Tile[,] Tile { get { return _Tile; } set { _Tile = value; } }

        private MathHelper.Vector2 _Size = new MathHelper.Vector2(0, 0);
        public MathHelper.Vector2 Size { get { return _Size; } set {  _Size = value; } }

    }
}
