using System;
using System.Net;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;

namespace SilverArcade.SilverSprite.Tests.TestApps
{
	public class ViewportTransformTests : Game
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
		Vector2 _origin = new Vector2(0, 0);
		Color _color = Color.Yellow;
		Color _color2 = Color.Red;

		public ViewportTransformTests()
		{
			graphics = new GraphicsDeviceManager(this);

			Content.RootDirectory = "Content";
		}

		protected override void Update(GameTime gameTime)
		{
			KeyboardState currentState = Keyboard.GetState();

			if (currentState.IsKeyDown(Keys.Escape) && _lastState.IsKeyUp(Keys.Escape))
				this.Exit();

			base.Update(gameTime);
		}

		protected override void Initialize()
		{
			_spriteBatch = new SpriteBatch(graphics.GraphicsDevice);
			base.Initialize();
		}

		protected override void LoadContent()
		{
			_texture = Content.Load<Texture2D>("Textures/SilverSprite200x100");

			base.LoadContent();
		}

		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.CornflowerBlue);
			Viewport saved = GraphicsDevice.Viewport;
			Viewport v = saved;
			v.Height = 250;
			GraphicsDevice.Viewport = v;
			_spriteBatch.Begin();
			_spriteBatch.Draw(_texture, new Rectangle(150, 180, 200, 100), new Color(_color, _alpha));
			_spriteBatch.End();
			v.Y = 250;
			GraphicsDevice.Viewport = v;
			Matrix m = Matrix.CreateTranslation(0, -250, 0);
			_spriteBatch.Begin(SpriteBlendMode.AlphaBlend, SpriteSortMode.Immediate, SaveStateMode.None, m);
			_spriteBatch.Draw(_texture, new Rectangle(150, 180, 200, 100), new Color(_color2, _alpha));
			_spriteBatch.End();
			GraphicsDevice.Viewport = saved;
			base.Draw(gameTime);
		}
	}
}
