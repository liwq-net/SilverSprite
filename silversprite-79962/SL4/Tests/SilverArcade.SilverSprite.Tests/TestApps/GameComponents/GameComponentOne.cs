using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SilverArcade.SilverSprite.Tests.TestApps.GameComponents
{
    public class GameComponentOne : DrawableGameComponent
    {
        private Texture2D _textureOne;
        SpriteBatch _spriteBatch;
        SpriteFont _font;

        public GameComponentOne(Game game)
            : base(game)
        {

        }

        public override void Initialize()
        {
            DrawOrder = 100;
            UpdateOrder = 1;
            TextOrder = "Top";

            _spriteBatch = new SpriteBatch(Game.GraphicsDevice);
            base.Initialize();
        }

        public void SetOrder(string order)
        {
            TextOrder = order;

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

        public string TextOrder { get; private set; }

        protected override void LoadContent()
        {
            _textureOne = Game.Content.Load<Texture2D>("Textures/SilverSpriteImage1");
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
            _spriteBatch.DrawString(_font, "Image One - " + TextOrder + " " + DrawOrder, new Vector2(50, 20), Color.Red);
            _spriteBatch.Draw(_textureOne, new Vector2(50, 50), Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }

    }
}
