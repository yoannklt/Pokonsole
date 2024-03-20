using Pokonsole.Source.Pokemons;

namespace Pokonsole.Source.Items
{
    internal abstract class Item
    {
        public enum ITEM_TYPE
        {
            None = 0,
            POTION,
            BALL,
            REMINDER
        }

        public Item() 
        {
            Pokemon = new Pokemon();
        }

        public void SetTarget(Pokemon pokemon)
        {
            Pokemon = pokemon;
        }

        public abstract void Use();

        private Pokemon? _Pokemon;
        public Pokemon Pokemon { get { return _Pokemon; } set { _Pokemon = value; } }
    }
}
