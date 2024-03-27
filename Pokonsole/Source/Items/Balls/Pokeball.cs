
namespace Pokonsole.Source.Items.Balls
{
    internal class Pokeball : Ball
    {
        public Pokeball()
        {
            ItemData = new ITEM_DATA("Pokeball");
            Amount++;
        }

        public override void Use() { }

    }
}
