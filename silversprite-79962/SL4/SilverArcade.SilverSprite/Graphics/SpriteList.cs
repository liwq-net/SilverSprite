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

namespace SilverArcade.SilverSprite.Graphics
{
    internal class SpriteList : List<Sprite>
    {
        SpriteBatchCanvas _spriteBatchCanvas;
        public Texture2D Texture2D;
        public SpriteFont SpriteFont;
        public BitmapSpriteFont BitmapSpriteFont;
        public Canvas ParentCanvas;
        double _renderAtScale = 1;
        bool _bitmapCacheEnabled = false;
        public bool BitmapCacheEnabled
        {
            set
            {
                _bitmapCacheEnabled = value;

                int count = Count;

                for(int i = 0; i < count; i++)
                {
                    Sprite s = this[i];
                    s.BitmapCacheEnabled = value;
                }
            }
        }

        public double RenderAtScale
        {
            set
            {
                _renderAtScale = value;
                int count = Count;

                for (int i = 0; i < count; i++)
                {
                    Sprite s = this[i];
                    s.RenderAtScale = value;
                }
            }
        }

        public SpriteType Type
        {
            get;
            set;
        }

        public enum SpriteType
        {
            SpriteImage,
            SpriteText,
            ClippedSpriteImage,
            BitmapSpriteText
        }

        public SpriteList(SpriteBatchCanvas spriteBatchCanvas, SpriteType type)
            : base()
        {
            _spriteBatchCanvas = spriteBatchCanvas;
            BitmapCacheEnabled = spriteBatchCanvas.BitmapCacheEnabled;
            RenderAtScale = spriteBatchCanvas.RenderAtScale;
            Type = type;
        }

        int current;
        public void BeginSpriteBatch()
        {
            int count = Count;

            for (int i = 0; i < count; i++)
            {
                Sprite d = this[i];
                d.InUse = false;
            }
            current = 0;
        }

        Sprite CreateSprite()
        {
            if (Type == SpriteType.BitmapSpriteText)
            {
                BitmapSpriteText s = new BitmapSpriteText();
                s.Font = BitmapSpriteFont;
                s.RenderAtScale = _renderAtScale;
                s.BitmapCacheEnabled = _bitmapCacheEnabled;
                return (Sprite)s;
            }
            else if (Type == SpriteType.SpriteText)
            {
                SpriteText s = new SpriteText();
                s.Font = SpriteFont;
                s.RenderAtScale = _renderAtScale;
                s.BitmapCacheEnabled = _bitmapCacheEnabled;
                return s;
            }
            else if (Type == SpriteType.ClippedSpriteImage)
            {
                ClippedSpriteImage s = new ClippedSpriteImage();
                s.Texture2D = Texture2D;
                s.RenderAtScale = _renderAtScale;
                s.BitmapCacheEnabled = _bitmapCacheEnabled;
                return (Sprite)s;
            }
            return null;
        }

        public Sprite GetSprite()
        {
            if (current < Count - 1)
            {
                Sprite d = this[current];
                current++;
                return d;
            }
            else
            {
                Sprite d = CreateSprite();
                this.Add(d);
                return d;
            }          
        }

        void CleanUp()
        {
            int removedCount = 0;
            for (int i = this.Count - 1; i >= 0; i--)
            {
                Sprite d = this[i];
                if (d.Active == false)
                {
                    this.RemoveAt(i);
                    IDisposable disp = d as IDisposable;
                    if (disp != null) disp.Dispose();
                    removedCount++;
                    if (removedCount > this.Count / 4)
                    {
                        return;
                    }
                }
            }
        }

        public void EndSpriteBatch()
        {
            int activeCount = 0;
            int count = Count;

            for (int i = 0; i < count; i++)
            {
                Sprite d = this[i];

                if (d.InUse == false && d.Active == true)
                {
                    d.Active = false;
                    ParentCanvas.Children.Remove(d.Element);
                }
                else if (d.InUse == true && d.Active == false)
                {
                    d.Active = true;
                    ParentCanvas.Children.Add(d.Element);
                }
                if (d.Active == true) activeCount++;
            }
            if (activeCount * 2 < this.Count)
            {
                // Vic says:  Bill Reiss said to try
                // commenting this line out to eliminate
                // some flickering that would occur when rapidly
                // changing the displayed Texture of Sprites.
                //CleanUp();
            }
        }
    }
}
