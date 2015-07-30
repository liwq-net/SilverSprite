using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

//using Microsoft.Xna.Framework.Storage;
using System.IO;

namespace Microsoft.Xna.Framework
{
    static class ExtensionMethods
    {
        public static void DrawString(SpriteBatch spriteBatch, float borderSize, Color borderColor, SpriteFont spriteFont, string text, Vector2 position, Color color, float rotation, Vector2 origin, float scale, SpriteEffects effects, float layerDepth)
        {
            for (int loop = 0; loop < 8; loop++)
            {
                float[] offsets = { -1, -1, 1, 1, -1, 1, 1, -1, -1.2f, 0, 1.2f, 0, 0, -1.2f, 0, 1.2f };
                float xoffset = offsets[loop * 2] * borderSize;
                float yoffset = offsets[loop * 2 + 1] * borderSize;
                spriteBatch.DrawString(spriteFont, text, position + new Vector2(xoffset, yoffset), borderColor, rotation, origin, scale, effects, layerDepth);
            }
            spriteBatch.DrawString(spriteFont, text, position, color, rotation, origin, scale, effects, layerDepth);

        }

        public static FileStream SafeGetFileStream(string filename)
        {
            FileStream file;
            if (File.Exists(filename))
            {
                file = File.OpenRead(filename);
            }
            else if (File.Exists(filename + ".tmp"))
            {
                File.Move(filename + ".tmp", filename);
                file = File.OpenRead(filename);
            }
            else
            {
                return null;
            }
            return file;
        }
    }
}
