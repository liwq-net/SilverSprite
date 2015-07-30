
/*
 * S3 Texture Compression (S3TC) decoding functions
 * Copyright (c) 2007 by Ivo van Poorten
 *
 * see also: http://wiki.multimedia.cx/index.php?title=S3TC
 *
 * The color decoding logic is ported by Bill Reiss to C# from the FFmpeg s3tc.c file.
 *
 * FFmpeg is free software; you can redistribute it and/or
 * modify it under the terms of the GNU Lesser General Public
 * License as published by the Free Software Foundation; either
 * version 2.1 of the License, or (at your option) any later version.
 *
 * FFmpeg is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
 * Lesser General Public License for more details.
 *
 * You should have received a copy of the GNU Lesser General Public
 * License along with FFmpeg; if not, write to the Free Software
 * Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA
 */

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
using System.Windows.Media.Imaging;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Markup;
using SilverArcade.SilverSprite.Graphics;

namespace Microsoft.Xna.Framework.Graphics
{
    public class Texture2D : Texture
    {
        #region Fields

        static int AssetCount;
        internal int AssetId;
        public string AssetName;
        int _rowLength;
        int _width = -1;
        int _height = -1;
        public WriteableBitmap ImageSource;
        public Canvas VectorGraphic;
        private string _vectorGraphicsString;
        Rectangle rect = new Rectangle();
        static uint[] bitmasks = { 0x00, 0x01, 0x03, 0x07, 0x0f, 0x1f, 0x3f, 0x7f, 0xff };
        string mName;
		public bool IsDirty;
        SurfaceFormat mSurfaceFormat;

        #endregion

        #region Properties

        public Rectangle SourceRect
        {
            get
            {
                if (Width != rect.Width)
                {
                    rect.Width = Width;
                }
                if (Height != rect.Height)
                {
                    rect.Height = Height;
                }

                return rect;
            }
        }
        public int Width
        {
            get
            {
                if (ImageSource != null)
                {

                    if (_width < 0)
                    {
                        if (ImageSource != null && ImageSource.PixelWidth > 0)
                        {
                            _width = (int)ImageSource.PixelWidth;
                        }
                        else
                        {
                            return 0;
                        }
                    }
                    return _width;
                }
                else
                {
                    return (int)VectorGraphic.Width;
                }
            }
        }

        public int Height
        {
            get
            {
                if (ImageSource != null)
                {
                    if (_height < 0)
                    {
                        if (ImageSource != null && ImageSource.PixelHeight > 0)
                        {
                            _height = (int)ImageSource.PixelHeight;
                        }
                        else
                        {
                            return 0;
                        }
                    }
                    return _height;
                }
                else
                {
                    return (int)VectorGraphic.Height;
                }
            }
        }


        public SurfaceFormat Format
        {
            get { return mSurfaceFormat; }
        }

        public TextureUsage TextureUsage
        {
            get { throw new NotImplementedException(); }
        }


        public Object Tag
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public bool IsDisposed
        {
            get { return _isDisposed; }
        }

        public string Name
        {
            get { return mName; }
            set { mName = value; }
        }


        #endregion

        #region Events

        public event EventHandler Disposing;

        #endregion

        #region Methods


		internal Texture2D(WriteableBitmap bmp)
		{
			AssetId = AssetCount;
			AssetCount++;
			ImageSource = bmp;
			_width = bmp.PixelWidth;
			_height = bmp.PixelHeight;
			AssetName = Guid.NewGuid().ToString();
		}

		public Texture2D(GraphicsDevice device, int width, int height)
		{
			GraphicsDevice = device;

			ImageSource = new WriteableBitmap(width, height);

			//            SpriteImage = new WriteableBitmap(img.PixelWidth, img.PixelHeight);
			//            SpriteImage.Source = img;
			//            SpriteImage.Opacity = 0;
			//            device.Root.Children.Add(SpriteImage);
			AssetId = AssetCount;
			AssetCount++;
			if (width > 0 && height > 0)
			{
				_width = (int)width;
				_height = (int)height;
			}
			else
			{
				_width = -1;
				_height = -1;
			}

			mSurfaceFormat = SurfaceFormat.Color;
		}

        public Texture2D(Stream source, GraphicsDevice device)
        {
            AssetId = AssetCount;
            AssetCount++;
			GraphicsDevice = device;

            using (var rdr = new StreamReader(source))
            {
                _vectorGraphicsString = rdr.ReadToEnd();

                VectorGraphic = XamlReader.Load(_vectorGraphicsString) as Canvas;

                if (VectorGraphic == null)
                    throw new Exception("Could not load vector graphic.");
            }

            // Vic says - This is a guess.
            mSurfaceFormat = SurfaceFormat.Color;
        }

        public Canvas CloneVectorGraphic()
        {
            return XamlReader.Load(_vectorGraphicsString) as Canvas;
        }

        public Texture2D(Stream source, GraphicsDevice device, Vector2 size)
        {
			GraphicsDevice = device;
            ImageSource = new WriteableBitmap(ImageLoader.GetBitmapImage(source));
            //            SpriteImage = new WriteableBitmap(img.PixelWidth, img.PixelHeight);
            //            SpriteImage.Source = img;
            //            SpriteImage.Opacity = 0;
            //            device.Root.Children.Add(SpriteImage);
            AssetId = AssetCount;
            AssetCount++;
            if (size.X > 0 && size.Y > 0)
            {
                _width = (int)size.X;
                _height = (int)size.Y;
            }
            else
            {
                _width = -1;
                _height = -1;
            }

            mSurfaceFormat = SurfaceFormat.Color;

        }

        public Texture2D(BitmapImage bitmapImage, GraphicsDevice device, Vector2 size, string name)
        {
			GraphicsDevice = device;
			this.mName = name;

            ImageSource = new WriteableBitmap(bitmapImage);
            
            //            SpriteImage = new WriteableBitmap(img.PixelWidth, img.PixelHeight);
            //            SpriteImage.Source = img;
            //            SpriteImage.Opacity = 0;
            //            device.Root.Children.Add(SpriteImage);
            AssetId = AssetCount;
            AssetCount++;
            if (size.X > 0 && size.Y > 0)
            {
                _width = (int)size.X;
                _height = (int)size.Y;
            }
            else
            {
                _width = -1;
                _height = -1;
            }

            mSurfaceFormat = SurfaceFormat.Color;

        }

        public Texture2D(GraphicsDevice graphicsDevice, int width, int height, int numberLevels, TextureUsage usage, SurfaceFormat format)
        {
			GraphicsDevice = graphicsDevice;
			_width = width;
            _height = height;
            rect.Width = _width;
            rect.Height = _height;
            _rowLength = _width * 4 + 1;
            AssetName = Guid.NewGuid().ToString();
            AssetId = AssetCount;
            AssetCount++;
            mSurfaceFormat = format;


            ImageSource = new WriteableBitmap(_width, _height);
        }

        public Texture2D(TextureCreationParameters param, byte[] data)
        {
            _width = param.Width;
            _height = param.Height;
            rect.Width = _width;
            rect.Height = _height;
            _rowLength = _width * 4 + 1;
            ImageSource = new WriteableBitmap(_width, _height);
            SetData<byte>(data);
            AssetId = AssetCount;
            mSurfaceFormat = SurfaceFormat.Color;
            AssetCount++;
        }

		Color GetPixel(int index)
		{
			int pixel = ImageSource.Pixels[index];
			int a = (pixel >> 24) & 0xff;
			int r = (pixel >> 16) & 0xff;
			int g = (pixel >> 8) & 0xff;
			int b = (pixel) & 0xff;
			if (a != 255 && a != 0)
			{
				r = r * 255 / a;
				g = g * 255 / a;
				b = b * 255 / a;
			}
			Color color = new Color((byte)r, (byte)g, (byte)b, (byte)a);
			return color;
		}

        public Color GetPixel(int col, int row)
        {
			return GetPixel(row * ImageSource.PixelWidth + col);
        }

        public void SetPixel(int col, int row, byte red, byte green, byte blue, byte alpha)
        {
            int index = row * Width + col;
            double pct = alpha / 255d;
            int pixel = (alpha << 24) + (((int)(red * pct)) << 16) + (((int)(green * pct)) << 8) + ((int)(blue * pct));
            ImageSource.Pixels[index] = (int)pixel;
			IsDirty = true;
		}

        public void SetData<T>(T[] data)
        {
            SetData<T>(data, 0, data.Length, SetDataOptions.None);
			IsDirty = true;
		}


        public void SetData<T>(T[] data, int startIndex, int elementCount, SetDataOptions options)
        {
            int i = 0;
            int j = 0;
            int endIndex = startIndex + elementCount;

            // i and j are going to get set depending on the start index
            // That's why j is set AFTER its loop

            int width = Width;
            int height = Height;
            
            i = startIndex / Width;
            j = startIndex % Width;

            if (typeof(T) == typeof(byte))
            {
                byte[] b = data.Cast<byte>().ToArray();
                int idx = startIndex;

                for ( ; i < height; i++)
                {
                    for ( ; j < width; j++)
                    {
                        SetPixel(j, i, b[idx + 2], b[idx + 1], b[idx], b[idx + 3]);
                        idx += 4;
                        if (idx >= elementCount)
                        {
                            break; 
                        }
                    }
                    if (idx >= elementCount)
                    {
                        break;
                    }
                    
                    j = 0;
                }
            }
            else if (typeof(T) == typeof(Color))
            {
                Color[] c = data.Cast<Color>().ToArray();
                int idx = startIndex;
                for ( ; i < height; i++)
                {
                    for (; j < width; j++)
                    {
                        SetPixel(j, i, c[idx].R, c[idx].G, c[idx].B, c[idx].A);
                        idx++;

                        if (idx >= elementCount)
                        {
                            break;
                        }
                    }
                    if (idx >= elementCount)
                    {
                        break;
                    }
                    j = 0;
                }
            }
            ImageSource.Invalidate();
			IsDirty = true;
        }


        static byte GetBits64(ulong source, int first, int length, int shift)
        {
            uint bitmask = bitmasks[length];
            source = source >> first;
            source = source & bitmask;
            source = source << shift;
            return (byte)source;
        }

        static byte GetBits(uint source, int first, int length, int shift)
        {
            uint bitmask = bitmasks[length];
            source = source >> first;
            source = source & bitmask;
            source = source << shift;
            return (byte)source;
        }

        static void SetColorFromPacked(byte[] data, int offset, byte alpha, uint packed)
        {
            byte r = (byte)(GetBits(packed, 0, 8, 0));
            byte g = (byte)(GetBits(packed, 8, 8, 0));
            byte b = (byte)(GetBits(packed, 16, 8, 0));
            data[offset] = r;
            data[offset + 1] = g;
            data[offset + 2] = b;
            data[offset + 3] = alpha;
        }

        static void ColorsFromPacked(uint[] colors, uint c0, uint c1, bool flag)
        {
            uint rb0, rb1, rb2, rb3, g0, g1, g2, g3;

            rb0 = (c0 << 3 | c0 << 8) & 0xf800f8;
            rb1 = (c1 << 3 | c1 << 8) & 0xf800f8;
            rb0 += (rb0 >> 5) & 0x070007;
            rb1 += (rb1 >> 5) & 0x070007;
            g0 = (c0 << 5) & 0x00fc00;
            g1 = (c1 << 5) & 0x00fc00;
            g0 += (g0 >> 6) & 0x000300;
            g1 += (g1 >> 6) & 0x000300;

            colors[0] = rb0 + g0;
            colors[1] = rb1 + g1;

            if (c0 > c1 || flag)
            {
                rb2 = (((2 * rb0 + rb1) * 21) >> 6) & 0xff00ff;
                rb3 = (((2 * rb1 + rb0) * 21) >> 6) & 0xff00ff;
                g2 = (((2 * g0 + g1) * 21) >> 6) & 0x00ff00;
                g3 = (((2 * g1 + g0) * 21) >> 6) & 0x00ff00;
                colors[3] = rb3 + g3;
            }
            else
            {
                rb2 = ((rb0 + rb1) >> 1) & 0xff00ff;
                g2 = ((g0 + g1) >> 1) & 0x00ff00;
                colors[3] = 0;
            }

            colors[2] = rb2 + g2;
        }

        static Texture2D FromDxt1File(GraphicsDevice graphicsDevice, Stream stream, int length, TextureCreationParameters param)
        {
            BinaryReader rdr = new BinaryReader(stream);
            int xoffset = 0;
            int yoffset = 0;
            int rowLength = param.Width * 4;
            byte[] b = new byte[length];
            ushort c0;
            ushort c1;
            uint[] colors = new uint[4];

            uint lu;

            for (int y = 0; y < param.Height / 4; y++)
            {
                yoffset = y * 4;
                for (int x = 0; x < param.Width / 4; x++)
                {
                    xoffset = x * 4;
                    c0 = rdr.ReadUInt16();
                    c1 = rdr.ReadUInt16();
                    ColorsFromPacked(colors, c0, c1, false);

                    lu = rdr.ReadUInt32();
                    for (int i = 0; i < 16; i++)
                    {
                        int idx = GetBits(lu, 30 - i * 2, 2, 0);
                        int ii = 15 - i;
                        byte aa = 255;
                        int yy = yoffset + (ii / 4);
                        int xx = xoffset + (ii % 4);
                        int offset = yy * rowLength + xx * 4;
                        uint ci = colors[idx];
                        SetColorFromPacked(b, offset, aa, ci);
                    }
                }
            }
			Texture2D texture = new Texture2D(param, b);
			texture.GraphicsDevice = graphicsDevice;
			return texture;
		}

        static Texture2D FromDxt5File(GraphicsDevice graphicsDevice, Stream stream, int length, TextureCreationParameters param)
        {
            BinaryReader rdr = new BinaryReader(stream);
            int xoffset = 0;
            int yoffset = 0;
            int rowLength = param.Width * 4;
            byte[] b = new byte[length];
            ulong alpha;
            ushort c0;
            ushort c1;
            uint[] colors = new uint[4];

            uint lu;
            byte[] a = new byte[8];
            byte[] al = new byte[6];
            ulong ax;

            for (int y = 0; y < param.Height / 4; y++)
            {
                yoffset = y * 4;
                for (int x = 0; x < param.Width / 4; x++)
                {
                    xoffset = x * 4;
                    a[0] = rdr.ReadByte();
                    a[1] = rdr.ReadByte();
                    if (a[0] > a[1])
                    {
                        a[2] = (byte)(((6 * a[0]) + a[1]) / 7);
                        a[3] = (byte)(((5 * a[0]) + (2 * a[1])) / 7);
                        a[4] = (byte)(((4 * a[0]) + (3 * a[1])) / 7);
                        a[5] = (byte)(((3 * a[0]) + (4 * a[1])) / 7);
                        a[6] = (byte)(((2 * a[0]) + (5 * a[1])) / 7);
                        a[7] = (byte)(((1 * a[0]) + (6 * a[1])) / 7);
                    }
                    else
                    {
                        a[2] = (byte)(((4 * a[0]) + (1 * a[1])) / 5);
                        a[3] = (byte)(((3 * a[0]) + (2 * a[1])) / 5);
                        a[4] = (byte)(((2 * a[0]) + (3 * a[1])) / 5);
                        a[5] = (byte)(((1 * a[0]) + (2 * a[1])) / 5);
                        a[6] = 0;
                        a[7] = 255;
                    }
                    rdr.Read(al, 0, 6);
                    ax = (ulong)(
                        (((ulong)al[5]) << 40) +
                        (((ulong)(al[4]) << 32) +
                        (((ulong)al[3]) << 24) +
                        (((ulong)al[2]) << 16) +
                        (((ulong)al[1]) << 8) +
                        (ulong)al[0]));

                    c0 = rdr.ReadUInt16();
                    c1 = rdr.ReadUInt16();
                    ColorsFromPacked(colors, c0, c1, true);

                    lu = rdr.ReadUInt32();
                    for (int i = 0; i < 16; i++)
                    {
                        int idx = GetBits(lu, 30 - i * 2, 2, 0);
                        int ii = 15 - i;
                        int aidx = GetBits64(ax, ii * 3, 3, 0);
                        byte aa = a[aidx];
                        int yy = yoffset + (ii / 4);
                        int xx = xoffset + (ii % 4);
                        int offset = yy * rowLength + xx * 4;
                        uint ci = colors[idx];
                        SetColorFromPacked(b, offset, aa, ci);
                    }
                }
            }
			Texture2D texture = new Texture2D(param, b);
			texture.GraphicsDevice = graphicsDevice;
			return texture;
		}

        static Texture2D FromDxt3File(GraphicsDevice graphicsDevice, Stream stream, int length, TextureCreationParameters param)
        {
            BinaryReader rdr = new BinaryReader(stream);
            int xoffset = 0;
            int yoffset = 0;
            int rowLength = param.Width * 4;
            byte[] b = new byte[length];
            ulong alpha;
            ushort c0, c1;
            uint[] colors = new uint[4];
            uint lu;

            for (int y = 0; y < param.Height / 4; y++)
            {
                yoffset = y * 4;
                for (int x = 0; x < param.Width / 4; x++)
                {
                    xoffset = x * 4;
                    alpha = rdr.ReadUInt64();
                    c0 = rdr.ReadUInt16();
                    c1 = rdr.ReadUInt16();
                    ColorsFromPacked(colors, c0, c1, true);

                    lu = rdr.ReadUInt32();
                    for (int i = 0; i < 16; i++)
                    {
                        int idx = GetBits(lu, 30 - i * 2, 2, 0);
                        uint ci = colors[idx];
                        int ii = 15 - i;
                        byte a = (byte)(GetBits64(alpha, ii * 4, 4, 0));
                        a += (byte)(a << 4);
                        int yy = yoffset + (ii / 4);
                        int xx = xoffset + (ii % 4);
                        int offset = yy * rowLength + xx * 4;
                        SetColorFromPacked(b, offset, a, ci);
                    }
                }
            }
			Texture2D texture = new Texture2D(param, b);
			texture.GraphicsDevice = graphicsDevice;
			return texture;
		}

        public static Texture2D FromFile(GraphicsDevice graphicsDevice, Stream stream, int length, TextureCreationParameters param)
        {
            if (param.Format == SurfaceFormat.Dxt3)
            {
                return FromDxt3File(graphicsDevice, stream, length, param);
            }
            else if (param.Format == SurfaceFormat.Dxt5)
            {
                return FromDxt5File(graphicsDevice, stream, length, param);
            }
            else if (param.Format == SurfaceFormat.Dxt1)
            {
                return FromDxt1File(graphicsDevice, stream, length, param);
            }
            else if (param.Format == SurfaceFormat.Color)
            {
                byte[] b = new byte[length];
                stream.Read(b, 0, length);
				Texture2D texture = new Texture2D(param, b);
				texture.GraphicsDevice = graphicsDevice;
				return texture;
			}
            else
            {
                return null;
            }
        }

		public void Cleanup()
		{
			GraphicsDevice.CleanupTexture(this);
		}

        protected override void  Dispose(bool disposing)
        {
			Cleanup();
            ImageSource = null;
            VectorGraphic = null;
            bitmasks = null;

            _isDisposed = true;
        }

        public static Texture2D FromFile(GraphicsDevice graphicsDevice, Stream textureStream)
        {
            throw new NotImplementedException();
        }

        public static Texture2D FromFile(GraphicsDevice graphicsDevice, Stream textureStream, int numberBytes)
        {
            throw new NotImplementedException();
        }

        public static Texture2D FromFile(GraphicsDevice graphicsDevice, Stream textureStream, TextureCreationParameters creationParameters)
        {
            throw new NotImplementedException();
        }

        public static Texture2D FromFile(GraphicsDevice graphicsDevice, string filename, TextureCreationParameters creationParameters)
        {
            throw new NotImplementedException();
        }

        public static Texture2D FromFile(GraphicsDevice graphicsDevice, string filename, int width, int height)
        {
            throw new NotImplementedException();
        }

        public static Texture2D FromFile(GraphicsDevice graphicsDevice, string filename)
        {
            throw new NotImplementedException();
        }


        public void SetData<T>(int level, Rectangle? rect, T[] data, int startIndex, int elementCount, SetDataOptions options)
        {
            throw new NotImplementedException();
        }

        public void GetData<T>(T[] data)
        {
			GetData<T>(0, null, data, 0, _width * _height);
        }

        public void GetData<T>(T[] data, int startIndex, int elementCount)
        {
			GetData<T>(0, null, data, startIndex, elementCount);
		}

        public void GetData<T>(int level, Rectangle? rect, T[] data, int startIndex, int elementCount)
        {
			Rectangle r;
			if (rect != null)
			{
				r = rect.Value;
			}
			else
			{
				r = new Rectangle(0, 0, _width, _height);
			}
			if (data.Length < startIndex + elementCount)
			{
				throw new ArgumentException("The data passed has a length of " + data.Length + " but " + elementCount + " pixels have been requested.");
			}
			if (typeof(T) == typeof(Color))
			{
				Color[] castedToColor = data as Color[];
				int count=0;
				for (int y = r.Top; y < r.Bottom; y++)
				{
					for (int x = r.Left; x < r.Right; x++)
					{
						castedToColor[count + startIndex] = GetPixel(x,y);
						count++;
						if (count >= elementCount) return;
					}
				}
			}
			else if (typeof(T) == typeof(uint))
			{
				uint[] castedToUint = data as uint[];
				Color[] castedToColor = data as Color[];
				int count = 0;
				for (int y = r.Top; y < r.Bottom; y++)
				{
					for (int x = r.Left; x < r.Right; x++)
					{
						castedToUint[count+startIndex] = GetPixel(x,y).PackedValue;
						count++;
						if (count >= elementCount) return;
					}
				}
			}
			else
			{
				throw new NotImplementedException();
			}
		}

        #endregion
        
    }
}
