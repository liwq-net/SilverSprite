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
using System.Text;
using System.Linq;
using System.Windows.Media.Effects;
using SWM = System.Windows.Media;
using SilverArcade.SilverSprite.Graphics;

using Local = Microsoft.Xna.Framework;
using Microsoft.Xna.Framework;

namespace Microsoft.Xna.Framework.Graphics
{
    public class SpriteBatch : IDisposable
    {
        internal static List<SpriteBatch> SpriteBatches = new List<SpriteBatch>();
        GraphicsDevice _graphicsDevice;

        static double _globalRenderAtScale = 1;
        static bool _globalBitmapCacheEnabled = false;
        double _renderAtScale = 1;
        bool _bitmapCacheEnabled = false;
        SilverlightRenderBase _renderer;

        public void Begin(SpriteBlendMode blendMode)
        {
            Begin(blendMode, SpriteSortMode.Deferred, SaveStateMode.None, Local.Matrix.Identity);
        }

        public void Begin(SpriteBlendMode blendMode, SpriteSortMode sortMode, SaveStateMode stateMode)
        {
            Begin(blendMode, sortMode, stateMode, Local.Matrix.Identity);
        }

        public void Begin(SpriteBlendMode blendMode, SpriteSortMode sortMode, SaveStateMode stateMode, Local.Matrix transformMatrix)
        {
            //TODO: Full XNA Library throws an exception if Begin is called before calling End of the previous session.
            _renderer = GetRenderer();
            _renderer.Begin(_graphicsDevice, blendMode, sortMode, stateMode, transformMatrix);
        }

        // made public for FRB.
        public CanvasRenderer GetCanvas()
        {
            return GetRenderer() as CanvasRenderer;
        }

        // made public for FRB.
        public SilverlightRenderBase GetRenderer()
        {
            SilverlightRenderBase c;
            c = this.GraphicsDevice.GetCurrentRenderTarget()._renderer;
            return c;
        }

        public void Begin()
        {
            Begin(SpriteBlendMode.AlphaBlend, SpriteSortMode.Deferred, SaveStateMode.None, Local.Matrix.Identity);
        }

        public void End()
        {
            _renderer.End();
        }

        public GraphicsDevice GraphicsDevice
        {
            get
            {
                return _graphicsDevice;
            }
        }

        public SpriteBatch(GraphicsDevice graphicsDevice)
        {
            _graphicsDevice = graphicsDevice;
            SpriteBatches.Add(this);
        }

        public void DrawString(SpriteFont spriteFont, string text, Vector2 position, Color color, float rotation, Vector2 origin, float scale, SpriteEffects effects, float layerDepth)
        {
            DrawCommand cmd = _renderer.GetAvailableCommand();
            cmd.CommandType = DrawCommand.DrawCommandType.String;
            cmd.Font = spriteFont;
            cmd.Text = text;
            cmd.Position = position;
            cmd.Color = color;
            cmd.Rotation = rotation;
            cmd.Origin = origin;
            cmd.Scale = new Vector2(scale, scale);
            cmd.Effects = effects;
            cmd.LayerDepth = layerDepth;
        }

        public void DrawString(SpriteFont spriteFont, string text, Vector2 position, Color color)
        {
            DrawCommand cmd = _renderer.GetAvailableCommand();
            cmd.CommandType = DrawCommand.DrawCommandType.String;
            cmd.Font = spriteFont;
            cmd.Text = text;
            cmd.Position = position;
            cmd.Color = color;
            cmd.Rotation = 0;
            cmd.Origin = Vector2.Zero;
            cmd.Scale = Vector2.One;
            cmd.Effects = SpriteEffects.None;
            cmd.LayerDepth = 0;
        }

        public void DrawString(SpriteFont spriteFont, StringBuilder text, Vector2 position, Color color)
        {
            DrawString(spriteFont, text.ToString(), position, color);
        }

        public void DrawString(SpriteFont spriteFont, string text, Vector2 position, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth)
        {
            DrawCommand cmd = _renderer.GetAvailableCommand();
            cmd.CommandType = DrawCommand.DrawCommandType.String;
            cmd.Font = spriteFont;
            cmd.Text = text;
            cmd.Position = position;
            cmd.Color = color;
            cmd.Rotation = rotation;
            cmd.Origin = origin;
            cmd.Scale = scale;
            cmd.Effects = effects;
            cmd.LayerDepth = layerDepth;
        }

        public void DrawString(SpriteFont spriteFont, StringBuilder text, Vector2 position, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth)
        {
            DrawCommand cmd = _renderer.GetAvailableCommand();
            cmd.CommandType = DrawCommand.DrawCommandType.String;
            cmd.Font = spriteFont;
            cmd.Text = text.ToString();
            cmd.Position = position;
            cmd.Color = color;
            cmd.Rotation = rotation;
            cmd.Origin = origin;
            cmd.Scale = scale;
            cmd.Effects = effects;
            cmd.LayerDepth = layerDepth;
        }

        public void DrawString(SpriteFont spriteFont, StringBuilder text, Vector2 position, Color color, float rotation, Vector2 origin, float scale, SpriteEffects effects, float layerDepth)
        {
            DrawCommand cmd = _renderer.GetAvailableCommand();
            cmd.CommandType = DrawCommand.DrawCommandType.String;
            cmd.Font = spriteFont;
            cmd.Text = text.ToString();
            cmd.Position = position;
            cmd.Color = color;
            cmd.Rotation = rotation;
            cmd.Origin = origin;
            cmd.Scale = new Vector2(scale, scale);
            cmd.Effects = effects;
            cmd.LayerDepth = layerDepth;
        }

        public void Draw(Texture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, float scale, SpriteEffects effects, float layerDepth)
        {
            DrawCommand cmd = _renderer.GetAvailableCommand();
            cmd.CommandType = DrawCommand.DrawCommandType.Texture;
            cmd.Texture = texture;
            cmd.Position = position;
            cmd.Color = color;
            cmd.Rotation = rotation;
            cmd.Origin = origin;
            if (sourceRectangle != null)
            {
                cmd.SourceRectangle = DoubleRectangle.FromRectangle(sourceRectangle.Value);
            }
            else
            {
                cmd.SourceRectangle = DoubleRectangle.Empty;
            }
            cmd.Scale = new Vector2(scale, scale);
            cmd.Effects = effects;
            cmd.LayerDepth = layerDepth;
            cmd.CalculateDestinationRectangle(texture);
        }

        public void Draw(Texture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color)
        {
            DrawCommand cmd = _renderer.GetAvailableCommand();
            cmd.CommandType = DrawCommand.DrawCommandType.Texture;
            cmd.Texture = texture;
            cmd.Position = position;
            cmd.Color = color;
            cmd.Rotation = 0;
            cmd.Origin = Vector2.Zero;
            cmd.Scale = Vector2.One;
            cmd.Effects = SpriteEffects.None;
            cmd.LayerDepth = 0;
            if (sourceRectangle != null)
            {
                cmd.SourceRectangle = DoubleRectangle.FromRectangle(sourceRectangle.Value);
            }
            else
            {
                cmd.SourceRectangle = DoubleRectangle.Empty;
            }
            cmd.CalculateDestinationRectangle(texture);
        }

        public void Draw(Texture2D texture, Rectangle destinationRectangle, Rectangle? sourceRectangle, Color color)
        {
            DrawCommand cmd = _renderer.GetAvailableCommand();
            cmd.CommandType = DrawCommand.DrawCommandType.Texture;
            cmd.Texture = texture;
            cmd.Position = new Vector2(destinationRectangle.X, destinationRectangle.Y);
            cmd.Color = color;
            cmd.Rotation = 0;
            cmd.Origin = Vector2.Zero;
            if (sourceRectangle != null)
            {
                cmd.SourceRectangle = DoubleRectangle.FromRectangle(sourceRectangle.Value);
            }
            else
            {
                cmd.SourceRectangle = DoubleRectangle.Empty;
            }
            float scaleX = destinationRectangle.Width / (float)cmd.SourceRectangle.Width;
            float scaleY = destinationRectangle.Height / (float)cmd.SourceRectangle.Height;
            cmd.Scale = new Vector2(scaleX, scaleY);
            cmd.Effects = SpriteEffects.None;
            cmd.LayerDepth = 0;
            cmd.CalculateDestinationRectangle(texture);
        }

        public void Draw(Texture2D texture, Rectangle destinationRectangle, Color color)
        {
            DrawCommand cmd = _renderer.GetAvailableCommand();
            cmd.CommandType = DrawCommand.DrawCommandType.Texture;
            cmd.Texture = texture;
            cmd.Position = new Vector2(destinationRectangle.X, destinationRectangle.Y);
            cmd.Color = color;
            cmd.Rotation = 0;
            cmd.Origin = Vector2.Zero;
            cmd.SourceRectangle = DoubleRectangle.Empty;
            float scaleX = destinationRectangle.Width / (float)cmd.SourceRectangle.Width;
            float scaleY = destinationRectangle.Height / (float)cmd.SourceRectangle.Height;
            cmd.Scale = new Vector2(scaleX, scaleY);
            cmd.Effects = SpriteEffects.None;
            cmd.LayerDepth = 0;
            cmd.CalculateDestinationRectangle(texture);
        }

        public void Draw(Texture2D texture, Vector2 position, Color color)
        {
            DrawCommand cmd = _renderer.GetAvailableCommand();
            cmd.CommandType = DrawCommand.DrawCommandType.Texture;
            cmd.Texture = texture;
            cmd.Position = position;
            cmd.Color = color;
            cmd.Rotation = 0;
            cmd.Origin = Vector2.Zero;
            cmd.SourceRectangle = DoubleRectangle.Empty;
            cmd.Scale = Vector2.One;
            cmd.Effects = SpriteEffects.None;
            cmd.LayerDepth = 0;
            cmd.CalculateDestinationRectangle(texture);
        }

        public void Draw(Texture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth)
        {
            DrawCommand cmd = _renderer.GetAvailableCommand();
            cmd.CommandType = DrawCommand.DrawCommandType.Texture;
            cmd.Texture = texture;
            cmd.Position = position;
            cmd.Color = color;

            // Vic says - make sure this stays in, or else previously-drawn Sprites can make later-drawn Sprites have the wrong effect
            cmd.ShaderEffect = null;

            cmd.Rotation = rotation;
            cmd.Origin = origin;
            if (sourceRectangle != null)
            {
                cmd.SourceRectangle = DoubleRectangle.FromRectangle(sourceRectangle.Value);
            }
            else
            {
                cmd.SourceRectangle = DoubleRectangle.Empty;
            }
            cmd.Scale = scale;
            cmd.Effects = effects;
            cmd.LayerDepth = layerDepth;
            cmd.CalculateDestinationRectangle(texture);
        }

        public void Draw(Texture2D texture, Rectangle destinationRectangle, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, SpriteEffects effects, float layerDepth)
        {
            DrawCommand cmd = _renderer.GetAvailableCommand();
            cmd.CommandType = DrawCommand.DrawCommandType.Texture;
            cmd.Texture = texture;
            cmd.Position = new Vector2(destinationRectangle.X, destinationRectangle.Y);
            cmd.Color = color;

            // Vic says - make sure this stays in, or else previously-drawn Sprites can make later-drawn Sprites have the wrong effect
            cmd.ShaderEffect = null;

            cmd.Rotation = rotation;
            cmd.Origin = origin;
            if (sourceRectangle != null)
            {
                cmd.SourceRectangle = DoubleRectangle.FromRectangle(sourceRectangle.Value);
            }
            else
            {
                cmd.SourceRectangle = DoubleRectangle.Empty;
            }
            float scaleX = destinationRectangle.Width / (float)cmd.SourceRectangle.Width;
            float scaleY = destinationRectangle.Height / (float)cmd.SourceRectangle.Height;
            cmd.Scale = new Vector2(scaleX, scaleY);
            cmd.Effects = effects;
            cmd.LayerDepth = layerDepth;
            cmd.CalculateDestinationRectangle(texture);
        }

        #region IDisposable Members

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
