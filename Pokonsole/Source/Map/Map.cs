using Pokonsole.Source.Items;

namespace Pokonsole.Source.Map
{
    internal class Map
    {
        public Map(int size)
        {
            _Size = size;
            _Tile = new Tile[_Size, _Size];

            for (int i = 0; i < _Size; i++)
            {
                for (int j = 0; j < _Size; j++)
                {
                    _Tile[i, j] = new Tile(TileType.EMPTY);
                }
            }
        }

        public void LoadMap()
        {
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
        }

        public void PlaceTile(TileType type, int x, int y)
        {
            if (x > _Size - 1 || y > _Size - 1) { return; }
            _Tile[x, y] = new Tile(type);
        }

        public void Draw()
        {
            for (int i = 0; i < _Size; i++)
            {
                for (int j = 0; j < _Size; j++)
                {
                    Console.Write(_Tile[j, i].GetString() + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public void Update()
        {
            for (int i = 0; i < _Size; i++)
            {
                for (int j = 0; j < _Size; j++)
                {
                    if (_Tile[j, i]._TileType != TileType.EMPTY)
                    {
                        Console.SetCursorPosition(j * 2, i);
                        Console.Write(_Tile[j, i].GetString());
                        Console.SetCursorPosition(0, _Size + 1);
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
            _Tile[x, y] = new Tile(TileType.EMPTY);
        }

        public void ClearMap()
        {
            for (int i = 0; i < _Size; i++)
            {
                for (int j = 0; j < _Size; j++)
                {
                    _Tile[j, i] = new Tile(TileType.EMPTY);
                }
            }
        }

        private Tile[,] Tile;
        public Tile[,] _Tile { get { return Tile; } set { Tile = value; } }

        public Item[,] Item;
        public Item[,] _Item { get { return Item; } set { Item = value; } }

        private int Size = 0;

        public int _Size { get { return Size; } set { Size = value; } }

    }
}
