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

using G = Microsoft.Xna.Framework.Graphics; 


namespace Microsoft.Xna.Framework
{
    public interface IGameComponent
    {
        void Initialize();
    }

    
    public class GameComponent : IGameComponent, IComparable<GameComponent>, IUpdateable, IDisposable
    {
        Game _game;
        int _updateOrder;
        bool _enabled;
        public event EventHandler UpdateOrderChanged;
        public event EventHandler EnabledChanged;
        bool _initialized = false;
        public GameComponent(Game game)
        {
            _game = game;
            Enabled = true;
        }

        public Game Game 
        {
            get 
            {
                return _game;
            }
        }

#if !SILVERSPRITELITE
        public G.GraphicsDevice GraphicsDevice
        {
            get
            {
                return _game.GraphicsDevice;
            }
        }
#endif

        public virtual void Initialize()
        {
            if (!_initialized)
            {
                _initialized = true;
                LoadContent();
            }
        }

		internal virtual void BeforeUpdate()
		{
			if (!_initialized) Initialize();
		}

        public virtual void Update(GameTime gameTime)
        {
        }

        protected virtual void LoadContent()
        {
        }

        protected virtual void UnloadContent()
        {
        }

        protected virtual void LoadGraphicsContent(bool loadContent)
        {

        }

        public bool Enabled
        {
            get{return _enabled;}
            set
            {
                _enabled = value;
                if(EnabledChanged != null)
                    EnabledChanged(this, null);

                OnEnabledChanged(this, null);
            }
        }

        public int UpdateOrder
        {
            get
            {
                return _updateOrder;
            }
            set
            {
                _updateOrder = value;
                if(UpdateOrderChanged != null)
                    UpdateOrderChanged(this, null);

                OnUpdateOrderChanged(this, null);
            }
        }

        protected virtual void OnUpdateOrderChanged(object sender, EventArgs args)
        {

        }

        protected virtual void OnEnabledChanged(object sender, EventArgs args)
        {

        }

        #region IComparable<GameComponent> Members

        public int CompareTo(GameComponent other)
        {
            return other.UpdateOrder - this.UpdateOrder;
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
