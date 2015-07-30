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
using System.Windows.Media.Effects;
#if USE_FARSEER
using FarseerGames.FarseerPhysics.Mathematics;
#endif

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
            Texture,
            String
        }
        public string Text;
        public SpriteFont Font;
        public Texture2D Texture;
        public Color Color;
        public DrawCommandType CommandType;
        public Vector2 Position;
        public Vector2 Scale;
        public Vector2 Origin;
        public Rectangle SourceRectangle;
        public float Rotation;
        public SpriteEffects Effects;
        public float LayerDepth;
        public ShaderEffect ShaderEffect;
    }
}
