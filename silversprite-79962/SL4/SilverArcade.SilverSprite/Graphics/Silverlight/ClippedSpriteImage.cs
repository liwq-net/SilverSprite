using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using SWM = System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using SilverArcade.SilverSprite.Effects;
using System.Windows.Media.Effects;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SilverArcade.SilverSprite.Graphics
{
    public class ClippedSpriteImage : Sprite
    {
        #region Fields

        SWM.TranslateTransform translate;
        System.Windows.Shapes.Rectangle rectangle;
        Texture2D texture;
        protected SWM.ImageBrush brush;
        DoubleRectangle sourceRectangle;
        #endregion

        #region Properties

        public DoubleRectangle SourceRectangle
        {
            get
            {
                return sourceRectangle;
            }
            set
            {
                if (sourceRectangle.X != value.X ||
                    sourceRectangle.Y != value.Y)
                {
                    translate.X = -value.X;
                    translate.Y = -value.Y;
                }
                if (sourceRectangle.Width != value.Width ||
                    sourceRectangle.Height != value.Height)
                {
                    rectangle.Width = value.Width;
                    rectangle.Height = value.Height;
                }
                sourceRectangle = value;
            }
        }

        public virtual Texture2D Texture2D
        {
            get
            {
                return texture;
            }
            set
            {
                texture = value;
                if (value.VectorGraphic != null)
                {
                    ChildElement = value.CloneVectorGraphic();
                    brush = null;
                }
                else
                    brush.ImageSource = value.ImageSource;
            }
        }

        #endregion

        #region Methods

        public ClippedSpriteImage()
            : base()
        {
            rectangle = new System.Windows.Shapes.Rectangle();
            brush = new SWM.ImageBrush();
            brush.Stretch = SWM.Stretch.None;
            translate = new SWM.TranslateTransform();
            brush.AlignmentX = SWM.AlignmentX.Left;
            brush.AlignmentY = SWM.AlignmentY.Top;
            brush.Transform = translate;
            rectangle.Fill = brush;
            ChildElement = rectangle;
        }

        #endregion
    }
}
