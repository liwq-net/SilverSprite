using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Microsoft.Xna.Framework
{
    public struct DoubleRectangle : IEquatable<DoubleRectangle>
    {
        #region Fields
        static DoubleRectangle emptyRect = new DoubleRectangle(double.MinValue, double.MinValue, double.MinValue, double.MinValue);
        public double X;
        public double Y;
        public double Width;
        public double Height;

        #endregion

        #region Properties

        public double Left
        {
            get { return this.X; }
        }

        public double Right
        {
            get { return (this.X + this.Width); }
        }

        public double Top
        {
            get { return this.Y; }
        }

        public double Bottom
        {
            get { return (this.Y + this.Height); }
        }

        static public DoubleRectangle Empty
        {
            get
            {
                return emptyRect;
            }
        }

        public bool IsEmpty
        {
            get
            {
                return this.X == double.MinValue;
            }
        }
        #endregion

        #region Methods

        public DoubleRectangle(double x, double y, double width, double height)
        {
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
        }

        public bool Equals(DoubleRectangle other)
        {
            return X == other.X && Y == other.Y && Width == other.Width && Height == other.Height;
        }

        public static DoubleRectangle FromRectangle(Rectangle rectangle)
        {
            DoubleRectangle dr = new DoubleRectangle();
            dr.X = rectangle.X;
            dr.Y = rectangle.Y;
            dr.Width = rectangle.Width;
            dr.Height = rectangle.Height;

            return dr;
        }

        #endregion
    }
}
