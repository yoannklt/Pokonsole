using Pokonsole.Source.Actors.Player;
using Pokonsole.Source.Core;
using Pokonsole.Source.Pokemons;
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
                    return TileType.WATER;

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
                    if (Tile[i, j].TileType == TileType.PLAYER) 
                    {
                        Console.Write(Tile[j, i].GetString());
                    }
                    else 
                        Console.Write(Tile[j, i].GetString());
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public void Update(GameManager manager)
        {
            for (int i = 0; i < Size.X; i++)
            {
                for (int j = 0; j < Size.Y; j++)
                {
                    if (Tile[j, i].TileType != TileType.EMPTY) 
                    {
                        Console.SetCursorPosition(j, i);
                        Console.Write(Tile[j, i].GetString());
                    }
                    else
                    {
                        Console.SetCursorPosition(j, i);
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        Console.Write(" ");
                    }
                }
            }
            Console.BackgroundColor = ConsoleColor.Black;
            
            if (manager.Player.myPokemons !=null && manager.Player.myPokemons.Count != 0 )
            {
                string myPokemonsName = "";
                for (int i = 0; i < manager.Player.myPokemons.Count; i ++ )
                {
                    myPokemonsName += manager.Player.myPokemons[i].Name;
                    myPokemonsName += "  ";
                }
                Console.WriteLine(myPokemonsName);
            }
            else
            {
                Console.WriteLine(" ");
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
