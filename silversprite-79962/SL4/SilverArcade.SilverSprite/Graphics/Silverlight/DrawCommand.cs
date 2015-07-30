using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using SWM = System.Windows.Media;
using System.Windows.Media.Animation;
using System.Collections.Generic;
using System.Windows.Media.Effects;

using Microsoft.Xna.Framework;
using Local = Microsoft.Xna.Framework;
using Root = Microsoft.Xna.Framework;

using G = Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Graphics;

namespace SilverArcade.SilverSprite.Graphics
{
    internal class DrawCommandQueue : List<DrawCommand>
    {
        int _currentIndex;
        public void Reset()
        {
            _currentIndex = 0;
        }

        public DrawCommand GetNextAvailable()
        {
            if (_currentIndex >= Count)
            {
                DrawCommand cmd = new DrawCommand();
                _currentIndex++;
                this.Add(cmd);
                return cmd;
            }
            else
            {
                DrawCommand cmd = this[_currentIndex];
                _currentIndex++;
                return cmd;
            }
        }

        public int CommandCount
        {
            get
            {
                return _currentIndex;
            }
        }
    }

    internal class DrawCommand
    {
        public enum DrawCommandType
        {
			None,
            Texture,
            String
        }
        public string Text;
        public G.SpriteFont Font;
        public G.Texture2D Texture;
        public G.Color Color;
        public DrawCommandType CommandType;
        public Vector2 Position;
        public Vector2 Scale;
        public Vector2 Origin;
        public DoubleRectangle SourceRectangle;
        public float Rotation;
        public G.SpriteEffects Effects;
        public float LayerDepth;
        public ShaderEffect ShaderEffect;
        public Root.Rectangle DestinationRectangle;

		public DrawCommand()
		{
			CommandType = DrawCommandType.None;
		}

        public void CalculateDestinationRectangle(Texture2D texture)
        {
            DoubleRectangle rect = SourceRectangle.IsEmpty ? DoubleRectangle.FromRectangle(texture.SourceRect) : SourceRectangle;
            DestinationRectangle = new Rectangle((int)Math.Round(Position.X), (int)Math.Round(Position.Y), (int)Math.Round(rect.Width * Scale.X), (int)Math.Round(rect.Height * Scale.Y));
        }

		public void CopyTo(DrawCommand cmd)
		{
			cmd.CommandType = this.CommandType;
			cmd.Text = this.Text;
			cmd.Font = this.Font;
			cmd.Texture = this.Texture;
			cmd.Color = this.Color;
			cmd.Position = this.Position;
			cmd.Scale = this.Scale;
			cmd.Origin = this.Origin;
			cmd.SourceRectangle = this.SourceRectangle;
			cmd.Rotation = this.Rotation;
			cmd.Effects = this.Effects;
			cmd.ShaderEffect = this.ShaderEffect;
			cmd.DestinationRectangle = this.DestinationRectangle;
		}

		public bool CheckDirty(DrawCommand cmd)
		{
			if (this.CommandType != cmd.CommandType) return true;
			if (this.CommandType == DrawCommandType.String)
			{
				if (Text != cmd.Text || Font != cmd.Font) return true;
			}
			else
			{
				if (Texture != cmd.Texture) return true;
				if (Texture.IsDirty == true) return true;
			}
			if (Color != cmd.Color || Position != cmd.Position ||
				Scale != cmd.Scale || Origin != cmd.Origin ||
				SourceRectangle.Equals(cmd.SourceRectangle) == false ||
				Rotation != cmd.Rotation ||
				Effects != cmd.Effects ||
				ShaderEffect != cmd.ShaderEffect)
			{
				return true;
			}
			return false;
		}
    }
}
