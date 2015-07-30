using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;

namespace SilverArcade.SilverSprite.Tests.TestApps
{
    public class KeyHandling : Game
    {        
        GraphicsDeviceManager graphics;
        SpriteBatch _spriteBatch;
        SpriteFont _font;
        KeyboardState _lastState;

        string message = string.Empty;
        string keyADownStatus = string.Empty;
        int _count = 0;

        public KeyHandling()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";            
        }

        protected override void Initialize()
        {
            _spriteBatch = new SpriteBatch(graphics.GraphicsDevice);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _font = Content.Load<SpriteFont>("Fonts/Arial");

            base.LoadContent();
        }


        protected override void Update(GameTime gameTime)
        {
            KeyboardState currentState = Keyboard.GetState();

            keyADownStatus = (currentState.IsKeyDown(Keys.A)).ToString();

            if (currentState.IsKeyDown(Keys.B) && _lastState.IsKeyUp(Keys.B))
                _count++;

            if (currentState.IsKeyDown(Keys.Escape) && _lastState.IsKeyUp(Keys.Escape))
                this.Exit();

            _lastState = currentState;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            _spriteBatch.DrawString(_font, "Simple Keyboard Tests", new Vector2(50, 50), Color.Yellow);
            _spriteBatch.DrawString(_font, "Key Down Test: Is Key A Down? " + keyADownStatus, new Vector2(70, 150), Color.Yellow);
            _spriteBatch.DrawString(_font, string.Format("Debounce Test: Press B to increment number by exacly one: {0}", _count), new Vector2(70, 250), Color.Yellow);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
