
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

        public struct Vector2f
        {
            float x, y;
            public float X { get => x; set => x = value; }
            public float Y { get => y; set => y = value; }

            public Vector2f(float x, float y)
            {
                X = x;
                Y = y;
            }
        }

        static MathHelper() { }

        public static int Sum(int a , int b) { return  a + b; }
        public static float FSum(float a , float b) { return a + b; }

        public static int Sub(int a, int b) { return a - b; }
        public static float FSub(float a , float b) { return a - b; }

        public static int Multiply(int a, int b) { return a * b; }
        public static float FMultiply(float a, float b) { return a * b; }

        public static int Divide(int a, int b) { return a / b; }
        public static float FDivide(float a, float b) { return a / b; }

        public static int Max(int a, int b) { return a > b ? a : b; }
        public static float FMax(float a, float b) { return a > b ? a : b; }

        public static int Min(int a, int b) { return a < b ? a : b; }
        public static float FMin(float a, float b) { return a < b ? a : b;}
    }
}
