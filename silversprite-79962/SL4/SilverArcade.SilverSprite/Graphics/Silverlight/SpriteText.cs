using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SilverArcade.SilverSprite.Graphics
{
    public class SpriteText : Sprite
    {
        TextBlock textBlock;
        SpriteFont font;
        string text = "";
        Color color = Color.Black;
        public SpriteText()
        {
            textBlock = new TextBlock();
            ChildElement = textBlock;
        }

        public Color Color
        {
            get
            {
                return color;
            }
            set
            {
                if (color != value)
                {
                    color = value;
                    textBlock.Foreground = new System.Windows.Media.SolidColorBrush(value.ToSilverlightColor());
                }
            }
        }

        public SpriteFont Font
        {
            get
            {
                return font;
            }
            set
            {
                if (font != value)
                {
                    font = value;
                    if (font.Bold)
                    {
                        textBlock.FontWeight = FontWeights.Bold;
                    }
                    else
                    {
                        textBlock.FontWeight = FontWeights.Normal;
                    }

                    if (font.Italic)
                    {
                        textBlock.FontStyle = FontStyles.Italic;
                    }
                    else
                    {
                        textBlock.FontStyle = FontStyles.Normal;
                    }

                    textBlock.FontSize = value.FontSize;
                    textBlock.FontFamily = value.FontFamily;
                }
            }
        }

        public string Text
        {
            get
            {
                return text;
            }
            set
            {
                if (text != value)
                {
                    textBlock.Text = value;
                    text = value;
                }
            }
        }
    }
}
