using Pokonsole.Source.Utils;

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
            try
            {
                using (StreamReader sr = new("../../../Source/Data/Map.txt"))
                {
                    var txt = sr.ReadToEnd();
                    string[] allLines = txt.Split("\r\n");

                    for (int i = 0; i < allLines.Length; i++)
                    {
                        for(int j = 0; j < allLines[i].Length; j++)
                        {
                            TileType type = ConvertToTileType(allLines[j][i]);
                            PlaceTile(type, i, j); 
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public TileType ConvertToTileType(char c)
        {
            switch (c)
            {
                case '0':
                    return TileType.EMPTY;

                case '1':
                    return TileType.ENEMY;

                case '2':
                    return TileType.BUSH;

                case '3':
                    return TileType.TREE;

                case '4':
                    return TileType.HORIZONTAL_WALL;

                case '5':
                    return TileType.WALL;

                case '6':
                    return TileType.ANGULAR_WALL;

                default : return TileType.EMPTY;
            }
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
                    if (Tile[j, i].TileType != TileType.EMPTY) 
                    {
                        Console.SetCursorPosition(j * 2, i);
                        Console.Write(Tile[j, i].GetString());
                        Console.SetCursorPosition(0, Size.Y + 1);
                    }
                    else
                    {
                        Console.SetCursorPosition(j * 2, i);
                        Console.Write(".");
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
