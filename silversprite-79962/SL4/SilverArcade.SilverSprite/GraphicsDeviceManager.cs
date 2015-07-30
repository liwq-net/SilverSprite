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

using Microsoft.Xna.Framework.Graphics;

namespace Microsoft.Xna.Framework
{
    public class GraphicsDeviceManager : IGraphicsDeviceService, IDisposable, IGraphicsDeviceManager
    {
        Game _game;
        int _preferredBackBufferWidth;
        int _preferredBackBufferHeight;

        public bool IsFullScreen
        {
            get;
            set;
        }

        public void ApplyChanges()
        {
			GraphicsDevice.Viewport = new Viewport()
			{
				Width = PreferredBackBufferWidth,
				Height = PreferredBackBufferHeight,
				X = 0,
				Y = 0
			};
            GraphicsDevice.Root.Width = PreferredBackBufferWidth;
            GraphicsDevice.Root.Height = PreferredBackBufferHeight;
            GraphicsDevice.PresentationParameters.BackBufferFormat = PreferredBackBufferFormat;
            GraphicsDevice.Reset();
        }

        public GraphicsDevice GraphicsDevice
        {
            get;
            set;
        }

        public GraphicsDeviceManager(Game game)
        {
            this.GraphicsDevice = game.GraphicsDevice;
            game.GraphicsDevice.GraphicsDeviceManager = this;
            PreferredBackBufferWidth = 800;
            PreferredBackBufferHeight = 600;
            PreferredBackBufferFormat = SurfaceFormat.Canvas;
            _game = game;
            // as per test application on reference framework
            _game.Services.AddService(typeof(IGraphicsDeviceManager), this);
            _game.Services.AddService(typeof(IGraphicsDeviceService), this);
        }

        public int PreferredBackBufferWidth
        {
            get
            {
                return _preferredBackBufferWidth;
            }
            set
            {
                _preferredBackBufferWidth = value;
            }
        }

        public int PreferredBackBufferHeight
        {
            get
            {
                return _preferredBackBufferHeight;
            }
            set
            {
                _preferredBackBufferHeight = value;
            }
        }

        public SurfaceFormat PreferredBackBufferFormat
        {
            get;
            set;
        }
        
        public bool SynchronizeWithVerticalRetrace
        {
            get;
            set;
        }

        public void ToggleFullScreen()
        {
        }
        #region IGraphicsDeviceService Members


        public event EventHandler DeviceCreated;

        public event EventHandler DeviceDisposing;

        public event EventHandler DeviceReset;

        public event EventHandler DeviceResetting;

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IGraphicsDeviceManager Members

        public bool BeginDraw()
        {
            throw new NotImplementedException();
        }

        public void CreateDevice()
        {
            throw new NotImplementedException();
        }

        public void EndDraw()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
