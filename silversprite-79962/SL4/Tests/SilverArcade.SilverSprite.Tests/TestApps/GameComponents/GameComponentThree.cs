using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SilverArcade.SilverSprite.Tests.TestApps.GameComponents
{
    public class GameComponentThree : DrawableGameComponent
    {
        private Texture2D _textureThree;
        SpriteBatch _spriteBatch;
        SpriteFont _font;
        private string _order;

        public GameComponentThree(Game game)
            : base(game)
        {

        }

        public override void Initialize()
        {
            DrawOrder = 300;
            _order = "Bottom";

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
            _font = Game.Content.Load<SpriteFont>("Fonts/Arial");

            _textureThree = Game.Content.Load<Texture2D>("Textures/SilverSpriteImage3");
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();
            _spriteBatch.DrawString(_font, "Image Three - " + _order + " " + DrawOrder, new Vector2(550, 20), Color.Green);
            _spriteBatch.Draw(_textureThree, new Vector2(50, 50), Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }

    }
}
