
namespace Pokonsole.Source.Items.Potions
{
    internal class StandardPotion : Potion
    {
        public StandardPotion() { }

        public override void Use()
        {
            if (Pokemon.Health > 0)
                Pokemon.Health += HealthRegeneration;
        }

        private float _HealthRegeneration = 20.0f;
        public float HealthRegeneration { get { return _HealthRegeneration; } set => _HealthRegeneration = value; } 
    }
}
