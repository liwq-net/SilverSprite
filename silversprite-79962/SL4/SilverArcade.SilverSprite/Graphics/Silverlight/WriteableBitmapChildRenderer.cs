using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using SWM = System.Windows.Media;
using System.Windows.Media.Animation;
using SWS = System.Windows.Shapes;
using System.Windows.Media.Imaging;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Local = Microsoft.Xna.Framework;
using Root = Microsoft.Xna.Framework;

namespace SilverArcade.SilverSprite.Graphics
{
    public class WriteableBitmapChildRenderer
    {
        WriteableBitmap _bmp;
        int _width;
        int _height;
		int clearColor;
        System.Windows.Shapes.Rectangle _clearRect;
        SWM.SolidColorBrush _transparentBrush;
		TextBlock _text;
		SWM.TranslateTransform _textTranslate;
		DrawCommandQueue _lastCommands = new DrawCommandQueue();
		int _lastCommandCount;
		DirtyQuad _quads;
		bool first = true;
		Random rand = new Random();
		internal bool changed = false;
		Local.Matrix _transformMatrix;
		int[] _clearArray;
		Image _img;
		public FrameworkElement Root;
		public SpriteBlendMode blendMode;
		bool somethingWasDrawn = false;

		public WriteableBitmapChildRenderer(int width, int height)
        {
            _transparentBrush = new SWM.SolidColorBrush(SWM.Colors.Transparent);
            _width = width;
            _height = height;
			_clearArray = new int[_width];
            _clearRect = new System.Windows.Shapes.Rectangle();
            _clearRect.Width = _width;
            _clearRect.Height = _height;
			_img = new Image();
			_bmp = new WriteableBitmap(_width, _height);
			_img.Source = _bmp;
			_img.Width = _width;
			_img.Height = _height;
			Root = _img;
			_text = new TextBlock();
			_textTranslate = new SWM.TranslateTransform();
			_quads = new DirtyQuad(new Rectangle(0, 0, width, height));
		}

		public void BeforeDraw()
		{
			somethingWasDrawn = false;
		}

        int blend(int a, int b, int c)
        {
            return ((((((a * b) * 0x8081) >> 23) * c) * 0x8081) >> 23);
        }

        int blend(byte a, byte b)
        {
            return (((a * b) * 0x8081) >> 23);
        }

        int blend(int a, int b)
        {
            return (((a * b) * 0x8081) >> 23);
        }

		void GetDestinationRect(ref Rectangle rect, Vector2 position, ref DoubleRectangle sourceRectangle, Vector2 scale, Vector2 origin)
		{
			position -= origin * scale;
			Vector2 pos = Vector2.Transform(position, _transformMatrix);
			Vector2 pos2 = position;
			pos2.X += (float)(sourceRectangle.Width * scale.X);
			pos2.Y += (float)(sourceRectangle.Height * scale.Y);
			pos2 = Vector2.Transform(pos2, _transformMatrix);
			rect.X = (int)(pos.X + .5);
			rect.Y = (int)(pos.Y + .5);
			int right = (int)(pos2.X + .5);
			int bottom = (int)(pos2.Y + .5);
			rect.Width = right - rect.X;
			rect.Height = bottom - rect.Y;
		}

		public void GetTextBounds(ref Rectangle rect, SpriteFont spriteFont, string text, Vector2 position, Vector2 origin, Vector2 scale)
		{
			position -= origin * scale;
			Vector2 pos = Vector2.Transform(position, _transformMatrix);
			Vector2 pos2 = position;

			if (spriteFont is BitmapSpriteFont)
			{
				BitmapSpriteFont font = spriteFont as BitmapSpriteFont;
				foreach (char c in text)
				{
					if (c == '\n')
					{
						pos.Y += font.LineSpacing;
						pos.X = 0;
						continue;
					}
					if (font.characterData.ContainsKey(c) == false) continue;
					GlyphData g = font.characterData[c];
					pos2.X += (g.Kerning.Y + g.Kerning.Z + font.Spacing) * scale.X;
					float y = pos.Y + g.Glyph.Y + g.Glyph.Height;
					if (y > pos2.Y)
					{
						pos2.Y = y;
					}
				}
			}
			else
			{
				_text.Text = text;
				_text.FontFamily = spriteFont.FontFamily;
				_text.FontSize = spriteFont.FontSize;
				pos2.X = (float)(pos.X + _text.ActualWidth);
				pos2.Y = (float)(pos.Y + _text.ActualHeight);
			}
			rect.X = (int)(pos.X + .5);
			rect.Y = (int)(pos.Y + .5);
			int right = (int)(pos2.X + .5);
			int bottom = (int)(pos2.Y + .5);
			rect.Width = right - rect.X;
			rect.Height = bottom - rect.Y;
		}

        void Blit(WriteableBitmap source, Vector2 position, ref DoubleRectangle sourceRectangle, Color color, Vector2 scale, Vector2 origin, SpriteEffects effects)
        {
			int sourceWidth = source.PixelWidth;
			int sourceHeight = source.PixelHeight;
			int[] sourcePixels = source.Pixels;
			int[] destPixels = _bmp.Pixels;
			int sourceLength = sourcePixels.Length;
			int destLength = destPixels.Length;
			if (color.A == 0) return;
			Root.Rectangle DestinationRect = new Root.Rectangle();
			GetDestinationRect(ref DestinationRect, position, ref sourceRectangle, scale, origin);
			scale.X = (float)(DestinationRect.Width / sourceRectangle.Width);
			scale.Y = (float)(DestinationRect.Height / sourceRectangle.Height);
			foreach (DirtyQuad q in _quads.GetDirtyQuads(DestinationRect))
			{
				int sourceIdx = -1;
				int px = Math.Max(q.BoundingRect.X, DestinationRect.X);
				int py = Math.Max(q.BoundingRect.Y, DestinationRect.Y);
				int right = Math.Min(q.BoundingRect.Right, DestinationRect.Right);
				int bottom = Math.Min(q.BoundingRect.Bottom, DestinationRect.Bottom);
				int dw = right - px;
				int dh = bottom - py;
				int x;
				int y;
				int idx;
				float ii;
				float jj;
				int sr = 0;
				int sg = 0;
				int sb = 0;
				int dr, dg, db;
				int sourcePixel;
				int sa = 0;
				int da;
				int ca = color.A;
				int cr = color.R;
				int cg = color.G;
				int cb = color.B;
				bool tinted = color.PackedValue != 0xffffffff;
				bool hflip = (effects & SpriteEffects.FlipHorizontally) == SpriteEffects.FlipHorizontally;
				bool vflip = (effects & SpriteEffects.FlipVertically) == SpriteEffects.FlipVertically;
				float sdx = 1 / scale.X;
				float sdy = 1 / scale.Y;
				float sourceStartX = (float)sourceRectangle.Left + ((px - DestinationRect.X) * sdx) + sdx/2;
				float sourceStartY = (float)sourceRectangle.Top + ((py - DestinationRect.Y) * sdy) + sdy/2;
				int lastii, lastjj;
				lastii = -1;
				lastjj = -1;
				if (hflip)
				{
					sourceStartX = (float)sourceRectangle.Right - ((px - DestinationRect.X) / scale.X) - sdx/2;
					sdx = -sdx;
				}
				if (vflip)
				{
					sourceStartY = (float)sourceRectangle.Bottom - ((py - DestinationRect.Y) / scale.Y) - sdy/2;
					sdy = -sdy;
				}
				jj = sourceStartY;
				y = py;
				for (int j = 0; j < dh; j++)
				{
					ii = sourceStartX;
					idx = px + y * _width;
					x = px;
					sourcePixel = sourcePixels[0];

					for (int i = 0; i < dw; i++)
					{
						int ir = (int)(ii);
						int jr = (int)(jj);
						if (ir < sourceWidth && jr < sourceHeight)
						{
							if (ir != lastii || jr != lastjj)
							{
								lastii = ir;
								lastjj = jr;
								sourceIdx = ir + jr * sourceWidth;
								if (sourceIdx >= 0 && sourceIdx < sourceLength)
								{
									sourcePixel = sourcePixels[sourceIdx];
									sa = ((sourcePixel >> 24) & 0xff);
									sr = ((sourcePixel >> 16) & 0xff);
									sg = ((sourcePixel >> 8) & 0xff);
									sb = ((sourcePixel) & 0xff);
									if (tinted && sa != 0)
									{
										sa = (((sa * ca) * 0x8081) >> 23);
										sr = ((((((sr * cr) * 0x8081) >> 23) * ca) * 0x8081) >> 23);
										sg = ((((((sg * cg) * 0x8081) >> 23) * ca) * 0x8081) >> 23);
										sb = ((((((sb * cb) * 0x8081) >> 23) * ca) * 0x8081) >> 23);
										sourcePixel = (sa << 24) | (sr << 16) | (sg << 8) | sb;
									}
								}
								else
								{
									sa = 0;
								}
							}
							if (blendMode == SpriteBlendMode.None)
							{
								destPixels[idx] = sourcePixel;
							}
							else if (sa > 0)
							{
								int destPixel = destPixels[idx];
								da = ((destPixel >> 24) & 0xff);
								if ((sa == 255 || da == 0) && blendMode != SpriteBlendMode.Additive)
								{
									destPixels[idx] = sourcePixel;
								}
								else
								{
									dr = ((destPixel >> 16) & 0xff);
									dg = ((destPixel >> 8) & 0xff);
									db = ((destPixel) & 0xff);
									if (blendMode == SpriteBlendMode.AlphaBlend)
									{
#if false
								destPixel = ((sa + blend(da, (255 - sa))) << 24) |
									((sr + blend(dr, 255-sa)) << 16) |
									((sg + blend(dg, 255-sa)) << 8) |
									((sb + blend(db, 255-sa)));
#endif
										destPixel = ((sa + (((da * (255 - sa)) * 0x8081) >> 23)) << 24) |
											((sr + (((dr * (255 - sa)) * 0x8081) >> 23)) << 16) |
											((sg + (((dg * (255 - sa)) * 0x8081) >> 23)) << 8) |
											((sb + (((db * (255 - sa)) * 0x8081) >> 23)));
									}
									else if (blendMode == SpriteBlendMode.Additive)
									{
										int a = 255 <= sa + da ? 255 : sa + da;
										destPixel = (a << 24) |
											 ((a <= sr + dr ? a : sr + dr) << 16) |
											 ((a <= sg + dg ? a : sg + dg) << 8) |
											 ((a <= sb + db ? a : sb + db));

									}
									destPixels[idx] = destPixel;
								}
							}
						}
						x++;
						idx++;
						ii += sdx;
					}
					jj += sdy;
					y++;
				}
			}
        }

		internal void Draw(DrawCommand cmd)
		{
			somethingWasDrawn = true;
			if (cmd.CommandType == DrawCommand.DrawCommandType.Texture)
			{
				cmd.Texture.IsDirty = false;
			}
			switch (cmd.CommandType)
			{
				case DrawCommand.DrawCommandType.String:
					DrawString(cmd.Font, cmd.Text, cmd.Position, cmd.Color, cmd.Rotation, cmd.Origin, cmd.Scale, cmd.Effects, cmd.LayerDepth);
					break;
				case DrawCommand.DrawCommandType.Texture:
					if (float.IsInfinity(cmd.Scale.X)) cmd.Scale.X = 0;
					if (float.IsInfinity(cmd.Scale.Y)) cmd.Scale.Y = 0;
					if (cmd.ShaderEffect != null)
					{
						Draw(cmd.Texture, cmd.Position, ref cmd.SourceRectangle, cmd.ShaderEffect, cmd.Rotation, cmd.Origin, cmd.Scale, cmd.Effects, cmd.LayerDepth);
					}
					else
					{
						Draw(cmd.Texture, cmd.Position, ref cmd.SourceRectangle, cmd.Color, cmd.Rotation, cmd.Origin, cmd.Scale, cmd.Effects, cmd.LayerDepth);
					}
					break;
			}
		}

        public void Draw(Texture2D texture, Vector2 position, ref DoubleRectangle sourceRectangle, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth)
        {
            Blit(texture.ImageSource, position, ref sourceRectangle, color, scale, origin, effects);
        }

        public void Draw(Texture2D texture, Vector2 position, ref DoubleRectangle sourceRectangle, System.Windows.Media.Effects.ShaderEffect shaderEffect, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth)
        {
			Blit(texture.ImageSource, position, ref sourceRectangle, Color.White, scale, origin, effects);
        }

		public void DrawString(SpriteFont spriteFont, string text, Vector2 position, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth)
		{
			origin = origin * scale;
			if (color.A == 0 && blendMode == SpriteBlendMode.AlphaBlend) return;
			if (spriteFont is BitmapSpriteFont)
			{
				BitmapSpriteFont font = spriteFont as BitmapSpriteFont;
				Vector2 pos = Vector2.Zero;
				foreach (char c in text)
				{
					if (c == '\n')
					{
						pos.Y += font.LineSpacing;
						pos.X = 0;
						continue;
					}
					if (font.characterData.ContainsKey(c) == false) continue;
					GlyphData g = font.characterData[c];
					DoubleRectangle rect = new DoubleRectangle(g.Glyph.X, g.Glyph.Y, g.Glyph.Width, g.Glyph.Height);
					Blit(font.SourceData, position - origin + pos + new Vector2(g.Cropping.X * scale.X, g.Cropping.Y * scale.Y), ref rect, color, scale, Vector2.Zero, effects);
					pos.X += (g.Kerning.Y + g.Kerning.Z + font.Spacing) * scale.X;
				}
			}
			else
			{
				_text.Text = text;
				_text.FontFamily = spriteFont.FontFamily;
				_text.FontSize = spriteFont.FontSize;
				_text.Foreground = new SWM.SolidColorBrush(color.ToSilverlightColor());
				_textTranslate.X = position.X;
				_textTranslate.Y = position.Y;
				_bmp.Invalidate();
				_bmp.Render(_text, _textTranslate);
				_bmp.Invalidate();
			}
		}


        public void Begin(GraphicsDevice device, SpriteBlendMode blendMode, SpriteSortMode sortMode, SaveStateMode stateMode, Local.Matrix transformMatrix)
        {
			_transformMatrix = transformMatrix;
			this.blendMode = blendMode;
        }

		internal void DrawAll(IEnumerable<DrawCommand> cmds)
		{
			int idx = 0;
			_quads.SetClean();
			_lastCommandCount = _lastCommands.CommandCount;
			_lastCommands.Reset();
			if (first)
			{
				first = false;
				_quads.InvalidateAll();
			}

			if (!ImageLoader.IsBusy)
			{
				foreach (DrawCommand cmd in cmds)
				{
					DrawCommand lc = _lastCommands.GetNextAvailable();
					if (cmd.CheckDirty(lc) == true)
					{
						if (cmd.CommandType == DrawCommand.DrawCommandType.Texture)
						{
							GetDestinationRect(ref cmd.DestinationRectangle, cmd.Position, ref cmd.SourceRectangle, cmd.Scale, cmd.Origin);
						}
						else
						{
							GetTextBounds(ref cmd.DestinationRectangle, cmd.Font, cmd.Text, cmd.Position, cmd.Origin, cmd.Scale);
						}
						_quads.Invalidate(ref cmd.DestinationRectangle);
						if (lc.CommandType != DrawCommand.DrawCommandType.None)
						{
							_quads.Invalidate(ref lc.DestinationRectangle);
						}
						// Copy the command so we can see if it's dirty next time
						cmd.CopyTo(lc);
					}
					idx++;
				}
				for (int i = idx; i < _lastCommandCount - 1; i++)
				{
					DrawCommand lc = _lastCommands.GetNextAvailable();
					_quads.Invalidate(ref lc.DestinationRectangle);
					lc.CommandType = DrawCommand.DrawCommandType.None;
				}
				Rectangle rect = new Rectangle(0, 0, _width, _height);
				foreach (DirtyQuad q in _quads.GetDirtyQuads(rect))
				{
					changed = true;
					Clear(ref q.BoundingRect);
				}
				foreach (DrawCommand cmd in cmds)
				{
					Draw(cmd);
				}
			}
			else
			{
				_quads.InvalidateAll();
				Rectangle rect = new Rectangle(0, 0, _width, _height);
				foreach (DirtyQuad q in _quads.GetDirtyQuads(rect))
				{
					changed = true;
					Clear(ref q.BoundingRect);
				}
			}

//			Rectangle rect2 = new Rectangle(0, 0, _width, _height);
//			foreach (DirtyQuad q in _quads.GetDirtyQuads(rect2))
//			{
//				DrawDirtyRect(ref q.BoundingRect);
//			}
		}

		void DrawDirtyRect(ref Rectangle rect)
		{
			int[] pixels = _bmp.Pixels;
			int len = pixels.Length;
			int sr = rand.Next(128);
			int sg = rand.Next(128);
			int sb = (255 - (sr + sg))/2;
		    int sa = 128;
			int width = rect.Width;
			int height = rect.Height;
			int stride = _width - width;
			int idx = rect.X + rect.Y * _width;
			for (int i = 0; i < height; i++)
			{
				for (int j = 0; j < width; j++)
				{
					int pixel = pixels[idx];
					int da = ((pixel >> 24) & 0xff);
					int dr = ((pixel >> 16) & 0xff);
					int dg = ((pixel >> 8) & 0xff);
					int db = ((pixel) & 0xff);
					pixel = ((sa + (((da * (255 - sa)) * 0x8081) >> 23)) << 24) |
						((sr + (((dr * (255 - sa)) * 0x8081) >> 23)) << 16) |
						((sg + (((dg * (255 - sa)) * 0x8081) >> 23)) << 8) |
						((sb + (((db * (255 - sa)) * 0x8081) >> 23)));
					pixels[idx] = pixel;
					idx++;
				}
				idx += stride;
			}
		}

		void Clear(ref Rectangle rect)
		{
			int[] pixels = _bmp.Pixels;
			int len = pixels.Length;

			int width = rect.Width;
			int height = rect.Height;
			int stride = _width - width;
			int idx = rect.X + rect.Y * _width;
			for (int i = 0; i < width; i++)
			{
				_clearArray[i] = clearColor;
			}
			for (int i = 0; i < height; i++)
			{
				Array.Copy(_clearArray, 0, pixels, idx, width);
				idx += _width;
			}
		}

		bool visible = true;
		public bool Visible
		{
			get
			{
				return visible;
			}
			set
			{
				if (visible != value)
				{
					visible = value;
					if (visible)
					{
						Root.Visibility = Visibility.Visible;
					}
					else
					{
						Root.Visibility = Visibility.Collapsed;
					}
				}
			}
		}

		public void AfterDraw()
		{
			Visible = somethingWasDrawn;
		}

		public void Clear(Color color)
        {
			somethingWasDrawn = true;
			clearColor = Color.ToPrgbaInt(color);
		}

		public void Invalidate()
		{
			_bmp.Invalidate();
		}
    }
}
