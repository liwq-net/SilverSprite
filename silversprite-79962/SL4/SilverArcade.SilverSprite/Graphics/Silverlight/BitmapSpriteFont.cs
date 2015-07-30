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
using System.Windows.Media.Imaging;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Local = Microsoft.Xna.Framework;

namespace SilverArcade.SilverSprite.Graphics
{
    struct GlyphData
    {
        public char CharacterIndex;
        public Local.Rectangle Glyph;
        public Local.Rectangle Cropping;
        public Vector3 Kerning;
    }

    public class BitmapSpriteFont : SpriteFont
    {
        Texture2D _texture;
        char? _defaultCharacter;
        internal Dictionary<char, GlyphData> characterData = new Dictionary<char, GlyphData>();
        internal WriteableBitmap SourceData;
        public BitmapSpriteFont(Texture2D texture, List<Local.Rectangle>glyphs, List<Local.Rectangle>cropping, List<char>charMap, int lineSpacing, float spacing, List<Vector3>kerning, char? defaultCharacter)
        {
            _texture = texture;
            SourceData = _texture.ImageSource;
            LineSpacing = lineSpacing;
            Spacing = spacing;
            _defaultCharacter = defaultCharacter;
            for (int i = 0; i < charMap.Count; i++)
            {
                GlyphData g = new GlyphData();
                g.Glyph = glyphs[i];
                g.Cropping = cropping[i];
                g.Kerning = kerning[i];
                g.CharacterIndex = charMap[i];
                characterData.Add(g.CharacterIndex, g);
            }
            AssetId = AssetCount;
            AssetCount++;
        }

        internal Vector2 InternalMeasureString(string text)
        {
            Vector2 v = Vector2.Zero;
            float xoffset=0;
            float yoffset=0;

            foreach (char c in text)
            {
                if (c == '\n')
                {
                    yoffset += LineSpacing;
                    xoffset = 0;
                    continue;
                }
                if (characterData.ContainsKey(c) == false) continue;
                GlyphData g = characterData[c];
                xoffset += g.Kerning.Y + g.Kerning.Z + Spacing;
                if (g.Glyph.Height + g.Cropping.Top + yoffset > v.Y)
                {
                    v.Y = yoffset + g.Glyph.Height + g.Cropping.Top;
                }
                if (xoffset > v.X) v.X = xoffset;
            }
            return v;
        }

        public void Draw(BitmapSpriteText sprite, string text)
        {
            Vector2 pos = Vector2.Zero;
            foreach (char c in text)
            {
                if (c == '\n')
                {
                    pos.Y += LineSpacing;
                    pos.X = 0;
                    continue;
                }
                if (characterData.ContainsKey(c) == false) continue;
                GlyphData g = characterData[c];
                sprite.BlitText(pos + new Vector2(g.Cropping.X, g.Cropping.Y), g.Glyph);
                pos.X += (g.Kerning.Y + g.Kerning.Z + Spacing);
            }
        }

        public float GetCharacterSpacing(int asciiNumber)
        {
            GlyphData g = characterData[(char)asciiNumber];
            return (g.Kerning.Y + g.Kerning.Z + Spacing);
        }

    }
}
