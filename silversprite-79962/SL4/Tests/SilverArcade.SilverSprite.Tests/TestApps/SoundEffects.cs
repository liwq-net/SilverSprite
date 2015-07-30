using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;

namespace SilverArcade.SilverSprite.Tests.TestApps
{
    public class SoundEffects : Game
    {
        GraphicsDeviceManager graphics;
        SoundEffect _sound;
        SoundEffectInstance _instance;
        SpriteFont _font;
        KeyboardState _lastState;
        SpriteBatch _spriteBatch;

        public SoundEffects()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void LoadContent()
        {
            _font = Content.Load<SpriteFont>("Fonts/Arial");
            _sound = Content.Load<SoundEffect>("Audio/Splash");
            
            base.LoadContent();
        }

        protected override void Initialize()
        {
            _spriteBatch = new SpriteBatch(graphics.GraphicsDevice);
            base.Initialize();
        }

        protected override void Update(GameTime gameTime)
        {
            KeyboardState currentState = Keyboard.GetState();

            if (currentState.IsKeyDown(Keys.S) && _lastState.IsKeyUp(Keys.S))
            {
				if (_instance != null)
					_instance.Play();
				else
				{
					_instance = _sound.CreateInstance();
					_instance.Play();
				}
            }

            if (currentState.IsKeyDown(Keys.X) && _lastState.IsKeyUp(Keys.X))
            {
                if (_instance == null)
				{
					_instance = _sound.CreateInstance();
					_instance.Play();
				}
                else
                {
                    _instance.Volume += 0.1f;
                    _instance.Play();
                }
            }

            if (currentState.IsKeyDown(Keys.R) && _lastState.IsKeyUp(Keys.R))
            {
                if (_instance == null)
                {
					_instance = _sound.CreateInstance();
					_instance.Play();
				}
                else
                {
                    _instance.Volume -= 0.1f;
                    _instance.Play();
                }
            }

            if (currentState.IsKeyDown(Keys.Z) && _lastState.IsKeyUp(Keys.Z))
            {
                if (_instance == null)
                {
					_instance = _sound.CreateInstance();
					_instance.Play();
				}
                else
                {
                    _instance.Volume -= 0.1f;
                    _instance.Play();
                }
            }

            if (currentState.IsKeyDown(Keys.Escape) && _lastState.IsKeyUp(Keys.Escape))
                this.Exit();

            _lastState = currentState;

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            _spriteBatch.DrawString(_font, "Press S to play Splash", new Vector2(50, 50), Color.Yellow);
            if(_instance != null)
                _spriteBatch.DrawString(_font, "X - Volume Up, Z - Volume Down : Current " + string.Format("{0:0.00}",_instance.Volume), new Vector2(50, 70), Color.Yellow);
            else
                _spriteBatch.DrawString(_font, "X - Volume Up, Z - Volume Down", new Vector2(50, 70), Color.Yellow);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
