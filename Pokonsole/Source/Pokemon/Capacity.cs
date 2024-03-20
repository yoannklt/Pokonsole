namespace Pokonsole.Source.Pokemon
{
    internal class Capacity
    {
        enum CAPACITY_TYPE
        {
            NONE = 0,
            ATTACK_BUFF,
            DEFENSE_BUFF,
            SPEED_BUFF,
            STATUS_BUFF
        }


        public Capacity() { }

        private float Power = 1.0f;
        public float _Power { get { return Power; } set { Power = value; } }

    }
}
