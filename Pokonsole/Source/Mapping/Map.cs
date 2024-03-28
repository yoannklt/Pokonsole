using Pokonsole.Source.Utils;

namespace Pokonsole.Source.Mapping
{
    internal class Map
    {
        public Map(int x, int y)
        {
            Size = new MathHelper.Vector2(x, y);
            Tile = new Tile[Size.X, Size.Y];
            ClearTiles = new Tile[Size.X, Size.Y];
        }

        public void LoadMap()
        {
            try
            {
                using (StreamReader sr = new("../../../Source/Data/Inside.txt"))
                {
                    var txt = sr.ReadToEnd();
                    string[] allLines = txt.Split("\r\n");

                    for (int i = 0; i < allLines.Length; i++)
                    {
                        for (int j = 0; j < allLines[i].Length; j++)
                        {
                            TileType type = ConvertToTileType(allLines[j][i]);
                            ClearTiles[i, j] = new Tile(type);
                            PlaceTile(type, i, j);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Version = 1;
        }

        public void LoadSecMap()
        {
            try
            {
                using (StreamReader sr = new("../../../Source/Data/Outside.txt"))
                {
                    var txt = sr.ReadToEnd();
                    string[] allLines = txt.Split("\r\n");

                    for (int i = 0; i < allLines.Length; i++)
                    {
                        for (int j = 0; j < allLines[i].Length; j++)
                        {
                            TileType type = ConvertToTileType(allLines[j][i]);
                            ClearTiles[i, j] = new Tile(type);
                            PlaceTile(type, i, j);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Version = 2;
        }


        public TileType ConvertToTileType(char c)
        {
            switch (c)
            {
                case '0':
                    return TileType.EMPTY;

                case '1':
                    return TileType.HOUSE_WALL;

                case '2':
                    return TileType.ROOF;

                case '3':
                    return TileType.SECOND_ROOF;

                case '4':
                    return TileType.WALL;

                case '5':
                    return TileType.FLOOR;

                case '6':
                    return TileType.POKEMON;

                case '7':
                    return TileType.DOOR;

                default : return TileType.EMPTY;
            }
        }

        public void PlaceTile(TileType type, int x, int y)
        {
            if (x > Size.X - 1 || y > Size.Y - 1) 
                return; 
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
                    Console.SetCursorPosition(i * 2, j);
                    Console.Write(Tile[i, j].GetString() + " ");
                }
            }
        }

        public void ClearTile(int x, int y)
        {
            Tile[x, y] = ClearTiles[x, y]; 
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

        public Tile[,] ClearTiles;

        private MathHelper.Vector2 _Size = new MathHelper.Vector2(0, 0);
        public MathHelper.Vector2 Size { get { return _Size; } set {  _Size = value; } }

        private int _version;
        public int Version { get { return _version; } set { _version = value; } }

    }
}
