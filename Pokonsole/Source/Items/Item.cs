
namespace Pokonsole.Source.Items
{
    public enum ITEM_NAME
    {
        None = 0,
        POTION,
        POKE_BALL,
        SUPER_BALL,
        HYPER_BALL,
        MASTER_BALL,
        TOTAL_ITEM_NAME
    }

    internal class Item
    {
        public Item() { }

        public void PlaceItem(int x, int y, ref Map.Map map, ITEM_NAME name)
        {
            map._Tile[x, y] = new Map.Tile(Map.TileType.OBJECT);
            map._Item[x, y] = new Item();
            _PosX = x;
            _PosY = y;
            _Name = name;
        }

        // CHAMPS
        private ITEM_NAME Name = ITEM_NAME.None;
        public ITEM_NAME _Name { get { return Name; } set => Name = value; }

        private int PosX = 0;
        private int PosY = 0;
        public int _PosX { get { return PosX; } set { PosX = value; } }
        public int _PosY { get { return PosY; } set { PosY = value; } }

        private int ID = 0;
        public int _ID { get { return ID; } set => ID = value; }
    }
}
