using Pokonsole.Source.Map;
using Pokonsole.Source.Items;

namespace Pokonsole.Source.Player
{
    internal class Player
    {
        // CONSTRUCTOR
        public Player() { }

        public void SetDirection(int x, int y) 
        {
            _DirX = x; _DirY = y;
        }

        public void Move(int x, int y, ref Map.Map map)
        {
            if (x == 0 && y == 0) { return; }
            if (x > 1) { x = 1; }
            if (y > 1) { y = 1; }
            if (x < 0) { x = -1; };
            if (y < 0) { y = -1; };

            if (_PosX + x < 0 || _PosX + x > map._Size - 1) { return; }
            if (_PosY + y < 0 || _PosY + y > map._Size - 1) { return; }

            int nextPosX = _PosX + x;
            int nextPosY = _PosY + y;
            if (map._Tile[nextPosX, nextPosY]._TileType != TileType.EMPTY) { return; }
            SetDirection(x, y);
            _PosX += x;
            _PosY += y;

            map.ClearTile(_PosX - x, _PosY - y);
            map.PlaceTile(TileType.PLAYER, _PosX, _PosY);
        }

        public string Interact(ref Map.Map map)
        {
            TileType currentTile = map._Tile[_PosX + _DirX, _PosY + _DirY]._TileType;
            Console.SetCursorPosition(0, map._Size + 3);
            Console.WriteLine();
            Console.SetCursorPosition(0, map._Size + 3);

            switch (currentTile)
            {
                case TileType.EMPTY:
                    return "There is nothing there";

                case TileType.WALL:
                    return "What a cool wall!";

                case TileType.TREE:
                    return "Wsh groot";

                case TileType.ENEMY:
                    return "AKHAAAAAAAAAAA!!";

                case TileType.OBJECT:
                    Item Item = CollectItem(_PosX + _DirX, _PosY + _DirY, ref map);
                    return "Object collected: " + Item._Name;

                default:
                    return "";
            }
        }

        public Item CollectItem(int x, int y, ref Map.Map map) 
        {
            return map._Item[x, y];
        }

        public void SelectPokemon(int number) { }

        public void Attack(Pokemon.Pokemon selectedPokemon)
        {

        }
        public void UseObject(Pokemon.Pokemon target, int obj) { }
        public void Escape() { }

        // VARIABLES MEMBRES
        Pokemon.Pokemon[] m_Pokemons = new Pokemon.Pokemon[6];
        private int PosX = 2;
        private int PosY = 2;
        private int DirX = 0;
        private int DirY = 0; 

        public int _PosX {  get { return PosX; } set {  PosX = value; } }
        public int _PosY {  get { return PosY; } set {  PosY = value; } }
        public int _DirX { get {  return DirX; } set {  DirX = value; } }
        public int _DirY { get { return DirY; } set { DirY = value; } }
    }

}
