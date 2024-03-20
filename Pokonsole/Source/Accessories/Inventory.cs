using Pokonsole.Source.Items;
using Pokonsole.Source.Items.Potions;
using Pokonsole.Source.Items.Balls;

namespace Pokonsole.Source.Accessories
{
    internal class Inventory
    {
        public Inventory()
        {
            ItemsDictionary = new Dictionary<Item.ITEM_TYPE, Item>();
            StandardPotions = new List<Potion>();
            Pokeballs = new List<Ball>();
        }

        public void AddItem(dynamic item, Item.ITEM_TYPE flag)
        {
            switch(flag)
            {
                case Item.ITEM_TYPE.POTION:
                    StandardPotions.Add(item);
                    break;

                case Item.ITEM_TYPE.BALL:
                    Pokeballs.Add(item);
                    break;

                default:
                    break;
            }
        }

        private Dictionary<Item.ITEM_TYPE, Item>? _ItemsDictionary;
        public Dictionary<Item.ITEM_TYPE, Item> ItemsDictionary { get { return _ItemsDictionary; } set => ItemsDictionary = value; }

        private List<Potion>? _StandardPotions;
        public List<Potion> StandardPotions { get { return _StandardPotions; } set => _StandardPotions = value; }

        private List<Ball>?  _Pokeballs;
        public List<Ball> Pokeballs { get { return _Pokeballs; } set => _Pokeballs = value; }
    }
}
