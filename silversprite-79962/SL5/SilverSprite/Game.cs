using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Input = Microsoft.Xna.Framework.Input;

using SilverSprite;

using System.Collections.Generic;
using SilverSprite.Manifest;
using System.Windows.Graphics;
using System.Diagnostics;

namespace Microsoft.Xna.Framework
{
    public class Game : IDisposable
    {
        public event System.EventHandler Exiting;
		ContentManager _content;
		bool _initialized = false;
        internal DrawingSurface drawingSurface;
        GameTime updateGameTime;
        GameTime drawGameTime;
        TimeSpan targetElapsedTime;
        bool isFixedTimeStep;
        FrameworkElement parent;
        ContentControl root;
        TimeSpan leftoverTime;

//        public static KeyHandler KeyHandler = null;
        GameComponentCollection _gameComponentCollection = new GameComponentCollection();
 //       Storyboard sb = new Storyboard();
        public GameServiceContainer _services = new GameServiceContainer();
        GameWindow _window;
        internal States _currentState = States.Idle;
        SolidColorBrush backgroundBrush = new SolidColorBrush(Colors.Black);
        bool resetElapsedTime = false;
        internal int currentWidth;
        internal int currentHeight;
        internal int preferredWidth = 800;
        internal int preferredHeight = 640;
        internal bool applyChanges;
        bool startingUp;

        internal enum States
        {
            Idle,
            Startup,
            Running,
            Done
        }

        public FrameworkElement Root
        {
            get
            {
                return drawingSurface;
            }
        }

        public void Attach(FrameworkElement parent)
        {
            this.parent = parent;
            if (parent is Panel)
            {
                (parent as Panel).Children.Add(root);
            }
            else if (parent is ContentControl)
            {
                (parent as ContentControl).Content = root;
            }
            else
            {
                this.parent = null;
            }
            Keyboard.RootControl = root;
            Mouse.RootControl = root;
        }

        public void ResetElapsedTime()
        {
            resetElapsedTime = true;
        }

        public void Detach()
        {
            if (this.parent is Panel)
            {
                (this.parent as Panel).Children.Remove(drawingSurface);
            }
            else if (parent is ContentControl)
            {
                (this.parent as ContentControl).Content = null;
            }
        }

        public GraphicsDevice GraphicsDevice
        {
            get
            {
                return System.Windows.Graphics.GraphicsDeviceManager.Current.GraphicsDevice;
            }
        }

 //       public void MapKeyboardToGamePadButton(Buttons b, Keys k)
 //       {
 //           GamePadState.MapKey(b, k);
 //       }

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
                return targetElapsedTime;
            }
            set
            {
				targetElapsedTime = value;
            }
        }

        public bool IsFixedTimeStep
        {
            get
            {
                return isFixedTimeStep;
            }
            set
            {
                isFixedTimeStep = value;
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
            GamePadState.Initialize();
            root = new ContentControl();
            drawingSurface = new DrawingSurface();
            root.Content = drawingSurface;
            drawingSurface.HorizontalAlignment = HorizontalAlignment.Left;
            drawingSurface.VerticalAlignment = VerticalAlignment.Top;
            _window = new SilverlightGameWindow(this) as GameWindow;
            updateGameTime = new GameTime();
            drawGameTime = new GameTime();
            startingUp = true;
            drawingSurface.Draw += new EventHandler<DrawEventArgs>(drawingSurface_Draw);
            drawingSurface.SizeChanged += new SizeChangedEventHandler(drawingSurface_SizeChanged);
            drawingSurface.Dispatcher.BeginInvoke(() =>
            {
                _currentState = States.Startup;
                SetSize();
                startingUp = false;
            });
        }

        void drawingSurface_SizeChanged(object sender, SizeChangedEventArgs e)
        {
        }

        void SetSize()
        {
            if (!drawingSurface.CheckAccess())
            {
                drawingSurface.Dispatcher.BeginInvoke(() =>
                {
                    SetSize();
                });
                return;
            }
            drawingSurface.Width = preferredWidth;
            drawingSurface.Height = preferredHeight;
            root.Width = preferredWidth;
            root.Height = preferredHeight;
            currentWidth = preferredWidth;
            currentHeight = preferredHeight;
        }

        void drawingSurface_Draw(object sender, DrawEventArgs e)
        {
            if (!startingUp && GraphicsDevice.ScissorRectangle.Width > 1)
            {
                if (applyChanges)
                {
                    SetSize();
                    applyChanges = false;
                }

                if (!_initialized)
                {
                    Initialize();
                    _initialized = true;
                }

                if (_currentState == States.Done) return;

                TimeSpan delta = e.DeltaTime;
                delta += leftoverTime;
                if (resetElapsedTime)
                {
                    delta = TimeSpan.Zero;
                    resetElapsedTime = false;
                }

                drawGameTime.ElapsedGameTime = delta;
                drawGameTime.TotalGameTime += delta;
                if (IsFixedTimeStep)
                {
                    var dt = this.TargetElapsedTime;
                    while (delta > dt)
                    {
                        updateGameTime.ElapsedGameTime = dt;
                        updateGameTime.TotalGameTime += dt;
                        Update(updateGameTime);
                        delta -= dt;
                    }
                    leftoverTime = delta;
                }
                else
                {
                    updateGameTime.ElapsedGameTime = delta;
                    updateGameTime.TotalGameTime += delta;
                    if (updateGameTime.ElapsedGameTime > TimeSpan.Zero) Update(updateGameTime);
                }


                bool ret = BeginDraw();
                if (ret == true)
                {
                    Draw(drawGameTime);
                    EndDraw();
                }
            }
            e.InvalidateSurface();
        }

        protected virtual void OnExiting(object sender, EventArgs e)
        {
        }
        protected virtual void BeginRun() { }
		
		public ContentManager Content
        {
            get
            {
                if (_content == null)
                {
                    _content = new ContentManager(null, "Content");                   
                }
                return _content;
            }
        }

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
            parent.Dispatcher.BeginInvoke(() =>
                {
                    if (Exiting != null) Exiting(this, null);
                    drawingSurface.Draw -= new EventHandler<DrawEventArgs>(drawingSurface_Draw);
                });
        }

        public GameComponentCollection Components 
        {
            get
            {
                return _gameComponentCollection;
            }
        }

        public void Run()
        {
        }

		#region IDisposable Members

		public void Dispose()
		{
		}

		#endregion
	}
}
