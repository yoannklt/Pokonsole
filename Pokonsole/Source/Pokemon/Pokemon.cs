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
                OnDie();
            }
        }
        public void OnAttack() { }
        public void OnEscape() { }
        public void OnDie() { }
        public void OnEnter() { }
        public void OnExit() { }
        public void OnCapture() 
        {
            m_Captured = true;
        }


        // VARIABLES MEMBRES
        private string m_Name { get; set; }
        private int m_Level { get; set; }
        private float m_HealthPoint { get; set; }
        private float m_Attack { get; set; }
        private float m_Defense { get; set; }
        private float m_Speed { get; set; }
        private float m_SpecialAttack { get; set; }
        private float m_SpecialDefense { get; set; }
        private float m_Accuracy { get; set; }
        private float m_Evasion { get; set; }


        private bool m_CanAttack { get => m_CanAttack;
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
