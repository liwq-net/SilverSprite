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
    public static class ViewportExtensions
    {
        public static Rectangle TitleSafeArea(this Viewport viewport)
        {
            return new Rectangle(viewport.X, viewport.Y, viewport.Width, viewport.Height);
        }
    }
}
