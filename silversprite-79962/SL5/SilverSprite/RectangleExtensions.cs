
namespace Microsoft.Xna.Framework
{
    public static class RectangleExtensions
    {

        public static bool Contains(this Rectangle rect, int x, int y)
        {
            return (rect.Left <= x && rect.Right >= x &&
                    rect.Top <= y && rect.Bottom >= y);
        }

        public static bool Contains(this Rectangle rect, Point value)
        {
            return (rect.Left <= value.X && rect.Right >= value.X &&
                    rect.Top <= value.Y && rect.Bottom >= value.Y);
        }

        public static void Contains(this Rectangle rect, ref Point value, out bool result)
        {
            result = (rect.Left <= value.X && rect.Right >= value.X &&
                      rect.Top <= value.Y && rect.Bottom >= value.Y);
        }

        public static bool Contains(this Rectangle rect, Rectangle value)
        {
            return (rect.Left <= value.Left && rect.Right >= value.Right &&
                    rect.Top <= value.Top && rect.Bottom >= value.Bottom);
        }

        public static void Contains(this Rectangle rect, ref Rectangle value, out bool result)
        {
            result = (rect.Left <= value.Left && rect.Right >= value.Right &&
                      rect.Top <= value.Top && rect.Bottom >= value.Bottom);
        }

        public static bool Intersects(this Rectangle rect, Rectangle r2)
        {
            return !(r2.Left > rect.Right
                     || r2.Right < rect.Left
                     || r2.Top > rect.Bottom
                     || r2.Bottom < rect.Top
                    );

        }

        public static void Intersects(this Rectangle rect, ref Rectangle value, out bool result)
        {
            result = !(value.Left > rect.Right
                     || value.Right < rect.Left
                     || value.Top > rect.Bottom
                     || value.Bottom < rect.Top
                    );

        }

        public static Point Center(this Rectangle rect)
        {
            return new Point((rect.Right - (rect.Width >> 1)), (rect.Bottom - (rect.Height >> 1))); 
        }

        public static void Inflate(this Rectangle rect, int horizontalValue, int verticalValue)
        {
            rect.X -= horizontalValue;
            rect.Y -= verticalValue;
            rect.Width += horizontalValue * 2;
            rect.Height += verticalValue * 2;
        }
    }
}
