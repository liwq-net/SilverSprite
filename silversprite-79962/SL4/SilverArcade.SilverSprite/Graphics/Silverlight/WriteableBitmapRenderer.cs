using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using System.Windows.Media.Imaging;

namespace SilverArcade.SilverSprite.Graphics
{
	public class WriteableBitmapRenderer : SilverlightRenderBase
	{
		WriteableBitmapChildRenderer _currentChildRenderer;
		Canvas _canvas;
		int _width;
		int _height;
		WriteableBitmap _renderBmp;
		bool changed;
		bool somethingWasDrawn = false;

		List<WriteableBitmapChildRenderer> _childRenderers = new List<WriteableBitmapChildRenderer>();
		int _currentIndex;

		public WriteableBitmapRenderer(int width, int height)
		{
			_width = width;
			_height = height;
			_canvas = new Canvas();
			_canvas.Width = _width;
			_canvas.Height = _height;
			Root = _canvas;
		}

		void GetCurrentRenderer()
		{
			if (_currentIndex < _childRenderers.Count)
			{
				_currentChildRenderer = _childRenderers[_currentIndex];
			}
			else
			{
				_currentChildRenderer = new WriteableBitmapChildRenderer(_width, _height);
				_childRenderers.Add(_currentChildRenderer);
				_canvas.Children.Add(_currentChildRenderer.Root);
			}
			_currentIndex++;
		}

		public override void BeforeDraw()
		{
			_currentIndex = 0;
			foreach (WriteableBitmapChildRenderer r in _childRenderers)
			{
				r.BeforeDraw();
			}
			GetCurrentRenderer();
			changed = false;
			somethingWasDrawn = false;
		}

		public override void AfterDraw()
		{
			foreach (WriteableBitmapChildRenderer r in _childRenderers)
			{
				bool vis = r.Visible;
				r.AfterDraw();
				if (r.Visible != vis) changed=true;
			}

			this.Visible = somethingWasDrawn;
			base.AfterDraw();
		}

		public override void Clear(Microsoft.Xna.Framework.Graphics.Color color)
		{
			_currentChildRenderer.Clear(color);
			somethingWasDrawn = true;
		}

		public override void Begin(Microsoft.Xna.Framework.Graphics.GraphicsDevice device, Microsoft.Xna.Framework.Graphics.SpriteBlendMode blendMode, Microsoft.Xna.Framework.Graphics.SpriteSortMode sortMode, Microsoft.Xna.Framework.Graphics.SaveStateMode stateMode, Microsoft.Xna.Framework.Matrix transformMatrix)
		{
			base.Begin(device, blendMode, sortMode, stateMode, transformMatrix);
			_currentChildRenderer.Begin(device, blendMode, sortMode, stateMode, transformMatrix);
		}

		public override void End()
		{
			if (_canvas.Children.Contains(_currentChildRenderer.Root) == false)
			{
				changed = true;
			}
			_currentChildRenderer.changed = false;
			base.End();
			if (_currentChildRenderer.changed)
			{
				_currentChildRenderer.Invalidate();
				changed = true;
			} 
			GetCurrentRenderer();
		}

		public override Texture2D GetTexture(GraphicsDevice device)
		{
			if (texture == null)
			{
				texture = new Texture2D(device, (int)Root.Width, (int)Root.Height);
			}
			else if (texture.Width != (int)Root.Width || texture.Height != (int)Root.Height)
			{
				texture = new Texture2D(device, (int)Root.Width, (int)Root.Height);
			}
			if (changed)
			{
				if (_renderBmp == null || _renderBmp.PixelWidth != Root.Width || _renderBmp.PixelHeight != Root.Height)
				{
					_renderBmp = new WriteableBitmap((int)Root.Width, (int)Root.Height);
				}
				_renderBmp.Render(Root, null);
				_renderBmp.Invalidate();
				texture.ImageSource = _renderBmp;
				texture.IsDirty = true;
			}
			changed = false;
			return texture;
		}

		internal override void Draw(DrawCommand cmd)
		{
			somethingWasDrawn = true;
			base.Draw(cmd);
			_currentChildRenderer.Draw(cmd);
		}

		protected override void Draw(Texture2D texture, Microsoft.Xna.Framework.Vector2 position, ref Microsoft.Xna.Framework.DoubleRectangle sourceRectangle, Microsoft.Xna.Framework.Graphics.Color color, float rotation, Microsoft.Xna.Framework.Vector2 origin, Microsoft.Xna.Framework.Vector2 scale, SpriteEffects effects, float layerDepth)
		{
			_currentChildRenderer.Draw(texture, position, ref sourceRectangle, color, rotation, origin, scale, effects, layerDepth);
		}

		protected override void Draw(Texture2D texture, Microsoft.Xna.Framework.Vector2 position, ref Microsoft.Xna.Framework.DoubleRectangle sourceRectangle, System.Windows.Media.Effects.ShaderEffect shaderEffect, float rotation, Microsoft.Xna.Framework.Vector2 origin, Microsoft.Xna.Framework.Vector2 scale, SpriteEffects effects, float layerDepth)
		{
			_currentChildRenderer.Draw(texture, position, ref sourceRectangle, shaderEffect, rotation, origin, scale, effects, layerDepth);
		}

		internal override void DrawAll(IEnumerable<DrawCommand> cmds)
		{
			_currentChildRenderer.DrawAll(cmds);
		}

		public override void DrawString(SpriteFont spriteFont, string text, Microsoft.Xna.Framework.Vector2 position, Microsoft.Xna.Framework.Graphics.Color color, float rotation, Microsoft.Xna.Framework.Vector2 origin, Microsoft.Xna.Framework.Vector2 scale, SpriteEffects effects, float layerDepth)
		{
			_currentChildRenderer.DrawString(spriteFont, text, position, color, rotation, origin, scale, effects, layerDepth);
		}
	}
}
