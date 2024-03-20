namespace Pokonsole.Source.Pokemon
{
    internal class CapacityManager:Capacity
    {
        public CapacityManager() 
        { 

        }

        public ~CapacityManager()
        {

        }

        private float _CapacityCreated = 0.0f;

        public createNewCapacity(string Name, POKEMON_TYPE type, float Power, float Précision, CAPACITY_TYPE Capacity_Type = NONE)
        {
            Capacity Name = new Capacity(type, Power, Précision, Capacity_Type);
            _CapacityCreated += 1;
        }
    }
}


