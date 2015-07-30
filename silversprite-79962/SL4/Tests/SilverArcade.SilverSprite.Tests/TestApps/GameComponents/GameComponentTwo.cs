using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace SilverArcade.SilverSprite.Tests.TestApps.GameComponents
{
    public class GameComponentTwo : DrawableGameComponent
    {
        Texture2D _textureTwo;
        SpriteBatch _spriteBatch;
        SpriteFont _font;
        string _order;

        public GameComponentTwo(Game game)
            : base(game)
        {

        }

        public override void Initialize()
        {
            DrawOrder = 200;
            _order = "Middle";

            _spriteBatch = new SpriteBatch(Game.GraphicsDevice);
            base.Initialize();
        }

        public void SetOrder(string order)
        {
            this._order = order;

            switch (order.ToLower())
            {
                case "bottom":
                    DrawOrder = 300;
                    break;
                case "middle":
                    DrawOrder = 200;
                    break;
                case "top":
                    DrawOrder = 100;
                    break;
            }
        }

        protected override void LoadContent()
        {
            _textureTwo = Game.Content.Load<Texture2D>("Textures/SilverSpriteImage2");
            _font = Game.Content.Load<SpriteFont>("Fonts/Arial");
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();
            _spriteBatch.DrawString(_font, "Image Two - " + _order + " " + DrawOrder, new Vector2(300, 20), Color.Yellow);
            _spriteBatch.Draw(_textureTwo, new Vector2(50, 50), Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
