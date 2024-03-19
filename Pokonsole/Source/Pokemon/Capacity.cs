namespace Pokonsole.Source.Pokemon
{
    internal class Capacity
    {

        enum ATTACK_TYPE
        {
            None = 0,
            ATTACKBUFFING,//_m_capacityDamage 15%
            DEFENSEBUFFING,
            SPECIALBUFFING,
            SPEEDBUFFING,//_m_capacityDefense 15%
            STATUSBUFFING, //_m_statusEffect POISON
            TOTAL_ATTACK_TYPE
        }
        public Capacity() 
        {
        }

        public void AddAttackDamage(Pokemon target) 
        {

            target.Attack1 = target.Attack1 + m_capacityDamage;
        }

        public void AddDefense(Pokemon target) 
        {
            target.Defense = target.Defense + m_capacityDefense;
        }
        public void SetStatusEffect(Pokemon target, POKEMON_STATUS status) 
        {
            target.State = status;
        }

        private float Power = 1.0f;
        private float m_capacityDamage = 0f;
        private float m_capacityDefense = 0f;
        private POKEMON_STATUS m_statusEffect = POKEMON_STATUS.NORMAL;
        private float m_capacityCrit = 0f;

        public float _Power { get { return Power; } set { Power = value; } }
        private string _Name;
        private float _Type;

    }
}
