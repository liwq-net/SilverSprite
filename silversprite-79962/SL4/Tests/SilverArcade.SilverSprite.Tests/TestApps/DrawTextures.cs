using System;
using System.Net;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;

namespace SilverArcade.SilverSprite.Tests.TestApps
{
    public class DrawTextures : Game
    {
        GraphicsDeviceManager graphics;
        Texture2D _texture;
        SpriteBatch _spriteBatch;
        SpriteFont _font;
        byte _alpha = 0xFF;
        KeyboardState _lastState;
        float _scale = 1.0f;
        SpriteEffects _effect;
        float _rotation = 0.0f;
        Vector2 _origin = new Vector2(0,0);
        Color _color = Color.Yellow;

        public DrawTextures()
        {
            graphics = new GraphicsDeviceManager(this);
            
            Content.RootDirectory = "Content";
        }

        protected override void Update(GameTime gameTime)
        {
            KeyboardState currentState = Keyboard.GetState();

            if (currentState.IsKeyDown(Keys.Escape) && _lastState.IsKeyUp(Keys.Escape))
                this.Exit();

            if (currentState.IsKeyDown(Keys.R) && _lastState.IsKeyUp(Keys.R))
                _rotation += MathHelper.ToRadians(10);

            if (currentState.IsKeyDown(Keys.Z) && _lastState.IsKeyUp(Keys.Z))
                _scale += 0.1f;

            if (currentState.IsKeyDown(Keys.X) && _lastState.IsKeyUp(Keys.X))
                _scale -= 0.1f;

            if (currentState.IsKeyDown(Keys.O) && _lastState.IsKeyUp(Keys.O) && _alpha > 0)
                _alpha -= 25;

            if (currentState.IsKeyDown(Keys.P) && _lastState.IsKeyUp(Keys.P) && _alpha < 255)
                _alpha += 25;

            if (currentState.IsKeyDown(Keys.C) && _lastState.IsKeyUp(Keys.C))
            {
                if (_color == Color.White)
                {
                    _color = Color.Red;
                    return;
                }

                if (_color == Color.Red)
                {
                    _color = Color.Green;
                    return;
                }

                if (_color == Color.Green)
                {
                    _color = Color.Blue;
                    return;
                }

                if (_color == Color.Blue)
                {
                    _color = Color.White;
                    return;
                }
            }

            if (currentState.IsKeyDown(Keys.Up) && _lastState.IsKeyUp(Keys.Up))
                _origin.Y++;

            if (currentState.IsKeyDown(Keys.Down) && _lastState.IsKeyUp(Keys.Down))
                _origin.Y--;

            if (currentState.IsKeyDown(Keys.Left) && _lastState.IsKeyUp(Keys.Left))
                _origin.X--;

            if (currentState.IsKeyDown(Keys.Right) && _lastState.IsKeyUp(Keys.Right))
                _origin.X++;


            if (currentState.IsKeyDown(Keys.E) && _lastState.IsKeyUp(Keys.E))
            {
                switch (_effect)
                {
                    case SpriteEffects.None:
                        _effect = SpriteEffects.FlipVertically;
                        break;
                    case SpriteEffects.FlipVertically:
                        _effect = SpriteEffects.FlipHorizontally;
                        break;
                    case SpriteEffects.FlipHorizontally:
                        _effect = SpriteEffects.None;
                        break;
                }
            }

            _lastState = currentState;

            base.Update(gameTime);
        }

        protected override void Initialize()
        {
            _spriteBatch = new SpriteBatch(graphics.GraphicsDevice);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _font = Content.Load<SpriteFont>("Fonts/Arial");
            _texture = Content.Load<Texture2D>("Textures/SilverSprite200x100");

            base.LoadContent();
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            _spriteBatch.DrawString(_font, "Overload 1", new Vector2(50, 20), Color.Yellow);
            _spriteBatch.Draw(_texture, new Rectangle(50, 50, 200, 100), new Color(_color, _alpha));
            _spriteBatch.DrawString(_font, "Overload 2", new Vector2(225, 20), Color.Yellow);
            _spriteBatch.Draw(_texture, new Vector2(225, 50), new Color(_color, _alpha));
            _spriteBatch.DrawString(_font, "Overload 3", new Vector2(450, 20), Color.Yellow);
            _spriteBatch.Draw(_texture, new Rectangle(450, 50, 200, 100), new Rectangle(10, 10, 100, 50), new Color(_color, _alpha));
            _spriteBatch.DrawString(_font, "Overload 4", new Vector2(50, 150), Color.Yellow);
            _spriteBatch.Draw(_texture, new Vector2(50, 175), new Rectangle(0, 0, 200, 100), new Color(_color, _alpha));
            _spriteBatch.DrawString(_font, "Overload 5", new Vector2(225, 150), Color.Yellow);
            _spriteBatch.Draw(_texture, new Rectangle(225, 175, 200, 100), null, new Color(_color, _alpha), _rotation, _origin, _effect, 0.75f);
            _spriteBatch.DrawString(_font, "Overload 6", new Vector2(450, 150), Color.Yellow);
            _spriteBatch.Draw(_texture, new Vector2(450,175), new Rectangle(0, 0, 200, 100), new Color(_color, _alpha), _rotation, _origin, _scale, _effect, 0.1f);
            _spriteBatch.DrawString(_font, "Overload 7", new Vector2(50, 260), Color.Yellow);
            _spriteBatch.Draw(_texture, new Vector2(50, 280), new Rectangle(0, 0, 200, 100), new Color(_color, _alpha), _rotation, _origin, new Vector2(1.5f, _scale), _effect, 0.1f);
                                    
            _spriteBatch.DrawString(_font, "Z - Scale Up - Overloads (6,7)", new Vector2(50, 375), Color.Yellow);
            _spriteBatch.DrawString(_font, "X - Scale Down - Overloads (6,7)", new Vector2(50, 400), Color.Yellow);
            _spriteBatch.DrawString(_font, "P - Increase Opacity - Overloads (all)", new Vector2(50, 425), Color.Yellow);
            _spriteBatch.DrawString(_font, "O - Decrease Opacity - Overloads (all)", new Vector2(50, 450), Color.Yellow);
            _spriteBatch.DrawString(_font, "R - Rotate - Overloads (5,6,7)", new Vector2(50, 475), Color.Yellow);
            _spriteBatch.DrawString(_font, "E - SpriteEffect - Overloads (5,6,7)", new Vector2(50, 500), Color.Yellow);
            _spriteBatch.DrawString(_font, "Arrow Keys - Move Origin", new Vector2(50, 550), Color.Yellow);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
