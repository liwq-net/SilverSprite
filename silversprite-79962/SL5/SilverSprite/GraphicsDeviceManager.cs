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

        public bool IsFullScreen
        {
            get;
            set;
        }

        public void ApplyChanges()
        {
            _game.applyChanges = true;
        }

        public GraphicsDevice GraphicsDevice
        {
            get
            {
                return System.Windows.Graphics.GraphicsDeviceManager.Current.GraphicsDevice;
            }
        }

        public GraphicsDeviceManager(Game game)
        {
            _game = game;
        }

        public int PreferredBackBufferWidth
        {
            get
            {
                return _game.preferredWidth;
            }
            set
            {
                _game.preferredWidth = value;
            }
        }

        public int PreferredBackBufferHeight
        {
            get
            {
                return _game.preferredHeight;
            }
            set
            {
                _game.preferredHeight = value;
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
        }

        #endregion

        #region IGraphicsDeviceManager Members

        public bool BeginDraw()
        {
            return true;
        }

        public void CreateDevice()
        {
        }

        public void EndDraw()
        {
        }

        #endregion
    }
}
