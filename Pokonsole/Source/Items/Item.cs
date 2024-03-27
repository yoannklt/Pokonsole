using Pokonsole.Source.Pokemons;

namespace Pokonsole.Source.Items
{
    struct ITEM_DATA
    {
        string? name;
        public string Name { get { return name; } set => name = value; }

        public ITEM_DATA(string name)
        {
            Name = name;
        }
    }

    internal abstract class Item
    {
        public Item() 
        {
            ItemData = new ITEM_DATA();
            //Pokemon = new Pokemon();
        }

        public void SetTarget(ref Pokemon pokemon)
        {
            Pokemon = pokemon;
        }

        public abstract void Use();

        private Pokemon? _Pokemon;
        public Pokemon Pokemon { get { return _Pokemon; } set { _Pokemon = value; } }

        private ITEM_DATA _ItemData;
        public ITEM_DATA ItemData { get { return _ItemData; } set { _ItemData = value; } }

        private int _amount;
        public int Amount { get { return _amount;} set { _amount = value; } }
    }
}
