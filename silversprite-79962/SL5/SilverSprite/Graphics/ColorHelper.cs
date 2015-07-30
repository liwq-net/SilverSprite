using System;
using System.Collections.Generic;

namespace Microsoft.Xna.Framework.Graphics
{
    public static class ColorHelper
    {
        public static Color Create(uint argbValue)
        {
            Color c = new Color();
            c.A = (byte)((argbValue >> 24) & 0xFF);
            c.R = (byte)((argbValue >> 16) & 0xFF);
            c.G = (byte)((argbValue >> 8) & 0xFF);
            c.B = (byte)((argbValue) & 0xFF);
            return c;
        }

        public static Color Create(Vector4 color)
        {
            Color c = new Color(color.X, color.Y, color.Z, color.W);
            return c;
        }

        public static Color Create(Vector3 color)
        {
            Color c = new Color(color.X, color.Y, color.Z, 1);
            return c;
        }

        public static Color Create(Color color, byte alpha)
        {
            Color c = color;
            c.A = alpha;
            return c;
        }

        public static Color Create(Color color, float alpha)
        {
            Color c = color;
            c.A = Convert.ToByte(alpha * 255);
            return c;
        }

        public static System.Windows.Media.Color ToSilverlightColor(this Color color)
        {
            return System.Windows.Media.Color.FromArgb(color.A, color.R, color.G, color.B);
        }

        public static int ToPrgbaInt(Color color)
        {
            int a = color.A;
            double pa = a / 255d;
            int r = (int)(color.R * pa);
            int g = (int)(color.G * pa);
            int b = (int)(color.B * pa);
            return (a << 24) + (r << 16) + (g << 8) + b;
        }

        public static readonly Color TransparentBlack = ColorHelper.Create(0);
        public static readonly Color TransparentWhite = ColorHelper.Create(0xffffff);
        public static readonly Color AliceBlue = ColorHelper.Create(0xfff0f8ff);
        public static readonly Color AntiqueWhite = ColorHelper.Create(0xfffaebd7);
        public static readonly Color Aqua = ColorHelper.Create(0xff00ffff);
        public static readonly Color Aquamarine = ColorHelper.Create(0xff7fffd4);
        public static readonly Color Azure = ColorHelper.Create(0xfff0ffff);
        public static readonly Color Beige = ColorHelper.Create(0xfff5f5dc);
        public static readonly Color Bisque = ColorHelper.Create(0xffffe4c4);
        public static readonly Color Black = ColorHelper.Create(0xff000000);
        public static readonly Color BlanchedAlmond = ColorHelper.Create(0xffffebcd);
        public static readonly Color Blue = ColorHelper.Create(0xff0000ff);
        public static readonly Color BlueViolet = ColorHelper.Create(0xff8a2be2);
        public static readonly Color Brown = ColorHelper.Create(0xffa52a2a);
        public static readonly Color BurlyWood = ColorHelper.Create(0xffdeb887);
        public static readonly Color CadetBlue = ColorHelper.Create(0xff5f9ea0);
        public static readonly Color Chartreuse = ColorHelper.Create(0xff7fff00);
        public static readonly Color Chocolate = ColorHelper.Create(0xffd2691e);
        public static readonly Color Coral = ColorHelper.Create(0xffff7f50);
        public static readonly Color CornflowerBlue = ColorHelper.Create(0xff6495ed);
        public static readonly Color Cornsilk = ColorHelper.Create(0xfffff8dc);
        public static readonly Color Crimson = ColorHelper.Create(0xffdc143c);
        public static readonly Color Cyan = ColorHelper.Create(0xff00ffff);
        public static readonly Color DarkBlue = ColorHelper.Create(0xff00008b);
        public static readonly Color DarkCyan = ColorHelper.Create(0xff008b8b);
        public static readonly Color DarkGoldenrod = ColorHelper.Create(0xffb8860b);
        public static readonly Color DarkGray = ColorHelper.Create(0xffa9a9a9);
        public static readonly Color DarkGreen = ColorHelper.Create(0xff006400);
        public static readonly Color DarkKhaki = ColorHelper.Create(0xffbdb76b);
        public static readonly Color DarkMagenta = ColorHelper.Create(0xff8b008b);
        public static readonly Color DarkOliveGreen = ColorHelper.Create(0xff556b2f);
        public static readonly Color DarkOrange = ColorHelper.Create(0xffff8c00);
        public static readonly Color DarkOrchid = ColorHelper.Create(0xff9932cc);
        public static readonly Color DarkRed = ColorHelper.Create(0xff8b0000);
        public static readonly Color DarkSalmon = ColorHelper.Create(0xffe9967a);
        public static readonly Color DarkSeaGreen = ColorHelper.Create(0xff8fbc8b);
        public static readonly Color DarkSlateBlue = ColorHelper.Create(0xff483d8b);
        public static readonly Color DarkSlateGray = ColorHelper.Create(0xff2f4f4f);
        public static readonly Color DarkTurquoise = ColorHelper.Create(0xff00ced1);
        public static readonly Color DarkViolet = ColorHelper.Create(0xff9400d3);
        public static readonly Color DeepPink = ColorHelper.Create(0xffff1493);
        public static readonly Color DeepSkyBlue = ColorHelper.Create(0xff00bfff);
        public static readonly Color DimGray = ColorHelper.Create(0xff696969);
        public static readonly Color DodgerBlue = ColorHelper.Create(0xff1e90ff);
        public static readonly Color Firebrick = ColorHelper.Create(0xffb22222);
        public static readonly Color FloralWhite = ColorHelper.Create(0xfffffaf0);
        public static readonly Color ForestGreen = ColorHelper.Create(0xff228b22);
        public static readonly Color Fuchsia = ColorHelper.Create(0xffff00ff);
        public static readonly Color Gainsboro = ColorHelper.Create(0xffdcdcdc);
        public static readonly Color GhostWhite = ColorHelper.Create(0xfff8f8ff);
        public static readonly Color Gold = ColorHelper.Create(0xffffd700);
        public static readonly Color Goldenrod = ColorHelper.Create(0xffdaa520);
        public static readonly Color Gray = ColorHelper.Create(0xff808080);
        public static readonly Color Green = ColorHelper.Create(0xff008000);
        public static readonly Color GreenYellow = ColorHelper.Create(0xffadff2f);
        public static readonly Color Honeydew = ColorHelper.Create(0xfff0fff0);
        public static readonly Color HotPink = ColorHelper.Create(0xffff69b4);
        public static readonly Color IndianRed = ColorHelper. Create(0xffcd5c5c);
        public static readonly Color Indigo = ColorHelper.Create(0xff4b0082);
        public static readonly Color Ivory = ColorHelper.Create(0xfffffff0);
        public static readonly Color Khaki = ColorHelper.Create(0xfff0e68c);
        public static readonly Color Lavender = ColorHelper.Create(0xffe6e6fa);
        public static readonly Color LavenderBlush = ColorHelper.Create(0xfffff0f5);
        public static readonly Color LawnGreen = ColorHelper.Create(0xff7cfc00);
        public static readonly Color LemonChiffon = ColorHelper.Create(0xfffffacd);
        public static readonly Color LightBlue = ColorHelper.Create(0xffadd8e6);
        public static readonly Color LightCoral = ColorHelper. Create(0xfff08080);
        public static readonly Color LightCyan = ColorHelper. Create(0xffe0ffff);
        public static readonly Color LightGoldenrodYellow = ColorHelper.Create(0xfffafad2);
        public static readonly Color LightGreen = ColorHelper.Create(0xff90ee90);
        public static readonly Color LightGray = ColorHelper.Create(0xffd3d3d3);
        public static readonly Color LightPink = ColorHelper.Create(0xffffb6c1);
        public static readonly Color LightSalmon = ColorHelper.Create(0xffffa07a);
        public static readonly Color LightSeaGreen = ColorHelper.Create(0xff20b2aa);
        public static readonly Color LightSkyBlue = ColorHelper.Create(0xff87cefa);
        public static readonly Color LightSlateGray = ColorHelper.Create(0xff778899);
        public static readonly Color LightSteelBlue = ColorHelper.Create(0xffb0c4de);
        public static readonly Color LightYellow = ColorHelper.Create(0xffffffe0);
        public static readonly Color Lime = ColorHelper.Create(0xff00ff00);
        public static readonly Color LimeGreen = ColorHelper.Create(0xff32cd32);
        public static readonly Color Linen = ColorHelper.Create(0xfffaf0e6);
        public static readonly Color Magenta = ColorHelper.Create(0xffff00ff);
        public static readonly Color Maroon = ColorHelper.Create(0xff800000);
        public static readonly Color MediumAquamarine = ColorHelper.Create(0xff66cdaa);
        public static readonly Color MediumBlue = ColorHelper.Create(0xff0000cd);
        public static readonly Color MediumOrchid = ColorHelper.Create(0xffba55d3);
        public static readonly Color MediumPurple = ColorHelper.Create(0xff9370db);
        public static readonly Color MediumSeaGreen = ColorHelper.Create(0xff3cb371);
        public static readonly Color MediumSlateBlue = ColorHelper.Create(0xff7b68ee);
        public static readonly Color MediumSpringGreen = ColorHelper.Create(0xff00fa9a);
        public static readonly Color MediumTurquoise = ColorHelper.Create(0xff48d1cc);
        public static readonly Color MediumVioletRed = ColorHelper.Create(0xffc71585);
        public static readonly Color MidnightBlue = ColorHelper.Create(0xff191970);
        public static readonly Color MintCream = ColorHelper.Create(0xfff5fffa);
        public static readonly Color MistyRose = ColorHelper.Create(0xffffe4e1);
        public static readonly Color Moccasin = ColorHelper.Create(0xffffe4b5);
        public static readonly Color NavajoWhite = ColorHelper.Create(0xffffdead);
        public static readonly Color Navy = ColorHelper.Create(0xff000080);
        public static readonly Color OldLace = ColorHelper.Create(0xfffdf5e6);
        public static readonly Color Olive = ColorHelper.Create(0xff808000);
        public static readonly Color OliveDrab = ColorHelper.Create(0xff6b8e23);
        public static readonly Color Orange = ColorHelper.Create(0xffffa500);
        public static readonly Color OrangeRed = ColorHelper.Create(0xffff4500);
        public static readonly Color Orchid = ColorHelper.Create(0xffda70d6);
        public static readonly Color PaleGoldenrod = ColorHelper.Create(0xffeee8aa);
        public static readonly Color PaleGreen = ColorHelper.Create(0xff98fb98);
        public static readonly Color PaleTurquoise = ColorHelper.Create(0xffafeeee);
        public static readonly Color PaleVioletRed = ColorHelper.Create(0xffdb7093);
        public static readonly Color PapayaWhip = ColorHelper.Create(0xffffefd5);
        public static readonly Color PeachPuff = ColorHelper.Create(0xffffdab9);
        public static readonly Color Peru = ColorHelper.Create(0xffcd853f);
        public static readonly Color Pink = ColorHelper.Create(0xffffc0cb);
        public static readonly Color Plum = ColorHelper.Create(0xffdda0dd);
        public static readonly Color PowderBlue = ColorHelper.Create(0xffb0e0e6);
        public static readonly Color Purple = ColorHelper.Create(0xff800080);
        public static readonly Color Red = ColorHelper.Create(0xffff0000);
        public static readonly Color RosyBrown = ColorHelper.Create(0xffbc8f8f);
        public static readonly Color RoyalBlue = ColorHelper.Create(0xff4169e1);
        public static readonly Color SaddleBrown = ColorHelper.Create(0xff8b4513);
        public static readonly Color Salmon = ColorHelper.Create(0xfffa8072);
        public static readonly Color SandyBrown = ColorHelper.Create(0xfff4a460);
        public static readonly Color SeaGreen = ColorHelper.Create(0xff2e8b57);
        public static readonly Color SeaShell = ColorHelper.Create(0xfffff5ee);
        public static readonly Color Sienna = ColorHelper.Create(0xffa0522d);
        public static readonly Color Silver = ColorHelper.Create(0xffc0c0c0);
        public static readonly Color SkyBlue = ColorHelper.Create(0xff87ceeb);
        public static readonly Color SlateBlue = ColorHelper.Create(0xff6a5acd);
        public static readonly Color SlateGray = ColorHelper.Create(0xff708090);
        public static readonly Color Snow = ColorHelper.Create(0xfffffafa);
        public static readonly Color SpringGreen = ColorHelper.Create(0xff00ff7f);
        public static readonly Color SteelBlue = ColorHelper.Create(0xff4682b4);
        public static readonly Color Tan = ColorHelper.Create(0xffd2b48c);
        public static readonly Color Teal = ColorHelper.Create(0xff008080);
        public static readonly Color Thistle = ColorHelper.Create(0xffd8bfd8);
        public static readonly Color Tomato = ColorHelper.Create(0xffff6347);
        public static readonly Color Turquoise = ColorHelper.Create(0xff40e0d0);
        public static readonly Color Violet = ColorHelper.Create(0xffee82ee);
        public static readonly Color Wheat = ColorHelper.Create(0xfff5deb3);
        public static readonly Color White = ColorHelper.Create(uint.MaxValue);
        public static readonly Color WhiteSmoke = ColorHelper.Create(0xfff5f5f5);
        public static readonly Color Yellow = ColorHelper.Create(0xffffff00);
        public static readonly Color YellowGreen = ColorHelper.Create(0xff9acd32);

        public static Color Lerp(Color value1, Color value2, Single amount)
        {
			return new Color((byte)MathHelper.Lerp(value1.R, value2.R, amount), (byte)MathHelper.Lerp(value1.G, value2.G, amount), (byte)MathHelper.Lerp(value1.B, value2.B, amount), (byte)MathHelper.Lerp(value1.A, value2.A, amount)); 
        }


        public static Vector3 ToVector3(this Color color)
        {
            Vector3 vector = new Vector3();
            vector.X = color.R;
            vector.Y = color.G;
            vector.Z = color.B;
            return vector;
        }

        public static Vector4 ToVector4(this Color color)
        {
            return new Vector4(color.R, color.G, color.B, color.A);
        }

    }
}
