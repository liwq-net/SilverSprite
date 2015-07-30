using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using Media = System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Media;

using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

using System.Collections.Generic;

using SilverArcade.SilverSprite.Graphics;

namespace Microsoft.Xna.Framework.Graphics
{
    public class GraphicsDevice
    {
        System.Windows.Media.SolidColorBrush backgroundBrush;
        Color background;
        Canvas root;
        RenderTarget[] _renderTargets;
        static internal List<RenderTarget> _allRenderTargets = new List<RenderTarget>();

        public event EventHandler Disposing;
        public event EventHandler DeviceResetting;
        public event EventHandler DeviceReset;
        public event EventHandler DeviceLost;
        public event EventHandler ResourceCreated;
        public event EventHandler ResourceDestroyed;

        public SamplerStateCollection SamplerStates = new SamplerStateCollection();
        RenderTarget backBuffer;
        public static bool BitmapCacheEnabled;
        public static double RenderAtScale;

        internal GraphicsDeviceManager GraphicsDeviceManager
        {
            set;
            get;
        }

        public GraphicsDevice()
        {
            BitmapCacheEnabled = true;
            RenderAtScale = 1;
            RenderState = new RenderState();
            PresentationParameters = new PresentationParameters();
            PresentationParameters.BackBufferFormat = SurfaceFormat.Canvas;
        }

		public void CleanupTexture(Texture2D texture)
		{
			foreach (RenderTarget2D target in _allRenderTargets)
			{
				if (target._renderer is CanvasRenderer)
				{
					(target._renderer as CanvasRenderer).DisposeTextureAssets(texture);
				}
			}
		}

        public RenderTarget GetRenderTarget(int index)
        {
            if (index > 0)
            {
                return null;
            }
            return _renderTargets[0];
        }

        internal void Initialize()
        {
        }

        public Viewport Viewport
        {
            get
            {
                RenderTarget t = GetCurrentRenderTarget();
                if (t != null)
                {
                    return t._viewport;
                }
                else
                {
                    return new Viewport()
                    {
                        Width = GraphicsDeviceManager.PreferredBackBufferWidth,
                        Height = GraphicsDeviceManager.PreferredBackBufferHeight
                    };
                }
            }
            set
            {
                GetCurrentRenderTarget()._viewport = value;
            }
        }

        public Canvas Root
        {
            get
            {
                return root;
            }
            set
            {
                root = value;
                background = Color.CornflowerBlue;
                backgroundBrush = new System.Windows.Media.SolidColorBrush(background.ToSilverlightColor());
                root.Background = backgroundBrush;
                Application.Current.RootVisual.MouseLeftButtonDown += new MouseButtonEventHandler(root_MouseLeftButtonDown);
                Application.Current.RootVisual.MouseLeftButtonUp += new MouseButtonEventHandler(root_MouseLeftButtonUp);
                Application.Current.RootVisual.MouseLeave += new MouseEventHandler(RootVisual_MouseLeave);
                Application.Current.RootVisual.MouseEnter += new MouseEventHandler(RootVisual_MouseEnter);

                Application.Current.RootVisual.MouseMove += new MouseEventHandler(root_MouseMove);
                _renderTargets = new RenderTarget[1];
                RenderTarget2D target = new RenderTarget2D(this, GraphicsDeviceManager.PreferredBackBufferWidth, GraphicsDeviceManager.PreferredBackBufferHeight, 1, PresentationParameters.BackBufferFormat, RenderTargetUsage.DiscardContents);
                backBuffer = target;
                _allRenderTargets.Add(backBuffer);
                root.Children.Add(backBuffer._renderer.Root);
				DepthStencilBuffer = new DepthStencilBuffer(this, Viewport.Width, Viewport.Height, DepthFormat.Unknown);
			}
        }

        void RootVisual_MouseLeave(object sender, MouseEventArgs e)
        {
            Mouse.IsOnGameWindow = false;
        }

        void RootVisual_MouseEnter(object sender, MouseEventArgs e)
        {
            Mouse.IsOnGameWindow = true;
        }

        void root_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                System.Windows.Point p = e.GetPosition(root);
                Mouse.X = (int)p.X;
                Mouse.Y = (int)p.Y;
            }
            catch
            {
            }
        }

        void root_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Mouse.LeftButtonDown = false;
        }

        void root_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Mouse.LeftButtonDown = true;
        }

        public void Clear(Color color)
        {
            if (_renderTargets != null && _renderTargets.Length > 0)
            {
                RenderTarget t = _renderTargets[0];
                if (t == null)
                {
                    t = backBuffer;
                }
                t._renderer.Clear(color);
            }
        }

        public bool SynchronizeWithVerticalRetrace
        {
            get;
            set;
        }

        public RenderState RenderState
        {
            get;
            set;
        }

        public PresentationParameters PresentationParameters
        {
            get;
            set;
        }
        public GraphicsDeviceCreationParameters CreationParameters
        {
            get;
            set;
        }

        public void Clear(ClearOptions options, Vector4 color, Single depth, int stencil)
        {
            throw new NotImplementedException();
        }

        public void Clear(ClearOptions options, Vector4 color, Single depth, int stencil, Rectangle[] regions)
        {
            throw new NotImplementedException();
        }

        public void Clear(ClearOptions options, Color color, Single depth, int stencil)
        {
            throw new NotImplementedException();
        }

        public void Clear(ClearOptions options, Color color, Single depth, int stencil, Rectangle[] regions)
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            Root.Children.Remove(backBuffer._renderer.Root);
            _allRenderTargets.Remove(backBuffer);
            backBuffer = new RenderTarget2D(this, Viewport.Width, Viewport.Height, 1, PresentationParameters.BackBufferFormat, RenderTargetUsage.DiscardContents);
            Root.Children.Add(backBuffer._renderer.Root);
            RectangleGeometry r = new RectangleGeometry();
            r.Rect = new Rect(0, 0, Viewport.Width, Viewport.Height);
            Root.Clip = r;
        }

        public void Reset(PresentationParameters presentationParameters)
        {
            PresentationParameters = presentationParameters;
            Reset();
        }

        public void Reset(GraphicsAdapter graphicsAdapter)
        {
            throw new NotImplementedException();
        }

        public void Reset(PresentationParameters presentationParameters, GraphicsAdapter graphicsAdapter)
        {
            throw new NotImplementedException();
        }

        public DisplayMode DisplayMode
        {
            get { throw new NotImplementedException(); }
        }

        public GraphicsDeviceCapabilities GraphicsDeviceCapabilities
        {
            get { throw new NotImplementedException(); }
        }

        public void Present(IntPtr overrideWindowHandle)
        {
            throw new NotImplementedException();
        }

        public void Present(Rectangle? sourceRectangle, Rectangle? destinationRectangle, IntPtr overrideWindowHandle)
        {
            throw new NotImplementedException();
        }

        public void Present()
        {
            throw new NotImplementedException();
        }

        internal RenderTarget GetCurrentRenderTarget()
        {
            if (_renderTargets == null || _renderTargets[0] == null)
            {
                return backBuffer;
            }
            else
            {
                return _renderTargets[0];
            }
        }

        public static void SetGlobalBitmapCache(bool cached, double renderAtScale)
        {
            BitmapCacheEnabled = cached;
            RenderAtScale = renderAtScale;
            foreach (RenderTarget target in _allRenderTargets)
            {
                RenderTarget2D target2D = target as RenderTarget2D;
                if (target2D != null)
                {
                    target2D.BitmapCacheEnabled = cached;
                    target2D.RenderAtScale = renderAtScale;
                }
            }
        }

        public DepthStencilBuffer DepthStencilBuffer { get; set; }

        public void SetRenderTarget(int renderTargetIndex, RenderTarget2D renderTarget)
        {
            if (renderTargetIndex > 0)
            {
                throw new NotSupportedException("RenderTargetIndex greater than zero not supported");
            }
            _renderTargets[0] = renderTarget;
        }

    }
}
