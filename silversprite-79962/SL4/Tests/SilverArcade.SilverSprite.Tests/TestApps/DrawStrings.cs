using System;
using System.Net;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;

namespace SilverArcade.SilverSprite.Tests.TestApps
{
    public class DrawStrings : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch _spriteBatch;
        SpriteFont _font;
        KeyboardState _lastState;
        
        string message = string.Empty;
        string keyADownStatus = string.Empty;

        private Overloads _overload;

        private enum Overloads
        {
            Overload3,
            Overload4,
            Overload5,
            Overload6
        }


        public DrawStrings()
        {
            graphics = new GraphicsDeviceManager(this);
            
            Content.RootDirectory = "Content";
            _overload = Overloads.Overload3;
        }

        protected override void LoadContent()
        {
            _font = Content.Load<SpriteFont>("Fonts/Arial");
            

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

            if (currentState.IsKeyDown(Keys.Escape) && _lastState.IsKeyUp(Keys.Escape))
                this.Exit();

            if (_overload == Overloads.Overload6)
                _overload = Overloads.Overload3;
            else
            {
                if (currentState.IsKeyDown(Keys.O) && _lastState.IsKeyUp(Keys.O))
                    _overload++;
            }

            _lastState = currentState;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            var bldr1 = new StringBuilder();
            var bldr2 = new StringBuilder();
            var bldr3 = new StringBuilder();

            bldr1.Append("TEXT ON TOP");
            bldr2.Append("TEXT IN MIDDLE");
            bldr3.Append("TEXT ON BOTTOM");

            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin(SpriteBlendMode.AlphaBlend, SpriteSortMode.BackToFront, SaveStateMode.SaveState);

            _spriteBatch.DrawString(_font, "Test Front To Back", new Vector2(10, 20), Color.White, 0.0f, Vector2.Zero, 2.0f, SpriteEffects.None, 0.1f);

            switch (_overload)
            {
                case Overloads.Overload3:
                    _spriteBatch.DrawString(_font, "TEXT IN MIDDLE", new Vector2(55, 55), Color.Yellow, 0.0f, Vector2.Zero, 2.5f, SpriteEffects.None, 0.2f);
                    _spriteBatch.DrawString(_font, "TEXT ON TOP", new Vector2(50, 50), Color.Green, 0.0f, Vector2.Zero, 2.5f, SpriteEffects.None, 0.1f);
                    _spriteBatch.DrawString(_font, "TEXT ON BOTTOM", new Vector2(60, 60), Color.Navy, 0.0f, Vector2.Zero, 2.5f, SpriteEffects.None, 0.3f);
                    break;
                case Overloads.Overload4:
                    _spriteBatch.DrawString(_font, "TEXT IN MIDDLE", new Vector2(55, 55), Color.Yellow, 0.0f, Vector2.Zero, new Vector2(2.5f, 2.5f), SpriteEffects.None, 0.2f);
                    _spriteBatch.DrawString(_font, "TEXT ON TOP", new Vector2(50, 50), Color.Green, 0.0f, Vector2.Zero, new Vector2(2.5f, 2.5f), SpriteEffects.None, 0.1f);
                    _spriteBatch.DrawString(_font, "TEXT ON BOTTOM", new Vector2(60, 60), Color.Navy, 0.0f, Vector2.Zero, new Vector2(2.5f, 2.5f), SpriteEffects.None, 0.3f);
                    break;
                case Overloads.Overload5:
                    _spriteBatch.DrawString(_font, bldr2, new Vector2(55, 55), Color.Yellow, 0.0f, Vector2.Zero, 2.5f, SpriteEffects.None, 0.2f);
                    _spriteBatch.DrawString(_font, bldr1, new Vector2(50, 50), Color.Green, 0.0f, Vector2.Zero, 2.5f, SpriteEffects.None, 0.1f);
                    _spriteBatch.DrawString(_font, bldr3, new Vector2(60, 60), Color.Navy, 0.0f, Vector2.Zero, 2.5f, SpriteEffects.None, 0.3f);
                    break;
                case Overloads.Overload6:
                    _spriteBatch.DrawString(_font, bldr2, new Vector2(55, 55), Color.Yellow, 0.0f, Vector2.Zero, new Vector2(2.5f, 2.5f), SpriteEffects.None, 0.2f);
                    _spriteBatch.DrawString(_font, bldr1, new Vector2(50, 50), Color.Green, 0.0f, Vector2.Zero, new Vector2(2.5f, 2.5f), SpriteEffects.None, 0.1f);
                    _spriteBatch.DrawString(_font, bldr3, new Vector2(60, 60), Color.Navy, 0.0f, Vector2.Zero, new Vector2(2.5f, 2.5f), SpriteEffects.None, 0.3f);
                    break;
            }
            _spriteBatch.End(); 

            _spriteBatch.Begin(SpriteBlendMode.AlphaBlend, SpriteSortMode.FrontToBack, SaveStateMode.SaveState);
            _spriteBatch.DrawString(_font, "Back to Front", new Vector2(10, 140), Color.White, 0.0f, Vector2.Zero, 2.0f, SpriteEffects.None, 0.1f);
            switch (_overload)
            {
                case Overloads.Overload3:
                    _spriteBatch.DrawString(_font, "TEXT IN MIDDLE", new Vector2(55, 185), Color.Yellow, 0.0f, Vector2.Zero, 2.5f, SpriteEffects.None, 0.2f);
                    _spriteBatch.DrawString(_font, "TEXT ON TOP", new Vector2(50, 180), Color.Green, 0.0f, Vector2.Zero, 2.5f, SpriteEffects.None, 0.3f);
                    _spriteBatch.DrawString(_font, "TEXT ON BOTTOM", new Vector2(60, 190), Color.Navy, 0.0f, Vector2.Zero, 2.5f, SpriteEffects.None, 0.1f);
                    
                    break;
                case Overloads.Overload4:
                    _spriteBatch.DrawString(_font, "TEXT IN MIDDLE", new Vector2(55, 185), Color.Yellow, 0.0f, Vector2.Zero, new Vector2(2.5f, 2.5f), SpriteEffects.None, 0.2f);
                    _spriteBatch.DrawString(_font, "TEXT ON TOP", new Vector2(50, 180), Color.Green, 0.0f, Vector2.Zero, new Vector2(2.5f, 2.5f), SpriteEffects.None, 0.3f);
                    _spriteBatch.DrawString(_font, "TEXT ON BOTTOM", new Vector2(60, 190), Color.Navy, 0.0f, Vector2.Zero, new Vector2(2.5f, 2.5f), SpriteEffects.None, 0.1f);                    
                    break;
                case Overloads.Overload5:
                    _spriteBatch.DrawString(_font, bldr2, new Vector2(55, 185), Color.Yellow, 0.0f, Vector2.Zero, 2.5f, SpriteEffects.None, 0.2f);
                    _spriteBatch.DrawString(_font, bldr1, new Vector2(50, 180), Color.Green, 0.0f, Vector2.Zero, 2.5f, SpriteEffects.None, 0.3f);
                    _spriteBatch.DrawString(_font, bldr3, new Vector2(60, 190), Color.Navy, 0.0f, Vector2.Zero, 2.5f, SpriteEffects.None, 0.1f);                    
                    break;
                case Overloads.Overload6:
                    _spriteBatch.DrawString(_font, bldr2, new Vector2(55, 185), Color.Yellow, 0.0f, Vector2.Zero, new Vector2(2.5f, 2.5f), SpriteEffects.None, 0.2f);
                    _spriteBatch.DrawString(_font, bldr1, new Vector2(50, 180), Color.Green, 0.0f, Vector2.Zero, new Vector2(2.5f, 2.5f), SpriteEffects.None, 0.3f);
                    _spriteBatch.DrawString(_font, bldr3, new Vector2(60, 190), Color.Navy, 0.0f, Vector2.Zero, new Vector2(2.5f, 2.5f), SpriteEffects.None, 0.1f);                    
                    break;
            }

            _spriteBatch.End();

            _spriteBatch.Begin(SpriteBlendMode.AlphaBlend, SpriteSortMode.BackToFront, SaveStateMode.SaveState);
            _spriteBatch.DrawString(_font, "Press O to toggle through overloads", new Vector2(10, 300), Color.Yellow, 0.0f, Vector2.Zero, 2.0f, SpriteEffects.None, 0.1f);
            _spriteBatch.DrawString(_font, "Current: " + _overload, new Vector2(10, 340), Color.Yellow, 0.0f, Vector2.Zero, 2.0f, SpriteEffects.None, 0.1f);
            _spriteBatch.End(); 
            
            base.Draw(gameTime);
        }
    }
}
