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

namespace Silverlight.Samples
{
	public class BmpTexture
	{
		private int							_width = 0;
		private int							_height = 0;
		private WriteableBitmap _wb = null;
		private int[]						_data;

		public BmpTexture(int width, int height)
		{
			_width = width;
			_height = height;

			// Get pixels array
			_data = new int[width*height];
		}

		public BmpTexture(WriteableBitmap wb)
		{
			_height = wb.PixelHeight;
			_width = wb.PixelWidth;
			_wb = wb;

			_data = _wb.Pixels;
		}

		public int Width { get { return _width; } }
		public int Height { get { return _height; } }

		public int GetPixel(int row, int col)
		{
			return _data[(row*_width)+col];
		}

		public Color GetColor(int row, int col)
		{
			int			pixel = GetPixel(row, col);

			return Color.FromArgb((byte)((pixel >> 0x18) & 0xFF),
														(byte)((pixel >> 0x10) & 0xFF),
														(byte)((pixel >> 8) & 0xFF),
														(byte)(pixel & 0xFF));
		}

		public void SetPixel(int row, int col, byte red, byte green, byte blue, byte alpha)
		{
			_data[(row * _width) + col] = alpha << 24 | red << 16 | green << 8 | blue;
		}

		public void SetPixel(int row, int col, Color color)
		{
			SetPixel(row, col, color.R, color.G, color.B, color.A);
		}

		public WriteableBitmap GetWriteableBitmap()
		{
			if (null == _wb)
			{
				// Create WB
				_wb = new WriteableBitmap(_width, _height);
			}

			// Copy data
			_data.CopyTo(_wb.Pixels, 0);

			_wb.Invalidate();

			// Return as writeable bitmap
			return _wb;
		}

	}
}
