namespace Pokonsole.Source.Player
{
    internal class Player
    {
        // CONSTRUCTOR
        public Player() { }

        public void Move(int x, int y, int MapSize)
        {
            if (x == 0 && y == 0) { return; }
            if (x > 1 || y > 1) { x = 1; y = 1; }
            if (x < 0 || y < 0) { x = -1; y = -1; };

            if (_PosX + x < 0 || _PosX + x > MapSize) { return; }
            if (_PosY + y < 0 || _PosY + y > MapSize) { return; }

         
            _PosX += x;
            _PosY += y;
        }
        public void SelectPokemon(int number) { }

        public void Attack(Pokemon.Pokemon selectedPokemon)
        {

        }
        public void UseObject(Pokemon.Pokemon target, int obj) { }
        public void Escape() { }

        // VARIABLES MEMBRES
        Pokemon.Pokemon[] m_Pokemons = new Pokemon.Pokemon[6];
        private int PosX = 0;
        private int PosY = 0;

        public int _PosX {  get { return PosX; } set {  PosX = value; } }
        public int _PosY {  get { return PosY; } set {  PosY = value; } }
    }

}
