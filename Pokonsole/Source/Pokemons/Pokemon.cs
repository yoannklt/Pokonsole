
namespace Pokonsole.Source.Pokemons
{
    enum POKEMON_TYPE
    {
        NORMAL = 0,
        FIRE,
        WATER,
        GRASS,
        TOTAL_POKEMON_TYPE
        /*
        ELECTRIK,
        DARK,
        FIGHTING,
        PSYCHIC,
        FLYING,
        GROUND,
        BUG,
        POISON,
        FAIRY,
        GHOST,
        ICE,
        STEEL,*/
    }

    enum POKEMON_STATUS
    {
        NORMAL = 0,
        PARALYSED,
        POISONED,
        TOTAL_POKEMON_STATUS
    }

    internal class Pokemon
    {
        public Pokemon() { }

        // METHODS
        public void Update() 
        {
            if (_Health == 0)
            {
                Die();
            }
        }
        public void Attack() { }
        public void Escape() { }
        public void Die() { }
        public void OnEnter() { }
        public void OnExit() { }
        public void OnCapture() 
        {
            m_Captured = true;
        }


        // VARIABLES MEMBRES
        private float _Health = 100.0f;
        public float Health { get => _Health; set => _Health = value; }
        private float _Attack { get; set; }
        private float _Defense { get; set; }
        private float _Speed { get; set; }
        private int _Level { get; set; }

        private string _Name { get; set; } = "";
        private bool _CanAttack { get => _CanAttack;
            set
            {
                if (m_Status == POKEMON_STATUS.PARALYSED)
                    _CanAttack = false;
            } 
        }
        private bool m_Captured { get; set; }
        private POKEMON_TYPE m_Type { get; set; }
        private POKEMON_STATUS m_Status { get; set; } = POKEMON_STATUS.NORMAL;
        private Capacity[] m_Capacities { get; set; } = new Capacity[4];

    }
}
