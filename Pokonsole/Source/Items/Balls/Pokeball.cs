
namespace Pokonsole.Source.Items.Balls
{
    internal class Pokeball : Ball
    {
        public Pokeball()
        {
            ItemData = new ItemData("Pokeball");
            Amount++;
        }

        public override void Use() { }

    }
}
