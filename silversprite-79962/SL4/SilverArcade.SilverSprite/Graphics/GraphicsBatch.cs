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
using System.Windows.Media.Effects;
using SilverArcade.SilverSprite.Graphics;
using Local = Microsoft.Xna.Framework;

namespace Microsoft.Xna.Framework.Graphics
{
    public class GraphicsBatch : SpriteBatch
    {
        public GraphicsBatch(GraphicsDevice graphicsDevice) : base(graphicsDevice)
        {
        }


        public void Draw(Texture2D texture, Vector2 position, DoubleRectangle? sourceRectangle, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth)
        {
            DrawCommand cmd = GetRenderer().GetAvailableCommand();
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
                cmd.SourceRectangle = sourceRectangle.Value;
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


        public void Draw(Texture2D texture, Vector2 position, DoubleRectangle? sourceRectangle, ShaderEffect shaderEffect, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth)
        {
            DrawCommand cmd = GetRenderer().GetAvailableCommand();
            cmd.CommandType = DrawCommand.DrawCommandType.Texture;
            cmd.Texture = texture;
            cmd.Position = position;
            cmd.ShaderEffect = shaderEffect;
            cmd.Rotation = rotation;
            cmd.Origin = origin;
            if (sourceRectangle != null)
            {
                cmd.SourceRectangle = sourceRectangle.Value;
            }
            else
            {
                cmd.SourceRectangle = DoubleRectangle.FromRectangle(texture.SourceRect);
            }
            cmd.Scale = scale;
            cmd.Effects = effects;
            cmd.LayerDepth = layerDepth;
        }

    }
}
