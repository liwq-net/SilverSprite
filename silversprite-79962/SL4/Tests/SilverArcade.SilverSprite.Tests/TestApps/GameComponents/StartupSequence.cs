using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SilverArcade.SilverSprite.Tests.TestApps.GameComponents
{
    public class StartupSequence : DrawableGameComponent
    {
        private Texture2D _textureOne;
        SpriteBatch _spriteBatch;
        SpriteFont _font;
        private bool _drawCaptured = false;
        private bool _updateCaptured = false;

        public StartupSequence(Game game)
            : base(game)
        {
            Tests.TestApps.StartupSequence.CurrentInstance.StartupSequenceBuilder.AppendLine("Game Component - Constructor");
        }

        public override void Initialize()
        {
            DrawOrder = 100;
            UpdateOrder = 1;

            Tests.TestApps.StartupSequence.CurrentInstance.StartupSequenceBuilder.AppendLine("Game Component - Initialize");

            _spriteBatch = new SpriteBatch(Game.GraphicsDevice);
            base.Initialize();
        }

        protected override void OnDrawOrderChanged(object sender, EventArgs args)
        {
            base.OnDrawOrderChanged(sender, args);
        }

        protected override void OnUpdateOrderChanged(object sender, EventArgs args)
        {
            base.OnUpdateOrderChanged(sender, args);
        }

        protected override void OnEnabledChanged(object sender, EventArgs args)
        {
            base.OnEnabledChanged(sender, args);
        }

        protected override void OnVisibleChanged(object sender, EventArgs args)
        {
            base.OnVisibleChanged(sender, args);
        }

        protected override void UnloadContent()
        {
            Tests.TestApps.StartupSequence.CurrentInstance.StartupSequenceBuilder.AppendLine("Game Component - Unload Content");            

            base.UnloadContent();
        }


        protected override void LoadContent()
        {
            Tests.TestApps.StartupSequence.CurrentInstance.StartupSequenceBuilder.AppendLine("Game Component - Load Content");

            _textureOne = Game.Content.Load<Texture2D>("Textures/SilverSprite200x100");
            _font = Game.Content.Load<SpriteFont>("Fonts/Arial");
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            if (!_updateCaptured)
            {
                Tests.TestApps.StartupSequence.CurrentInstance.StartupSequenceBuilder.AppendLine("Game Component - Update");
                _updateCaptured = true;
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            if (!_drawCaptured)
            {
                Tests.TestApps.StartupSequence.CurrentInstance.StartupSequenceBuilder.AppendLine("Game Component - Draw");
                _drawCaptured = true;
            }

            _spriteBatch.Begin();
            _spriteBatch.DrawString(_font, "Startup Sequence", new Vector2(300, 20), Color.Red);
            _spriteBatch.Draw(_textureOne, new Vector2(300, 50), Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }

    }
}
