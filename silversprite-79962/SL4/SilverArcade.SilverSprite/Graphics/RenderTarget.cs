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
using SilverArcade.SilverSprite.Graphics;

namespace Microsoft.Xna.Framework.Graphics
{
    public class RenderTarget
    {
        internal SilverlightRenderBase _renderer;
		internal Viewport _viewport;

		public RenderTarget()
		{
			_viewport = new Viewport();
		}

    }
}
