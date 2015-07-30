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
using System.Windows.Media.Imaging;

using Microsoft.Xna.Framework;
using Local = Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SilverArcade.SilverSprite.Graphics
{
    public class BitmapSpriteText : ClippedSpriteImage, IDisposable
    {
        WriteableBitmap renderedText;
        string _text;
        public BitmapSpriteFont Font;
        int pixelWidth;
        int pixelHeight;

        public override Texture2D Texture2D
        {
            get;
            set;
        }

        void RenderText()
        {
            Vector2 size = Font.InternalMeasureString(_text);
            renderedText = new WriteableBitmap((int)size.X, (int)size.Y);
            pixelWidth = renderedText.PixelWidth;
            pixelHeight = renderedText.PixelHeight;
            SourceRectangle = new DoubleRectangle(0, 0, pixelWidth, pixelHeight);
            Font.Draw(this, _text);
            brush.ImageSource = renderedText;
        }

        public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                if (_text != value)
                {
                    _text = value;
                    RenderText();
                    renderedText.Invalidate();
                }
            }
        }

        int blend(byte a, byte b)
        {
            return ((a * b) * 0x8081) >> 23;
        }

        internal void BlitText(Vector2 position, Local.Rectangle source)
        {
            WriteableBitmap SourceImage = Font.SourceData;
            int[] sourcePixels = Font.SourceData.Pixels;
            int[] targetPixels = renderedText.Pixels;
            int sourcePixelWidth = Font.SourceData.PixelWidth;
            int targetPixelWidth = pixelWidth;
            for (int i = 0; i < source.Width; i++)
            {
                for (int j = 0; j < source.Height; j++)
                {
                    int sourceIndex = (source.X + i) + ((source.Y + j) * sourcePixelWidth);
                    uint sourcePixel = (uint)sourcePixels[sourceIndex];
                    int targetIndex = ((int)position.X + i) + (((int)position.Y + j) * targetPixelWidth);
                    uint targetPixel = (uint)targetPixels[targetIndex];
                    int sa = (byte)((sourcePixel >> 24) & 0xff);
                    byte da = (byte)((targetPixel >> 24) & 0xff);
                    if (sa >= 255 || da == 0)
                    {
                        targetPixels[targetIndex] = (int)sourcePixel;
                    }
                    else if (sa == 0)
                    {
                    }
                    else
                    {
                        // not sure if this compositing algorithm is correct, 
                        // there is a good chance it needs to be fixed.
                        byte sr = (byte)((sourcePixel >> 16) & 0xff);
                        byte sg = (byte)((sourcePixel >> 8) & 0xff);
                        byte sb = (byte)((sourcePixel) & 0xff);
                        byte dr = (byte)((targetPixel >> 16) & 0xff);
                        byte dg = (byte)((targetPixel >> 8) & 0xff);
                        byte db = (byte)((targetPixel) & 0xff);
                        int ra = 255 - (255 - sa) * (255 - da) / 255;

                        targetPixels[targetIndex] = (ra << 24) |
                            (blend(sr, dr) << 16) |
                            (blend(sg, dg) << 8) |
                            (blend(sb, db));
                    }
                }
            }
        }

        #region IDisposable Members

        public void Dispose()
        {
            renderedText = null;
            Texture2D = null;
            Font = null;
            Element = null;
        }

        #endregion
    }
}
