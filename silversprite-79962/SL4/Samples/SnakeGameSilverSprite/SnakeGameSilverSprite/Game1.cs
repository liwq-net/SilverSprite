using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Storage;

namespace SnakeGame
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D snakeSegment;
        Texture2D fruit;
        Vector2 fruitPosition;

        List<Vector2> snake = new List<Vector2>();
        int width;
        int height;
        float scale = 1;
        SoundEffect blip;
        SoundEffect fanfare;
        TimeSpan moveDelay = TimeSpan.FromSeconds(.5);
        TimeSpan timeSinceLastMove = TimeSpan.Zero;
        Vector2 velocity = new Vector2(1, 0);
        Vector2 lastVelocity = new Vector2(1, 0);
        Random rand = new Random();
        int score = 0;
        SpriteFont beckerBlack;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
	//		graphics.PreferredBackBufferFormat = SurfaceFormat.Rgba32;
    //        graphics.PreferredBackBufferWidth = 240;
    //        graphics.PreferredBackBufferHeight = 320;
    //        scale = .5f;
        }

        bool CollidesWithSnake(Vector2 pos)
        {
            foreach (Vector2 snakePos in snake)
            {
                if (snakePos == pos) return true;
            }
            return false;
        }

        void SetFruitPosition()
        {
            while (true)
            {
                fruitPosition = new Vector2(rand.Next(width), rand.Next(height));
                if (CollidesWithSnake(fruitPosition) == false) return;
            }
        }
        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
			GraphicsDevice.BitmapCacheEnabled = true;
			graphics.GraphicsDevice.Root.CacheMode = new System.Windows.Media.BitmapCache();
            // TODO: Add your initialization logic here
            width = (int)(graphics.GraphicsDevice.Viewport.Width / (31 * scale));
            height = (int)(graphics.GraphicsDevice.Viewport.Height / (31 * scale));
            snake.Clear();
            for (int i = 0; i < 6; i++)
            {
                snake.Add(new Vector2((width / 2 - 3) + i, height / 2));
            }
            SetFruitPosition();
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            fruit = Content.Load<Texture2D>("fruit");
            snakeSegment = Content.Load<Texture2D>("snakeSegment");
            blip = Content.Load<SoundEffect>("blip");
            fanfare = Content.Load<SoundEffect>("fanfare");
            beckerBlack = Content.Load<SpriteFont>("beckerBlack");
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            timeSinceLastMove += gameTime.ElapsedGameTime;
            Vector2 pos = snake[snake.Count - 1];
            Vector2 newVelocity = lastVelocity;
            GamePadState gs = GamePad.GetState(PlayerIndex.One);
            if (gs.IsButtonDown(Buttons.DPadLeft))
            {
                newVelocity = new Vector2(-1, 0);
            }
            else if (gs.IsButtonDown(Buttons.DPadRight))
            {
                newVelocity = new Vector2(1, 0);
            }
            else if (gs.IsButtonDown(Buttons.DPadUp))
            {
                newVelocity = new Vector2(0, -1);
            }
            else if (gs.IsButtonDown(Buttons.DPadDown))
            {
                newVelocity = new Vector2(0, 1);
            }
            if (newVelocity != -lastVelocity)
            {
                velocity = newVelocity;
            }
            if (timeSinceLastMove >= moveDelay)
            {
                lastVelocity = velocity;
                Vector2 newPos = pos + velocity;
                if (newPos != fruitPosition)
                {
                    snake.RemoveAt(0);
                    snake.Add(newPos);
                    blip.Play(1);
                }
                else
                {
                    snake.Add(newPos);
                    SetFruitPosition();
                    score += 100;
                    fanfare.Play(.5f);
                }
                timeSinceLastMove = TimeSpan.Zero;
            }
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            Matrix scaleTransform = Matrix.CreateScale(scale);
            spriteBatch.Begin(SpriteBlendMode.AlphaBlend, SpriteSortMode.Immediate, SaveStateMode.None, scaleTransform);
            spriteBatch.DrawString(beckerBlack, "Score = " + score.ToString(), new Vector2(50, 50), Color.Red);
			spriteBatch.Draw(fruit, fruitPosition * 31, Color.White);
			foreach (Vector2 pos in snake)
            {
                spriteBatch.Draw(snakeSegment, pos * 31, Color.White);
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
