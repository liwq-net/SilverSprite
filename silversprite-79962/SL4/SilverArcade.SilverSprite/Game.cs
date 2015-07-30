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
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Input = Microsoft.Xna.Framework.Input;

using SilverArcade.SilverSprite;

using System.Collections.Generic;
using SilverArcade.SilverSprite.Manifest;

namespace Microsoft.Xna.Framework
{
    public class Game : Canvas, IDisposable
    {
        public event System.EventHandler Exiting;
        GraphicsDevice graphicsDevice;
		ContentManager _content;
		bool _initialized = false;

		SilverArcade.SilverSprite.GameLoop gameLoop;
		GameTime updateGameTime;
		GameTime drawGameTime;

//        public static KeyHandler KeyHandler = null;
        GameComponentCollection _gameComponentCollection = new GameComponentCollection();
 //       Storyboard sb = new Storyboard();
        public GameServiceContainer _services = new GameServiceContainer();
        GameWindow _window;
        internal States _currentState = States.Idle;
        SolidColorBrush backgroundBrush = new SolidColorBrush(Colors.Black);
        internal enum States
        {
            Idle,
            Startup,
            Running,
            Done
        }

        public void MapKeyboardToGamePadButton(Buttons b, Keys k)
        {
            GamePadState.MapKey(b, k);
        }

        public bool IsActive
        {
            get
            {
                return true;
            }
        }

        public bool IsMouseVisible
        {
            get;
            set;
        }

        public TimeSpan TargetElapsedTime
        {
            get
            {
				InitializeGameLoop();
                return gameLoop.TargetElapsedTime;
            }
            set
            {
				InitializeGameLoop();
				gameLoop.TargetElapsedTime = value;
            }
        }

        public bool IsFixedTimeStep
        {
            get
            {
                InitializeGameLoop();
                return gameLoop.IsFixedTimeStep;
            }
            set
            {
                InitializeGameLoop();
                gameLoop.IsFixedTimeStep = value;
            }

        }


        public GameWindow Window
        {
            get
            {
                return _window;
            }
        }

        public GameServiceContainer Services
        {
            get
            {
                return _services;
            }
        }

        public Game()
        {
			if (Discovery.Ready == false)
			{
				Discovery.Initialize();
			}
            GamePadState.Initialize();
            _window = new SilverlightGameWindow(this) as GameWindow;
            updateGameTime = new GameTime();
            drawGameTime = new GameTime();
//            sb.Completed += new EventHandler(sb_Completed);
            this.Loaded += new RoutedEventHandler(Game_Loaded);
            _currentState = States.Startup;
        }

        void Game_Loaded(object sender, RoutedEventArgs e)
        {
			GraphicsDevice.Root = this;
			InitializeGameLoop();
		}

		void InitializeGameLoop()
		{
			if (gameLoop == null)
			{
				gameLoop = new SilverArcade.SilverSprite.GameLoop();
				gameLoop.Update += new EventHandler<SilverArcade.SilverSprite.SimpleEventArgs<TimeSpan>>(gameLoop_Update);
				gameLoop.Draw += new EventHandler<SilverArcade.SilverSprite.SimpleEventArgs<TimeSpan>>(gameLoop_Draw);
			}
		}

		void gameLoop_Draw(object sender, SilverArcade.SilverSprite.SimpleEventArgs<TimeSpan> e)
		{
            bool ret = BeginDraw();
            if (ret == false) return;
            drawGameTime.Update(e.Result);
			for (int i = 0; i < GraphicsDevice._allRenderTargets.Count; i++)
			{
				GraphicsDevice._allRenderTargets[i]._renderer.BeforeDraw();
			}
			Draw(drawGameTime);
			for (int i = 0; i < GraphicsDevice._allRenderTargets.Count; i++)
			{
				GraphicsDevice._allRenderTargets[i]._renderer.AfterDraw();
			}
            EndDraw();
		}

		void gameLoop_Update(object sender, SilverArcade.SilverSprite.SimpleEventArgs<TimeSpan> e)
		{
			if (!_initialized)
			{
				Initialize();
                GraphicsDevice.GraphicsDeviceManager.ApplyChanges();
				_initialized = true;
				_currentState = States.Running;
				BeginRun();
			} 
			if (_currentState == States.Done) return;
			updateGameTime.Update(e.Result);
			Update(updateGameTime);
		}


        protected virtual void OnExiting(object sender, EventArgs e)
        {
        }
        protected virtual void BeginRun() { }

#if !SILVERSPRITELITE
		public void AddFont(string fontName, string fontFamily)
		{
			FontFamily f = new FontFamily(fontFamily);
			TextBlock t = new TextBlock();
			this.Children.Add(t);
			t.FontFamily = f;
			SpriteFont.AddFont(fontName, f);
		}
		
		public ContentManager Content
        {
            get
            {
                if (_content == null)
                {
                    _content = new ContentManager(_services);                   
                }
                return _content;
            }
        }

        public GraphicsDevice GraphicsDevice
        {
            get
            {
                if (graphicsDevice == null)
                {
                    graphicsDevice = new GraphicsDevice();
                }
                return graphicsDevice;
            }
            protected set
            {
                graphicsDevice = value;
            }
		}
#endif

		protected virtual void Initialize()
        {
            LoadContent();

            _gameComponentCollection.Initialize(this);
        }

        protected virtual void LoadContent()
        {
        }

        protected virtual void UnloadContent()
        {
        }

        protected virtual bool BeginDraw()
        {
            return true;
        }

        protected virtual void EndDraw()
        {

        }

        protected virtual void OnActivated(object o, EventArgs e)
        {

        }

        protected virtual void OnDeactivated(object o, EventArgs e)
        {

        }

        protected virtual void EndRun()
        {

        }

        protected virtual void Update(GameTime gameTime)
        {
            _gameComponentCollection.Update(gameTime);
        }

        protected virtual void Draw(GameTime gameTime)
        {
            _gameComponentCollection.Draw(gameTime);
        }

        public void Exit()
        {
            _currentState = States.Done;
			if (Exiting != null) Exiting(this, null);
			gameLoop.Dispose();
        }

        public GameComponentCollection Components 
        {
            get
            {
                return _gameComponentCollection;
            }
        }

		#region IDisposable Members

		public void Dispose()
		{
		}

		#endregion
	}
}
