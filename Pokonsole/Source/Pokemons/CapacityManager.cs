using System.Security.AccessControl;

namespace Pokonsole.Source.Pokemons
{
    internal class CapacityManager
    {

        Dictionary<string, Capacity> capacitys;

        public IReadOnlyDictionary<string, Capacity> Capacitys { get => capacitys; }

        public CapacityManager()
        {

            capacitys = new Dictionary<string, Capacity>();

        }

        ~CapacityManager()
        {

        }

        private float _CapacityCreated = 0.0f;


        public Capacity createNewCapacity(string Name, POKEMON_TYPE type, int Power, int Précision)
        {
            Capacity c = new Capacity(Name, type, Power, Précision);
            _CapacityCreated += 1;
            return c;
        }

        public Capacity createNewCapacity(string Name, POKEMON_TYPE type, int Power, int Précision, POKEMON_STATUS Poison)
        {
            Capacity c = new Capacity(Name, type, Power, Précision, Poison);
            _CapacityCreated += 1;
            return c;
        }

        internal void addDico(string StrKey, Capacity VarName)
        {
            capacitys.Add(StrKey, VarName);
        }
    }
}