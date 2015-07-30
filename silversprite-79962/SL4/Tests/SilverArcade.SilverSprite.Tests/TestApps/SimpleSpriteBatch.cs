using System;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace SilverArcade.SilverSprite.Tests.TestApps
{
    public class SimpleSpriteBatch : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch _spriteBatch;
        SpriteFont _font;
        KeyboardState _lastState;
        float _rotation = 0;
        float _scale = 1.0f;
        byte _alpha = 0xff;

        Vector2 _origin;

        SpriteEffects _spriteEffect = SpriteEffects.None;

        public SimpleSpriteBatch()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            
            _origin = new Vector2(0, 0);            
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

            if (currentState.IsKeyDown(Keys.Escape) && _lastState.IsKeyUp(Keys.Escape))
                this.Exit();

            if (currentState.IsKeyDown(Keys.R) && _lastState.IsKeyUp(Keys.R))
                _rotation += MathHelper.ToRadians(10);


            if (currentState.IsKeyDown(Keys.O) && _lastState.IsKeyUp(Keys.O) && _alpha > 0)
                _alpha -= 25;

            if (currentState.IsKeyDown(Keys.P) && _lastState.IsKeyUp(Keys.P) && _alpha < 255)
                _alpha += 25;

            if (currentState.IsKeyDown(Keys.Z) && _lastState.IsKeyUp(Keys.Z))
                _scale += 0.1f;

            if (currentState.IsKeyDown(Keys.X) && _lastState.IsKeyUp(Keys.X))
                _scale -= 0.1f;

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
                switch (_spriteEffect)
                {
                    case SpriteEffects.None:
                        _spriteEffect = SpriteEffects.FlipVertically;
                        break;
                    case SpriteEffects.FlipVertically:
                        _spriteEffect = SpriteEffects.FlipHorizontally;
                        break;
                    case SpriteEffects.FlipHorizontally:
                        _spriteEffect = SpriteEffects.None;
                        break;
                }
            }

            _lastState = currentState;

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            _spriteBatch.DrawString(_font, "STATIC TEXT - Overload 1, simple position & color", new Vector2(10, 10), new Color(255, 255, 0, _alpha));

            var bldr = new StringBuilder();
            bldr.Append("STATIC TEXT Overload 2 - String Builder");
            _spriteBatch.DrawString(_font, bldr, new Vector2(10, 30), new Color(255, 255, 0, _alpha));

            _spriteBatch.DrawString(_font, "String Overload 3 ", new Vector2(10, 50), new Color(255, 255, 0, _alpha), 0.0f, _origin, _scale, _spriteEffect, 0.1f);
            _spriteBatch.DrawString(_font, "String Overload 4 - Constant Width, height should scale", new Vector2(10, 70), new Color(255, 255, 0, _alpha), _rotation, _origin, new Vector2(1.5f, _scale), _spriteEffect, 0.1f);

            bldr = new StringBuilder();
            bldr.Append("StrBldr Overload 5");
            _spriteBatch.DrawString(_font, bldr, new Vector2(10, 90), new Color(255, 255, 0, _alpha), _rotation, _origin, _scale, _spriteEffect, 0.1f);

            bldr = new StringBuilder();
            bldr.Append("StrBldr Overload 6 - Constant Width, height should scale");
            _spriteBatch.DrawString(_font, bldr, new Vector2(10, 120), new Color(255, 255, 0, _alpha), _rotation, _origin, new Vector2(1.5f, _scale), _spriteEffect, 0.1f);

            _spriteBatch.DrawString(_font, "R - Rotate - Overloads (3,4,5,6)", new Vector2(50, 150), Color.Yellow);
            _spriteBatch.DrawString(_font, "Z - Scale Up - Overloads (3,4,5,6)", new Vector2(50, 175), Color.Yellow);
            _spriteBatch.DrawString(_font, "X - Scale Down - Overloads (3,4,5,6)", new Vector2(50, 200), Color.Yellow);
            _spriteBatch.DrawString(_font, "P - Increase Opacity - Overloads (all)", new Vector2(50, 225), Color.Yellow);
            _spriteBatch.DrawString(_font, "O - Decrease Opacity - Overloads (all)", new Vector2(50, 250), Color.Yellow);

            _spriteBatch.DrawString(_font, "E - Change Sprite Effect - Overloads (3,4,5,6)", new Vector2(50, 275), Color.Yellow);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
