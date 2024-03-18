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

        public void PlaceTile(TileType type, int x, int y)
        {
            for (int i = 0; i< _Size; i++)
            {
                for (int j=0; j< _Size; j++)
                {
                    _Tile[i, j] = new Tile(type);
                }
            }
        }

        public void Draw()
        {
            for (int i = 0; i < _Size; i++)
            {
                for (int j = 0; j < _Size; j++)
                {
                    Console.WriteLine(_Tile[i, j].GetString() + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public void ClearTile(int x, int y)
        {
            for (int i = 0; i < _Size; i++)
            {
                for (int j = 0; j < _Size; j++)
                {
                    _Tile[i, j] = new Tile(TileType.EMPTY);
                }
            }
        }

        private Tile[,] _Tile;
        private int Size = 0;

        public int _Size { get { return Size; } set { Size = value; } }
    }
}
