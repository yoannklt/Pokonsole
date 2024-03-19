using Pokonsole.Source.Map;

namespace Pokonsole.Source.Player
{
    internal class Player
    {
        // CONSTRUCTOR
        public Player() { }

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

            _PosX += x;
            _PosY += y;

            map.ClearTile(_PosX - x, _PosY - y);
            map.PlaceTile(TileType.PLAYER, _PosX, _PosY);
        }

        public string Interact(ref Map.Map map)
        {
            TileType currentTile = map._Tile[_PosX, _PosY]._TileType;

            switch(currentTile)
            {
                case TileType.EMPTY:
                    return "There is nothing there";

                case TileType.TREE:
                    return "What a cool tree!";

                case TileType.WALL:
                    return "Wsh groot";

                case TileType.ENEMY:
                    return "AKHAAAAAAAAAAA!!";

                case TileType.OBJECT:
                    /*CollectObject();*/
                    return "Object collected: " /*+ Object.Name*/;

                default:
                    return "";
            }
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

        public int _PosX {  get { return PosX; } set {  PosX = value; } }
        public int _PosY {  get { return PosY; } set {  PosY = value; } }
    }

}
