using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokonsole.Source.Pokemon
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
            if (_healthPoint == 0)
            {
                Die();
            }
        }
        public void Attack(Capacity capacité) { }
        public void Escape() { }
        public void Die() { }
        public void OnEnter() { }
        public void OnExit() { }
        public void OnCapture()
        {
            _isCaptured = true;
        }

        private string _name = "";
        private int _level;

        private float _healthPoint;
        private float _attack;
        private float _defense;
        private float _attackSpe;
        private float _defenseSpe;
        private float _speed;

        private bool _isCaptured = false;
        private POKEMON_STATUS _status = POKEMON_STATUS.NORMAL;
        private POKEMON_TYPE _type;

        public string Name { get => _name; set => _name = value; }
        public int Level { get => _level; set => _level = value; }

        public float HealthPoint { get => _healthPoint; set => _healthPoint = value; }
        public float Attack1 { get => _attack; set => _attack = value; }
        public float Defense { get => _defense; set => _defense = value; }
        public float AttackSpe { get => _attackSpe; set => _attackSpe = value; }
        public float DefenseSpe { get => _defenseSpe; set => _defenseSpe = value; }
        public float Speed { get => _speed; set => _speed = value; }

        public bool IsCaptured { get => _isCaptured; set => _isCaptured = value; }
        public POKEMON_STATUS State { get => _status; set => _status = value; }
        public POKEMON_TYPE Type { get => _type; set => _type = value; }


        // VARIABLES MEMBRES

        private bool m_CanAttack { get => m_CanAttack;
            set
            {
                if (_status == POKEMON_STATUS.PARALYSED)
                    m_CanAttack = false;
            } 
        }
        private Capacity[] m_Capacities { get; set; } = new Capacity[4];
    }
}
