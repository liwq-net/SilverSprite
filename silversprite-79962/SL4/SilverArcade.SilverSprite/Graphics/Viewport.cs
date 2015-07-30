using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Microsoft.Xna.Framework.Graphics
{
    public struct Viewport
    {
		public int X;
		public int Y;
		public int Width;
		public int Height;

        public Single MinDepth
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public Single MaxDepth
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public Vector3 Project(Vector3 source, Matrix projection, Matrix view, Matrix world)
        {
            throw new NotImplementedException();
        }

        public Vector3 Unproject(Vector3 source, Matrix projection, Matrix view, Matrix world)
        {
            throw new NotImplementedException();
        }

        public Single AspectRation
        {
            get { throw new NotImplementedException(); }
        }

        public Rectangle TitleSafeArea
        {
            //Note: This is implemented by Qbus/laumania.net. I'm not
            //sure this is the correct implementation, just implemented it as it were 
            //needed for running this Platformer starter kit using SilverSprite.
            get { return new Rectangle(this.X, this.Y, this.Width, this.Height); }
        }
    }
}
