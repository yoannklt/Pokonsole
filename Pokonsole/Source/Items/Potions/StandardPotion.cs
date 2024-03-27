
namespace Pokonsole.Source.Items.Potions
{
    internal class StandardPotion : Potion
    {
        public StandardPotion() 
        {
            ItemData = new ITEM_DATA("Potion");
            Amount++;
        }

        public override void Use()
        {
            if (Pokemon.Hp > 0)
                Pokemon.Hp += (int)HealthRegeneration;
        }
    }
}
