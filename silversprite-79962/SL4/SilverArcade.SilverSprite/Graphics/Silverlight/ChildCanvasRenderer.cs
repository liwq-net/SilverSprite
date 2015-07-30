using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.Generic;
using SWM = System.Windows.Media;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using G = Microsoft.Xna.Framework.Graphics;

using Local = Microsoft.Xna.Framework;

using System.Text;
using ShaderEffect = System.Windows.Media.Effects.ShaderEffect;
using System.Windows.Media;

namespace SilverArcade.SilverSprite.Graphics
{
    public class ChildCanvasRenderer
    {
        public Canvas Canvas;
        bool visible = true;
        Dictionary<long, SpriteList> clippedImages;
        Dictionary<long, SpriteList> images;
        Dictionary<long, SpriteList> bitmapTexts;
        Dictionary<long, SpriteList> texts;
        int zIndex;
        Rect lastRect;
        Local.Matrix lastMatrix;
        BitmapCache cache;

        Local.Matrix transMatrix = Local.Matrix.Identity;
        System.Windows.Media.MatrixTransform transform = new System.Windows.Media.MatrixTransform();
        double _renderAtScale = 1;
        bool _bitmapCacheEnabled = false;

        public void Begin(GraphicsDevice device)
        {
            Begin(device, SpriteBlendMode.AlphaBlend, SpriteSortMode.Deferred, SaveStateMode.None, Local.Matrix.Identity);
        }

        public void Begin(GraphicsDevice device, SpriteBlendMode blendMode, SpriteSortMode sortMode, SaveStateMode stateMode, Local.Matrix transformMatrix)
        {

            //transformMatrix = Matrix.Identity;


            Rect rect = new Rect(
                (device.Viewport.X),
                (device.Viewport.Y),
                device.Viewport.Width,
                device.Viewport.Height);

            if (rect != lastRect || !MatricesAreEqual(transformMatrix, lastMatrix))
            {
                transformMatrix.M41 += device.Viewport.X;
                transformMatrix.M42 += device.Viewport.Y;
                MatrixTransform matrixTransform = new MatrixTransform();
                System.Windows.Media.Matrix matrix = new System.Windows.Media.Matrix(
                   transformMatrix.M11,
                    transformMatrix.M12,
                    transformMatrix.M21,
                    transformMatrix.M22,
                    transformMatrix.M41,
                    transformMatrix.M42);
                matrixTransform.Matrix = matrix;
                System.Windows.Media.RectangleGeometry rectangleGeometry = new System.Windows.Media.RectangleGeometry();
                rectangleGeometry.Rect = rect;
                MatrixTransform inverse = matrixTransform.Inverse as MatrixTransform;

                rectangleGeometry.Transform = inverse;
                Canvas.Clip = rectangleGeometry;

                matrixTransform.Matrix = matrix;
                TransformMatrix = transformMatrix;
                lastRect = rect;
                lastMatrix = transformMatrix;
                Canvas.Width = rect.Width;
                Canvas.Height = rect.Height;
            }
            InUse = true;
            Begin();
        }

        public bool BitmapCacheEnabled
        {
            set
            {
                _bitmapCacheEnabled = value;
                if (value == true)
                {
                    cache = new BitmapCache();
                    cache.RenderAtScale = RenderAtScale;
                }
                else
                {
                    cache = null;
                }
//                Canvas.CacheMode = cache;
                foreach (SpriteList s in clippedImages.Values)
                {
                    s.BitmapCacheEnabled = value;
                }
                foreach (SpriteList s in images.Values)
                {
                    s.BitmapCacheEnabled = value;
                } 
                foreach (SpriteList s in bitmapTexts.Values)
                {
                    s.BitmapCacheEnabled = value;
                }
                foreach (SpriteList s in texts.Values)
                {
                    s.BitmapCacheEnabled = value;
                }
            }
            get
            {
                return _bitmapCacheEnabled;
            }
        }

        public void DisposeTextureAssets(Texture2D texture)
        {
            if (clippedImages.ContainsKey(texture.AssetId))
            {
                SpriteList img= clippedImages[texture.AssetId];
                img.ReleaseAll();
            }
            if (images.ContainsKey(texture.AssetId))
            {
                SpriteList img = clippedImages[texture.AssetId];
                img.ReleaseAll();
            }
        }

        public double RenderAtScale
        {
            set
            {
                _renderAtScale = value;
                foreach (SpriteList s in clippedImages.Values)
                {
                    s.RenderAtScale = value;
                }
                foreach (SpriteList s in bitmapTexts.Values)
                {
                    s.RenderAtScale = value;
                }
                foreach (SpriteList s in texts.Values)
                {
                    s.RenderAtScale = value;
                }
            }
            get
            {
                return _renderAtScale;
            }
        }

        public bool InUse
        {
            get;
            set;
        }

        public ChildCanvasRenderer()
        {
            Canvas = new Canvas();
            transform.Matrix = System.Windows.Media.Matrix.Identity;
            Canvas.RenderTransform = transform;
            clippedImages = new Dictionary<long, SpriteList>();
            images = new Dictionary<long, SpriteList>();
            texts = new Dictionary<long, SpriteList>();
            bitmapTexts = new Dictionary<long, SpriteList>();
        }

        public void End()
        {
            foreach (SpriteList dl in clippedImages.Values)
            {
                dl.EndSpriteBatch();
            }
            foreach (SpriteList dl in images.Values)
            {
                dl.EndSpriteBatch();
            } 
            foreach (SpriteList dl in texts.Values)
            {
                dl.EndSpriteBatch();
            }
            foreach (SpriteList dl in bitmapTexts.Values)
            {
                dl.EndSpriteBatch();
            }
        }

        public void Begin()
        {
            // Vic says:  I would like to get rid of these foreach statements, but
            // these are Dictionaries, so we can't just index into them.
            foreach (SpriteList dl in clippedImages.Values)
            {
                dl.BeginSpriteBatch();
            }
            foreach (SpriteList dl in images.Values)
            {
                dl.BeginSpriteBatch();
            } 
            foreach (SpriteList dl in texts.Values)
            {
                dl.BeginSpriteBatch();
            }
            foreach (SpriteList dl in bitmapTexts.Values)
            {
                dl.BeginSpriteBatch();
            }
            zIndex = 0;
        }

        public bool Visible
        {
            set
            {
                if (value != visible)
                {
                    visible = value;
                    if (visible == false)
                    {
                        Canvas.Visibility = Visibility.Collapsed;
                    }
                    else
                    {
                        Canvas.Visibility = Visibility.Visible;
                    }
                }
            }
            get
            {
                return visible;
            }
        }

        bool MatricesAreEqual(Local.Matrix m1, Local.Matrix m2)
        {
            return m1.M11 == m2.M11 &&
                m1.M12 == m2.M12 &&
                m1.M13 == m2.M13 &&
                m1.M14 == m2.M14 &&
                m1.M21 == m2.M21 &&
                m1.M22 == m2.M22 &&
                m1.M23 == m2.M23 &&
                m1.M24 == m2.M24 &&
                m1.M31 == m2.M31 &&
                m1.M32 == m2.M32 &&
                m1.M33 == m2.M33 &&
                m1.M34 == m2.M34 &&
                m1.M41 == m2.M41 &&
                m1.M42 == m2.M42 &&
                m1.M43 == m2.M43 &&
                m1.M44 == m2.M44;
        }

        public Local.Matrix TransformMatrix
        {
            get
            {
                return transMatrix;
            }
            set
            {
                if (MatricesAreEqual(transMatrix, value) == false)
                {
                    System.Windows.Media.Matrix t = new System.Windows.Media.Matrix(value.M11, value.M12, value.M21, value.M22, value.M41, value.M42);
                    transform.Matrix = t;
                    transMatrix = value;
                }
            }
        }

        internal void Draw(DrawCommand cmd)
        {
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
                        Draw(cmd.Texture, cmd.Position, cmd.SourceRectangle, cmd.ShaderEffect, cmd.Rotation, cmd.Origin, cmd.Scale, cmd.Effects, cmd.LayerDepth);
                    }
                    else
                    {
                        Draw(cmd.Texture, cmd.Position, cmd.SourceRectangle, cmd.Color, cmd.Rotation, cmd.Origin, cmd.Scale, cmd.Effects, cmd.LayerDepth);
                    }
                    break;
            }
        }

        public void DrawString(SpriteFont spriteFont, StringBuilder text, Vector2 position, G.Color color)
        {
            DrawString(spriteFont, text.ToString(), position, color);
        }

        void DrawBitmapStringInternal(BitmapSpriteFont spriteFont, string text, Vector2 position, G.Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth)
        {
            BitmapSpriteText d = GetBitmapSpriteText(spriteFont);
            if (d.ZIndex < zIndex)
            {
                d.ZIndex = zIndex;
            }
            else
            {
                zIndex = d.ZIndex;
            }
            zIndex++;
            d.InUse = true;
            d.Text = text;
            d.Color = color;
            d.PositionX = position.X;
            d.PositionY = position.Y;
            d.Scale = new Vector2((float)scale.X, (float)scale.Y);
            d.Rotation = rotation;
            d.Origin = origin;
            d.Effects = effects;
        }

        void DrawBitmapStringInternal(BitmapSpriteFont spriteFont, string text, Vector2 position, G.Color color, float rotation, Vector2 origin, float scale, SpriteEffects effects, float layerDepth)
        {
            DrawBitmapStringInternal(spriteFont, text, position, color, rotation, origin, new Vector2(scale, scale), effects, layerDepth);
        }

        public void DrawString(SpriteFont spriteFont, string text, Vector2 position, G.Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth)
        {
            if (text == null) return;
            if (spriteFont is BitmapSpriteFont)
            {
                DrawBitmapStringInternal((BitmapSpriteFont)spriteFont, text, position, color, rotation, origin, scale, effects, layerDepth);
                return;
            }
            SpriteList l;
            long key = spriteFont.AssetId;
            if (texts.ContainsKey(key))
            {
                l = texts[key];
            }
            else
            {
                l = new SpriteList(this, SpriteList.SpriteType.SpriteText);
                l.SpriteFont = spriteFont;
                l.ParentCanvas = Canvas;
                texts.Add(key, l);
            }
            SpriteText t = l.GetSprite() as SpriteText;
            if (t.ZIndex < zIndex)
            {
                t.ZIndex = zIndex;
            }
            else
            {
                zIndex = t.ZIndex;
            }
            zIndex++;
            t.InUse = true;

            t.PositionX = position.X;
            t.PositionY = position.Y;
            t.Color = color;
            t.Text = text;
            t.Scale = scale;
            t.Rotation = rotation;
            t.Origin = origin;
            t.Effects = effects;
        }


        public void DrawString(SpriteFont spriteFont, string text, Vector2 position, G.Color color, float rotation, Vector2 origin, float scale, SpriteEffects effects, float layerDepth)
        {
            if (text == null) return;
            if (spriteFont is BitmapSpriteFont)
            {
                DrawBitmapStringInternal((BitmapSpriteFont)spriteFont, text, position, color, rotation, origin, scale, effects, layerDepth);
                return;
            }
            SpriteList l;
            long key = spriteFont.AssetId;
            if (texts.ContainsKey(key))
            {
                l = texts[key];
            }
            else
            {
                l = new SpriteList(this, SpriteList.SpriteType.SpriteText);
                l.SpriteFont = spriteFont;
                l.ParentCanvas = Canvas;
                texts.Add(key, l);
            }
            SpriteText t = l.GetSprite() as SpriteText;
            if (t.ZIndex < zIndex)
            {
                t.ZIndex = zIndex;
            }
            else
            {
                zIndex = t.ZIndex;
            }
            Vector2 vscale = new Vector2(scale, scale);

            zIndex++;
            t.InUse = true;
            t.PositionX = position.X;
            t.PositionY = position.Y;
            t.Color = color;
            t.Text = text;
            t.Scale = vscale;
            t.Rotation = rotation;
            t.Origin = origin;
            t.Effects = effects;
        }

        public void DrawString(SpriteFont font, string text, Vector2 position, G.Color color)
        {
            DrawString(font, text, position, color, 0, Vector2.Zero, 1, SpriteEffects.None, 0);
        }


        BitmapSpriteText GetBitmapSpriteText(BitmapSpriteFont font)
        {
            SpriteList l;
            long key = font.AssetId;


            if (bitmapTexts.ContainsKey(key))
            {
                l = bitmapTexts[key];
            }
            else
            {
                l = new SpriteList(this, SpriteList.SpriteType.BitmapSpriteText);
                l.BitmapSpriteFont = font;
                l.ParentCanvas = Canvas;
                bitmapTexts.Add(key, l);
            }
            BitmapSpriteText s = l.GetSprite() as BitmapSpriteText;
            return s;
        }

        SpriteImage GetSprite(Texture2D texture)
        {
            SpriteList l;
            long key = texture.AssetId;

            if (images.ContainsKey(key))
            {
                l = images[key];
            }
            else
            {
                l = new SpriteList(this, SpriteList.SpriteType.SpriteImage);
                l.Texture2D = texture;
                l.ParentCanvas = Canvas;
                l.BitmapCacheEnabled = BitmapCacheEnabled;
                l.RenderAtScale = RenderAtScale;
                images.Add(key, l);
            }
            SpriteImage s = l.GetSprite() as SpriteImage;
            return s;
        }

        ClippedSpriteImage GetClippedSprite(Texture2D texture)
        {
            SpriteList l;
            long key = texture.AssetId;


            if (clippedImages.ContainsKey(key))
            {
                l = clippedImages[key];
            }
            else
            {
                l = new SpriteList(this, SpriteList.SpriteType.ClippedSpriteImage);
                l.BitmapCacheEnabled = BitmapCacheEnabled;
                l.RenderAtScale = RenderAtScale;
                l.Texture2D = texture;
                l.ParentCanvas = Canvas;
                clippedImages.Add(key, l);
            }
            ClippedSpriteImage s = l.GetSprite() as ClippedSpriteImage;
            return s;
        }

        public void Draw(Texture2D texture, Vector2 position, DoubleRectangle? sourceRectangle, G.Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth)
        {
            if (sourceRectangle == null || sourceRectangle.Value.IsEmpty)
            {
                SpriteImage d = GetSprite(texture);
                if (d.ZIndex < zIndex)
                {
                    d.ZIndex = zIndex;
                }
                else
                {
                    zIndex = d.ZIndex;
                }
                zIndex++;
                d.InUse = true;
                if (color != d.color) d.Color = color;
                d.PositionX = position.X;
                d.PositionY = position.Y;
                d.Scale = new Vector2((float)scale.X, (float)scale.Y);
                d.Rotation = rotation;
                d.SetOriginAndEffects(origin, effects);
                d.CustomEffect = null; // this needs to get reset in case it's left-over from another call
            }
            else
            {
                ClippedSpriteImage d = GetClippedSprite(texture);
                if (d.ZIndex < zIndex)
                {
                    d.ZIndex = zIndex;
                }
                else
                {
                    zIndex = d.ZIndex;
                }
                zIndex++;
                d.InUse = true;
                if (color != d.color) d.Color = color;
                d.SourceRectangle = sourceRectangle.Value;
                d.PositionX = position.X;
                d.PositionY = position.Y;
                d.Scale = new Vector2((float)scale.X, (float)scale.Y);
                d.Rotation = rotation;
                d.SetOriginAndEffects(origin, effects);
                d.CustomEffect = null; // this needs to get reset in case it's left-over from another call
            }
        }

        public void Draw(Texture2D texture, Vector2 position, DoubleRectangle? sourceRectangle, ShaderEffect shaderEffect, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth)
        {
            if (sourceRectangle == null || sourceRectangle.Value.IsEmpty)
            {
                SpriteImage d = GetSprite(texture);
                if (d.ZIndex < zIndex)
                {
                    d.ZIndex = zIndex;
                }
                else
                {
                    zIndex = d.ZIndex;
                }
                zIndex++;
                d.InUse = true;
                d.PositionX = position.X;
                d.PositionY = position.Y;
                d.Scale = new Vector2((float)scale.X, (float)scale.Y);
                d.Rotation = rotation;
                d.Origin = origin;
                d.Effects = effects;
                d.CustomEffect = shaderEffect;
            }
            else
            {
                ClippedSpriteImage d = GetClippedSprite(texture);
                if (d.ZIndex < zIndex)
                {
                    d.ZIndex = zIndex;
                }
                else
                {
                    zIndex = d.ZIndex;
                }
                zIndex++;
                d.InUse = true;
                d.SourceRectangle = sourceRectangle.Value;
                d.PositionX = position.X;
                d.PositionY = position.Y;
                d.Scale = new Vector2((float)scale.X, (float)scale.Y);
                d.Rotation = rotation;
                d.Origin = origin;
                d.Effects = effects;
                d.CustomEffect = shaderEffect;
            }
        }
    }
}
