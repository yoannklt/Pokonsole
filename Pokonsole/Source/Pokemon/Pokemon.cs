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
        POISONED
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

        // GETTER / SETTER
        public float GetHP() { return m_HealthPoint; } 
        public float GetAttack() { return m_Attack; } 
        public float GetDefense() { return m_Defense; } 
        public float GetSpeed() { return m_Speed; } 
        public int GetLevel() { return m_Level; }
        public string GetName() { return m_Name; }
        public bool CanAttack() { return m_CanAttack; }
        public POKEMON_TYPE GetTYPE() { return m_Type; }
        public POKEMON_STATUS GetStatus() { return m_Status; }
        public bool GetCaptured() { return m_Captured; }
        public void SetCanAttack()
        {
            if (m_Status != POKEMON_STATUS.PARALYSED)
            {
                m_CanAttack = true;
            }
        }


        // VARIABLES MEMBRES
        private float m_HealthPoint;
        private float m_Attack;
        private float m_Defense;
        private float m_Speed;
        private int m_Level;

        private string m_Name = "";
        private bool m_CanAttack;
        private bool m_Captured;
        private POKEMON_TYPE m_Type;    
        private POKEMON_STATUS m_Status = POKEMON_STATUS.NORMAL;
        private Capacity[] m_Capacities = new Capacity[4];

    }
}
