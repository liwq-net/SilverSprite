using System;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace SilverArcade.SilverSprite.Tests.TestApps
{
    public class StartupSequence : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch _spriteBatch;
        SpriteFont _font;
        KeyboardState _lastState;
        private bool _drawCaptured = false;
        private bool _beginDrawCaptured = false;
        private bool _endDrawCaptured = false;
        private bool _updateCaptured = false;
        public StringBuilder StartupSequenceBuilder;

        public static StartupSequence CurrentInstance;

        public StartupSequence()
        {
            CurrentInstance = this;

            StartupSequenceBuilder = new StringBuilder();

            StartupSequenceBuilder.AppendLine("Main - Begin Constructor");

            graphics = new GraphicsDeviceManager(this);         
            Content.RootDirectory = "Content";

            Components.Add(new GameComponents.StartupSequence(this));

            StartupSequenceBuilder.AppendLine("Main - End Constuctor");
        }


        protected override void OnExiting(object sender, EventArgs e)
        {
            StartupSequenceBuilder.AppendLine("Main - Exiting");

            base.OnExiting(sender, e);
        }

        protected override void Initialize()
        {
            _spriteBatch = new SpriteBatch(graphics.GraphicsDevice);

            StartupSequenceBuilder.AppendLine("Main - Initialize");
            base.Initialize();
        }

        protected override bool BeginDraw()
        {
            if (!_beginDrawCaptured)
            {
                StartupSequenceBuilder.AppendLine("Main - Begin Draw");
                _beginDrawCaptured = true;
            }            

            return base.BeginDraw();
        }

        protected override void EndDraw()
        {
            if (!_endDrawCaptured)
            {
                StartupSequenceBuilder.AppendLine("Main - End Draw");
                _endDrawCaptured = true;
            }

            base.EndDraw();
        }

        protected override void OnActivated(object sender, EventArgs args)
        {
            StartupSequenceBuilder.AppendLine("Main - On Activated");

            base.OnActivated(sender, args);
        }

        protected override void OnDeactivated(object sender, EventArgs args)
        {
            StartupSequenceBuilder.AppendLine("Main - On Deactivated");

             base.OnDeactivated(sender, args);
        }

        protected override void EndRun()
        {
            StartupSequenceBuilder.AppendLine("Main - On End Run");

            base.EndRun();
        }

        protected override void LoadContent()
        {
            StartupSequenceBuilder.AppendLine("Main - Load Content");
            _font = Content.Load<SpriteFont>("Fonts/Arial");

            base.LoadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            if (!_updateCaptured)
            {
                StartupSequenceBuilder.AppendLine("Main - Update");
                _updateCaptured = true;
            }

            KeyboardState currentState = Keyboard.GetState();

            if (currentState.IsKeyDown(Keys.Escape) && _lastState.IsKeyUp(Keys.Escape))
                this.Exit();

            _lastState = currentState;


            base.Update(gameTime);
        }

        protected override void UnloadContent()
        {
            base.UnloadContent();
        }

        protected override void BeginRun()
        {
            StartupSequenceBuilder.AppendLine("Main - Begin Run");
            base.BeginRun();
        }

        protected override void Draw(GameTime gameTime)
        {
            if (!_drawCaptured)
            {
                StartupSequenceBuilder.AppendLine("Main - Draw");
                _drawCaptured = true;
            }

            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            _spriteBatch.DrawString(_font, StartupSequenceBuilder, new Vector2(5, 5), Color.Yellow);
            _spriteBatch.End();

            base.Draw(gameTime);
        }


    }
}
