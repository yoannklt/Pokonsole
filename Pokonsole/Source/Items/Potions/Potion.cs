
namespace Pokonsole.Source.Items.Potions
{
    internal abstract class Potion : Item
    {
        public Potion() { }

        private float _HealthRegeneration;
        public float HealthRegeneration { get { return _HealthRegeneration; } set => _HealthRegeneration = value; }
    }
}
