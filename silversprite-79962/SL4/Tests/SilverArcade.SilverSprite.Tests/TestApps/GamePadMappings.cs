using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SilverArcade.SilverSprite.Tests.TestApps
{
    public class GamePadMappings : Game
    {
        KeyboardState _lastKeyState;
        GraphicsDeviceManager graphics;
        SpriteBatch _spriteBatch;
        SpriteFont _font;
        GamePadState _lastGameState;
        int _count = 0;

        /// <summary>
        /// Initializes a new instance of the GamePadMappings class.
        /// </summary>
        public GamePadMappings() 
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
#if(SILVERLIGHT)
            this.MapKeyboardToGamePadButton(Buttons.A, Keys.C);
            this.MapKeyboardToGamePadButton(Buttons.LeftTrigger, Keys.D1);
            this.MapKeyboardToGamePadButton(Buttons.RightTrigger, Keys.D2);
            this.MapKeyboardToGamePadButton(Buttons.LeftShoulder, Keys.L);
            this.MapKeyboardToGamePadButton(Buttons.RightShoulder, Keys.R);
#endif
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
            GamePadState currentGameState = GamePad.GetState(PlayerIndex.One);

            KeyboardState currentKeyState = Keyboard.GetState();

            if (currentGameState.Buttons.X == ButtonState.Pressed && _lastGameState.Buttons.X == ButtonState.Released)
                _count++;

            if (currentKeyState.IsKeyDown(Keys.Escape) && _lastKeyState.IsKeyUp(Keys.Escape))
                this.Exit();

            _lastKeyState = currentKeyState;
            _lastGameState = currentGameState;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();

            _spriteBatch.DrawString(_font, "Simple Gamepad Mappings Tests (SilverSprite Only)", new Vector2(50, 20), Color.Yellow);

            _spriteBatch.DrawString(_font, "A Button (Space Key): " + _lastGameState.Buttons.A, new Vector2(50, 70), Color.Yellow);
            _spriteBatch.DrawString(_font, "B Button (Delete Key): " + _lastGameState.Buttons.B, new Vector2(50, 90), Color.Yellow);
            _spriteBatch.DrawString(_font, "X Button (X Key): " + _lastGameState.Buttons.X, new Vector2(50, 110), Color.Yellow);
            _spriteBatch.DrawString(_font, "Y Button (Y Key): " + _lastGameState.Buttons.Y, new Vector2(50, 130), Color.Yellow);

            _spriteBatch.DrawString(_font, "D - Up (Up Arrow): " + _lastGameState.DPad.Up, new Vector2(50, 160), Color.Yellow);
            _spriteBatch.DrawString(_font, "D - Down (Down Arrow): " + _lastGameState.DPad.Down, new Vector2(50, 180), Color.Yellow);
            _spriteBatch.DrawString(_font, "D - Left (Left Arrow): " + _lastGameState.DPad.Left, new Vector2(50, 200), Color.Yellow);
            _spriteBatch.DrawString(_font, "D - Right (Right Arrow): " + _lastGameState.DPad.Right, new Vector2(50, 220), Color.Yellow);

            _spriteBatch.DrawString(_font, "Left Stick (Not Currently Implemented): " + _lastGameState.ThumbSticks.Left.X + "," + _lastGameState.ThumbSticks.Left.Y, new Vector2(50, 250), Color.Yellow);
            _spriteBatch.DrawString(_font, "Right Stick (Not Currently Implemented): " + _lastGameState.ThumbSticks.Right.X + "," + _lastGameState.ThumbSticks.Right.Y, new Vector2(50, 270), Color.Yellow);

            _spriteBatch.DrawString(_font, string.Format("Left Trigger (1 Key): {0:0.00}", _lastGameState.Triggers.Left), new Vector2(50, 300), Color.Yellow);
            _spriteBatch.DrawString(_font, string.Format("Right Trigger (2 Key): {0:0.00}", _lastGameState.Triggers.Right), new Vector2(50, 320), Color.Yellow);

            _spriteBatch.DrawString(_font, "Left Shoulder (L Key): " + _lastGameState.Buttons.LeftShoulder, new Vector2(50, 350), Color.Yellow);
            _spriteBatch.DrawString(_font, "Right Shoulder (R Key): " + _lastGameState.Buttons.RightShoulder, new Vector2(50, 370), Color.Yellow);

            _spriteBatch.DrawString(_font, "Back Button (BackSpace Key): " + _lastGameState.Buttons.Back, new Vector2(50, 400), Color.Yellow);
            _spriteBatch.DrawString(_font, "Start Button(Enter Key): " + _lastGameState.Buttons.Start, new Vector2(50, 420), Color.Yellow);

            _spriteBatch.DrawString(_font, "Custom A Button Mapping (C Key): " + _lastGameState.Buttons.A, new Vector2(50, 450), Color.Yellow);

            _spriteBatch.DrawString(_font, string.Format("Debounce Test: Press X Mapping to increment number by exacly one: {0}", _count), new Vector2(50, 480), Color.Yellow);

            _spriteBatch.End();

            base.Draw(gameTime);
        }

    }
}
