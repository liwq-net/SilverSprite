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
using System.Text;
using System.Xml;
using System.Collections.Generic;
using System.Windows.Resources;
using System.IO;
using SilverArcade.SilverSprite.Graphics;

using Microsoft.Xna.Framework;

namespace Microsoft.Xna.Framework.Graphics
{
    public class SpriteFont : Sprite
    {
        public int LineSpacing { get; set; }
        public float Spacing { get; set; }
        double size = 11;
        bool bold = false;
        bool italic = false;
        FontFamily fontFamily;
        public string AssetName;
        internal int AssetId;
        internal static int AssetCount;

        TextBlock tb = new TextBlock();
        Dictionary<string, Vector2> textSizes = new Dictionary<string, Vector2>();
        static Dictionary<string, FontFamily> fontXref = new Dictionary<string, FontFamily>();
        string fontName;



        internal static void AddFont(string xnaFontName, FontFamily silverlightFontFamily)
        {
            fontXref.Add(xnaFontName.ToLower(), silverlightFontFamily);
        }

        public bool CacheStringMeasurements
        {
            get;
            set;
        }

        public char? DefaultCharacter
        {
            set { throw new NotImplementedException(); }
            get { throw new NotImplementedException(); }
        }

        public TextBlock TextBlock
        {
            get { return tb; }
        }

        public Vector2 MeasureString(string text)
        {
            return MeasureString(text, float.MaxValue);

        }

        public Vector2 MeasureString(string text, float maxWidth)
        {
            if (this is BitmapSpriteFont)
            {
                return ((BitmapSpriteFont)this).InternalMeasureString(text);
            }
            if (text == null) text = "";

            if (CacheStringMeasurements)
            {
                if (textSizes.ContainsKey(text))
                {
                    return textSizes[text];
                }
            }

			Vector2 size = Vector2.Zero;

			if (tb.CheckAccess())
			{
				tb.Text = text;
				size = new Vector2((float)tb.ActualWidth, (float)tb.ActualHeight);
				tb.Width = maxWidth;
			}
			else
			{
				tb.Dispatcher.BeginInvoke(() =>
				{
					size = new Vector2((float)tb.ActualWidth, (float)tb.ActualHeight);
					tb.Width = maxWidth;
					tb.Text = text;
				});
			}

		
			if (CacheStringMeasurements)
			{
				textSizes.Add(text, size);
			}
            return size;
        }

        public Vector2 MeasureString(StringBuilder text)
        {
            return MeasureString(text.ToString());
        }

        public SpriteFont()
        {
            CacheStringMeasurements = true; // default to true so that SilverSprite behavior is the same
            AssetId = AssetCount;
            AssetCount++;
        }

        public double FontSize
        {
            get
            {
                return size;
            }
        }

        public bool Bold
        {
            get
            {
                return bold;
            }
        }

        public bool Italic
        {
            get
            {
                return italic;
            }
        }

        void ParseStyle(string style)
        {
            if (style.Contains("Bold"))
            {
                bold = true;
            }
            if (style.Contains("Italic"))
            {
                italic = true;
            }
        }

        void SetFontName(string font)
        {
            string tmp = font.ToLower();
            if (fontXref.ContainsKey(tmp))
            {
                fontFamily = fontXref[tmp];
            }
            else
            {
                fontName = font;
                fontFamily = new FontFamily(font);
            }
        }

        public SpriteFont(Stream stream)
        {
            try
            {

                XmlReader rdr = XmlReader.Create(stream);
                while (rdr.Read())
                {
                    string name = rdr.Name;
                    switch (name)
                    {
                        case "FontName":
                            SetFontName(rdr.ReadElementContentAsString());
                            break;
                        case "Size":
                            size = int.Parse(rdr.ReadElementContentAsString()) * 4f / 3f;
                            break;
                        case "Style":
                            ParseStyle(rdr.ReadElementContentAsString());
                            break;
                    }
                }
                LineSpacing = 35;
                rdr.Close();
            }
            catch
            {
            }
            tb.FontFamily = FontFamily;
            tb.FontSize = size;
            if (italic)
            {
                tb.FontStyle = FontStyles.Italic;
            }
            if (bold)
            {
                tb.FontWeight = FontWeights.Bold;
            }
            AssetId = AssetCount;
            AssetCount++;
        }

        public FontFamily FontFamily
        {
            get
            {
                return fontFamily;
            }
        }

    }
}
