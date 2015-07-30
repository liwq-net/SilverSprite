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
    public class RenderTarget2D : RenderTarget
    {
		GraphicsDevice device;

        void Init(GraphicsDevice graphicsDevice, int width, int height, SurfaceFormat format)
        {
            if (format == SurfaceFormat.Canvas)
            {
                _renderer = new CanvasRenderer(width, height);
            }
            else
            {
                _renderer = new WriteableBitmapRenderer(width, height);
            }
			_viewport.Width = width;
			_viewport.Height = height;
            RenderAtScale = GraphicsDevice.RenderAtScale;
            BitmapCacheEnabled = GraphicsDevice.BitmapCacheEnabled;
			device = graphicsDevice;
		}

        public RenderTarget2D(GraphicsDevice graphicsDevice, int width, int height, int numberLevels, SurfaceFormat format, RenderTargetUsage usage) 
        {
            Init(graphicsDevice, width, height, format);
            GraphicsDevice._allRenderTargets.Add(this);
        }

        public RenderTarget2D(GraphicsDevice graphicsDevice, int width, int height, int numberLevels, SurfaceFormat format, MultiSampleType multiSampleType, int multiSampleQuality)
        {
            Init(graphicsDevice, width, height, format);
            GraphicsDevice._allRenderTargets.Add(this);
        }

        public RenderTarget2D(GraphicsDevice graphicsDevice, int width, int height, int numberLevels, SurfaceFormat format, MultiSampleType multiSampleType, int multiSampleQuality, RenderTargetUsage usage)
        {
            Init(graphicsDevice, width, height, format);
            GraphicsDevice._allRenderTargets.Add(this);
        }

        public Texture2D GetTexture()
        {
            return _renderer.GetTexture(device);
        }

        public virtual bool BitmapCacheEnabled
        {
            get
            {
                return _renderer.BitmapCacheEnabled;
            }
            set
            {
                _renderer.BitmapCacheEnabled = value;
            }
        }

        public virtual double RenderAtScale
        {
            get
            {
                return _renderer.RenderAtScale;
            }
            set
            {
                _renderer.RenderAtScale = value;
            }
        }

    }
}
