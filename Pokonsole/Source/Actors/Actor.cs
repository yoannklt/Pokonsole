using Pokonsole.Source.Utils;
using Pokonsole.Source.Mapping;

namespace Pokonsole.Source.Actors
{
    internal abstract class Actor
    {

        public Actor(ref Map map) => Map = map;

        public void SetPosition(int x, int y)
        {
            Position = new MathHelper.Vector2(x, y);
        }

        public void SetDirection(int x, int y)
        {
            Direction = new MathHelper.Vector2(x, y);
        }

        public void Move(int x, int y)
        {
            if (x == 0 && y == 0) { return; }
            if (x > 1) { x = 1; }
            if (y > 1) { y = 1; }
            if (x < 0) { x = -1; };
            if (y < 0) { y = -1; };

            SetDirection(x, y);

            int nextPosX = Position.X + x;
            int nextPosY = Position.Y + y;

            if (nextPosX < 0 || nextPosX + x > Map.Size.X) { return; }
            if (nextPosY + y < 0 || nextPosY + y > Map.Size.Y) { return; }

            if (Map.Tile[nextPosX, nextPosY]._TileType != TileType.EMPTY) { return; }
            
            SetPosition(nextPosX, nextPosY);

            Map.ClearTile(Position.X - x, Position.Y - y);
            Map.PlaceTile(TileType.PLAYER, Position.X, Position.Y);
        }

        public abstract string Interact();

        // CHAMPS
        private Map? _Map;
        public Map Map { get => _Map; set => _Map = value; }

        private MathHelper.Vector2 _Position;
        private MathHelper.Vector2 _Direction;

        public MathHelper.Vector2 Position { get => _Position; set => _Position = value; }
        public MathHelper.Vector2 Direction { get => _Direction; set => _Direction = value; }

    }
}
