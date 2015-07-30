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
    public class DepthStencilBuffer : IDisposable
    {
        DepthFormat _format = DepthFormat.Depth32;

        public DepthStencilBuffer(GraphicsDevice graphicsDevice, int width, int height, DepthFormat format)
        {
            _format = format;
        }

        public DepthStencilBuffer(GraphicsDevice graphicsDevice, int width, int height, DepthFormat format, MultiSampleType multiSampleType, int multiSampleQuality)
        {
            _format = format;
        }
        #region IDisposable Members

        public void Dispose()
        {
        }

        #endregion

        public DepthFormat Format {
            get { return _format; }
        }
    }
}
