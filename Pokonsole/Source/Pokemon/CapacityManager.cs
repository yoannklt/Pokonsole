namespace Pokonsole.Source.Pokemon
{
    internal class CapacityManager
    {
        //CONSTRUCTEUR
        public CapacityManager()
        {

        }

        //METHODES
        public void createNewCapacity(string name, POKEMON_TYPE type, int power, int accuracy)
        {
            Capacity Name = new Capacity(name, type, power, accuracy);
            ListAllCapacities.Add(Name);
        }

        //METHODES GETTER / SETTER
        public List<Capacity> ListAllCapacities { get => _listAllCapacities; set => _listAllCapacities = value; }

        //VARIABLES PRIVEES
        private List<Capacity> _listAllCapacities;

    }
}