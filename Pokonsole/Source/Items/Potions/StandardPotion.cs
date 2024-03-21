
namespace Pokonsole.Source.Items.Potions
{
    internal class StandardPotion : Potion
    {
        public StandardPotion() 
        {
            ItemData = new ItemData("Potion");
            Amount++;
        }

        public override void Use()
        {
            if (Pokemon.Health > 0)
                Pokemon.Health += HealthRegeneration;
        }
    }
}
