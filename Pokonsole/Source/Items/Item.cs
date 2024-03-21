using Pokonsole.Source.Pokemons;

namespace Pokonsole.Source.Items
{
    struct ItemData
    {
        string? name;
        public string Name { get { return name; } set => name = value; }

        public ItemData(string name)
        {
            Name = name;
        }
    }

    internal abstract class Item
    {
        public Item() 
        {
            ItemData = new ItemData();
            Pokemon = new Pokemon();
        }

        public void SetTarget(ref Pokemon pokemon)
        {
            Pokemon = pokemon;
        }

        public abstract void Use();

        private Pokemon? _Pokemon;
        public Pokemon Pokemon { get { return _Pokemon; } set { _Pokemon = value; } }

        private ItemData _ItemData;
        public ItemData ItemData { get { return _ItemData; } set { _ItemData = value; } }

        private int _amount;
        public int Amount { get { return _amount;} set { _amount = value; } }
    }
}
