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
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace SilverArcade.SilverSprite.Graphics
{
    public class SpriteImage : Sprite
    {
        #region Fields
        Image image;
        Texture2D texture;
        #endregion

        #region Properties

        public virtual Texture2D Texture2D
        {
            get
            {
                return texture;
            }
            set
            {
                if (texture != value)
                {
                    texture = value;
                    if (value.VectorGraphic != null)
                    {
                        ChildElement = value.CloneVectorGraphic();
                    }
                    else
                    {
                        image = new Image();
                        image.Source = texture.ImageSource;
                        image.Width = texture.Width;
                        image.Height = texture.Height;
                        ChildElement = image;
                    }
                }
            }
        }

        #endregion

        #region Methods

        public SpriteImage()
            : base()
        {
        }

        #endregion
    }
}
