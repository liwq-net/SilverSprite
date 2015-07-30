using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SilverArcade.SilverSprite.Tests.TestApps
{
    public class DrawOrderTests : Game
    {
        private SilverArcade.SilverSprite.Tests.TestApps.GameComponents.GameComponentOne _componentOne;
        private SilverArcade.SilverSprite.Tests.TestApps.GameComponents.GameComponentTwo _componentTwo;
        private SilverArcade.SilverSprite.Tests.TestApps.GameComponents.GameComponentThree _componentThree;
        GraphicsDeviceManager graphics;
        KeyboardState _lastState;
        SpriteBatch _spriteBatch;
        SpriteFont _font;

        /// <summary>
        /// Initializes a new instance of the DrawOrderTests class.
        /// </summary>
        public DrawOrderTests()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            _componentOne = new GameComponents.GameComponentOne(this);
            _componentTwo = new GameComponents.GameComponentTwo(this);
            _componentThree = new GameComponents.GameComponentThree(this);

            
            
            this.Components.Add(_componentOne);
            this.Components.Add(_componentTwo);
            this.Components.Add(_componentThree);
        }

        protected override void Initialize()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
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

            if (currentState.IsKeyDown(Keys.O) && _lastState.IsKeyUp(Keys.O))
            {
                switch (_componentOne.TextOrder.ToLower())
                {
                    case "top":
                        _componentOne.SetOrder("Middle");
                        _componentTwo.SetOrder("Bottom");
                        _componentThree.SetOrder("Top");
                        break;
                    case "middle":
                        _componentOne.SetOrder("Bottom");
                        _componentTwo.SetOrder("Top");
                        _componentThree.SetOrder("Middle");
                        break;
                    case "bottom":
                        _componentOne.SetOrder("Top");
                        _componentTwo.SetOrder("Middle");
                        _componentThree.SetOrder("Bottom");
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
            _spriteBatch.DrawString(_font, "Press 'O' to change draw order\r\nLowest to Highest 100 should be on top.", new Vector2(20, 400), Color.Yellow);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
