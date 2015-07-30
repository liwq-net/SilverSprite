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

namespace Microsoft.Xna.Framework.Graphics
{
    public struct DisplayMode
    {
        public float AspectRatio
        {
            get
            {
                return 4f / 3f;
            }
        }

        public int Width
        {
            get
            {
                return 800;
            }
        }

        public int Height
        {
            get
            {
                return 600;
            }
        }

    }
}
