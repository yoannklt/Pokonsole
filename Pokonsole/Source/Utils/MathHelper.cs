
namespace Pokonsole.Source.Utils
{
    
    public static class MathHelper
    {
        public struct Vector2
        {
            int x, y;

            public int X { get => x; set => x = value; }
            public int Y { get => y; set => y = value; }

            public Vector2(int x, int y)
            {
                X = x;
                Y = y;
            }
        }

        static MathHelper() { }

        /*public static int Random(int min, int max)
        {
            return System.Random.Next(min, max);
        }

        public static float RandomF(float min, float max)
        {
            return Math.Min()
        }*/
    }
}
