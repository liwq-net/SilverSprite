#region License
/*
MIT License
Copyright � 2006 The Mono.Xna Team

All rights reserved.

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/
#endregion License

using System;
using System.Globalization;
using System.ComponentModel;

using Microsoft.Xna.Framework.Design;

namespace Microsoft.Xna.Framework
{

    [Serializable]
    public struct Rectangle : IEquatable<Rectangle>
    {
        #region Private Fields

        private static Rectangle emptyRectangle = new Rectangle();

        #endregion Private Fields


        #region Public Fields

        public int X;
        public int Y;
        public int Width;
        public int Height;

        #endregion Public Fields


        #region Public Properties

        public static Rectangle Empty
        {
            get { return emptyRectangle; }
        }

        public int Left
        {
            get { return this.X; }
        }

        public int Right
        {
            get { return (this.X + this.Width); }
        }

        public int Top
        {
            get { return this.Y; }
        }

        public int Bottom
        {
            get { return (this.Y + this.Height); }
        }

        public Point Center
        {
            get { return new Point((this.Right - (this.Width >> 1)), (this.Bottom - (this.Height >> 1))); }
        }
        #endregion Public Properties


        #region Constructors

        public Rectangle(int x, int y, int width, int height)
        {
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
        }

        #endregion Constructors


        #region Public Methods

        public static bool operator ==(Rectangle a, Rectangle b)
        {
            return ((a.X == b.X) && (a.Y == b.Y) && (a.Width == b.Width) && (a.Height == b.Height));
        }

        public static bool operator !=(Rectangle a, Rectangle b)
        {
            return !(a == b);
        }

        public void Offset(Point offset)
        {
            X += offset.X;
            Y += offset.Y;
        }

        public void Offset(int offsetX, int offsetY)
        {
            X += offsetX;
            Y += offsetY;
        }

        public void Inflate(int horizontalValue, int verticalValue)
        {
            X -= horizontalValue;
            Y -= verticalValue;
            Width += horizontalValue * 2;
            Height += verticalValue * 2;
        }

        public bool Equals(Rectangle other)
        {
            return this == other;
        }

        public override bool Equals(object obj)
        {
            return (obj is Rectangle) ? this == ((Rectangle)obj) : false;
        }

        public override string ToString()
        {
            return string.Format("{{X:{0} Y:{1} Width:{2} Height:{3}}}", X, Y, Width, Height);
        }

        public override int GetHashCode()
        {
            return (this.X ^ this.Y ^ this.Width ^ this.Height);
        }

        public bool Intersects(Rectangle r2)
        {
            return !(r2.Left > Right
                     || r2.Right < Left
                     || r2.Top > Bottom
                     || r2.Bottom < Top
                    );

        }


        public void Intersects(ref Rectangle value, out bool result)
        {
            result = !(value.Left > Right
                     || value.Right < Left
                     || value.Top > Bottom
                     || value.Bottom < Top
                    );

        }

        public bool Contains(int x, int y)
        {
            return (this.Left <= x && this.Right >= x &&
                    this.Top <= y && this.Bottom >= y);
        }

        public bool Contains(Point value)
        {
            return (this.Left <= value.X && this.Right >= value.X &&
                    this.Top <= value.Y && this.Bottom >= value.Y);
        }

        public void Contains(ref Point value, out bool result)
        {
            result = (this.Left <= value.X && this.Right >= value.X &&
                      this.Top <= value.Y && this.Bottom >= value.Y);
        }

        public bool Contains(Rectangle value)
        {
            return (this.Left <= value.Left && this.Right >= value.Right &&
                    this.Top <= value.Top && this.Bottom >= value.Bottom);
        }

        public void Contains(ref Rectangle value, out bool result)
        {
            result = (this.Left <= value.Left && this.Right >= value.Right &&
                      this.Top <= value.Top && this.Bottom >= value.Bottom);
        }

        #endregion Public Methods
    }
}
