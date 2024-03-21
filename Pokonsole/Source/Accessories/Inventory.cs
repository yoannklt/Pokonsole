using Pokonsole.Source.Items;

namespace Pokonsole.Source.Accessories
{
    internal class Inventory
    {
        public Inventory()
        {
            Items = new List<Item>();
        }

        public void AddItem(Item item)
        {
            var found = Items.FirstOrDefault(i => i.ItemData.Name == item.ItemData.Name);
            if (found !=null)
            {
                found.Amount++;
            }
            else
            {
                Items.Add(item);
            }

        }

        private List<Item>? _Items;
        public List<Item> Items { get => _Items; set => _Items = value; }
    }
}
