using Pokonsole.Source.Utils;
using Pokonsole.Source.Mapping;

namespace Pokonsole.Source.Actors
{
    internal class Enemy : Actor
    {
        public Enemy(MathHelper.Vector2 FTerm, MathHelper.Vector2 STerm, ref Map map) : base(ref map)
        {
            FirstTerminal = FTerm;
            SecondTerminal = STerm;
        }

        public void Update()
        {
           
        }

        public override string Interact()
        {
            return "";
        }

        private MathHelper.Vector2 _FirstTerminal;
        private MathHelper.Vector2 _SecondTerminal;

        public MathHelper.Vector2 FirstTerminal { get => _FirstTerminal; set => _FirstTerminal = value; }
        public MathHelper.Vector2 SecondTerminal { get => _SecondTerminal; set => _SecondTerminal = value; }
        

    }
}
