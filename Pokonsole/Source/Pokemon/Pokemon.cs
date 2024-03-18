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
            if (m_HealthPoint == 0)
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
        private float m_HealthPoint { get; set; }
        private float m_Attack { get; set; }
        private float m_Defense { get; set; }
        private float m_Speed { get; set; }
        private int m_Level { get; set; }

        private string m_Name { get; set; } = "";
        private bool m_CanAttack { get;
            set 
            {
                if (m_Status == POKEMON_STATUS.PARALYSED)
                    m_CanAttack = false;
            } 
        }
        private bool m_Captured { get; set; }
        private POKEMON_TYPE m_Type { get; set; }
        private POKEMON_STATUS m_Status { get; set; } = POKEMON_STATUS.NORMAL;
        private Capacity[] m_Capacities { get; set; } = new Capacity[4];

    }
}
