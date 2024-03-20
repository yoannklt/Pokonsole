using Pokonsole.Source.Utils;

namespace Pokonsole.Source.Mapping
{
    internal class Map
    {
        public Map(int x, int y)
        {
            Size = new MathHelper.Vector2(x, y);
            _Tile = new Tile[Size.X, Size.Y];

            for (int i = 0; i < Size.X; i++)
            {
                for (int j = 0; j < Size.Y; j++)
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
            PlaceTile(TileType.OBJECT, 19, 4);
        }

        public void PlaceTile(TileType type, int x, int y)
        {
            if (x > Size.X - 1 || y > Size.Y - 1) { return; }
            _Tile[x, y] = new Tile(type);
        }

        public void Draw()
        {
            for (int i = 0; i < Size.X; i++)
            {
                for (int j = 0; j < Size.Y; j++)
                {
                    Console.Write(_Tile[j, i].GetString() + " ");
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
                    if (_Tile[j, i]._TileType != TileType.EMPTY)
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
            _Tile[x, y] = new Tile(TileType.EMPTY);
        }

        public void ClearMap()
        {
            for (int i = 0; i < Size.X; i++)
            {
                for (int j = 0; j < Size.Y; j++)
                {
                    _Tile[j, i] = new Tile(TileType.EMPTY);
                }
            }
        }

        private Tile[,] Tile;
        public Tile[,] _Tile { get { return Tile; } set { Tile = value; } }

        private MathHelper.Vector2 _Size;
        public MathHelper.Vector2 Size { get { return _Size; } set {  _Size = value; } }

    }
}
