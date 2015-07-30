using System;
using System.Windows;
using System.Windows.Controls;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SWM = System.Windows.Media;
using SilverArcade.SilverSprite.Effects;
using System.Windows.Media.Effects;

namespace SilverArcade.SilverSprite.Graphics
{
    public class Sprite : IDisposable
    {
        float positionX;
        float positionY;
        int zIndex;
        SWM.ScaleTransform scaleTransform = null;
        SWM.ScaleTransform effectsTransform = null;
        SWM.TranslateTransform translateTransform = null;
        Vector2 scale = new Vector2(1, 1);
        Vector2 effectsScale = new Vector2(1, 1);
        SWM.RotateTransform rotateTransform = null;
        float rotation = 0;
        Vector2 origin;
        SpriteEffects effects = SpriteEffects.None;
        SWM.BitmapCache bitmapCache;
        double _renderAtScale = 1;
        internal Color color;
        protected TintEffect tintEffect;
        protected ShaderEffect mCustomEffect;
        Canvas root;
        FrameworkElement child;
        internal byte opacity;
        Color opaqueColor;

        public Sprite()
        {
            root = new Canvas();
            Element = root;
        }

        public bool BitmapCacheEnabled
        {
            set
            {
                if (value == true)
                {
                    if (bitmapCache == null)
                    {
                        bitmapCache = new SWM.BitmapCache();
                        bitmapCache.RenderAtScale = _renderAtScale;
                        Element.CacheMode = bitmapCache;
                    }
                }
                else if (value == false)
                {
                    bitmapCache = null;
                    Element.CacheMode = null;
                }
            }
            get
            {
                return bitmapCache == null;
            }
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
                    if (mCustomEffect == null)
                    {
                        SetTintEffectAndColor(color);
                    }
                }
            }
        }

        public ShaderEffect CustomEffect
        {
            get { return mCustomEffect; }
            set
            {
                if (mCustomEffect != value)
                {
                    mCustomEffect = value;

                    if (value == null)
                    {
                        // If we're switching back from a custom effect, refresh the tintEffect
                        SetTintEffectAndColor(color);
                    }
                    else
                    {
                        Element.Effect = mCustomEffect;
                    }
                }
            }
        }

        public double RenderAtScale
        {
            get
            {
                if (bitmapCache != null)
                {
                    return bitmapCache.RenderAtScale;
                }
                else
                {
                    return 1;
                }
            }
            set
            {
                _renderAtScale = value;
                if (bitmapCache != null)
                {
                    bitmapCache.RenderAtScale = value;
                }
            }
        }

        public SWM.ScaleTransform ScaleTransform
        {
            get
            {
                return scaleTransform;
            }
            set
            {
                scaleTransform = value;
            }
        }

        public Vector2 Origin
        {
            get
            {
                return origin;
            }
            set
            {
                if (rotateTransform == null)
                {
                    if (value == Vector2.Zero) return;
                    SetTransforms();
                }
                if (value != origin)
                {
                    origin = value;
                    translateTransform.X = -origin.X;
                    translateTransform.Y = -origin.Y;
                }
            }
        }

        void SetTransforms()
        {
            SWM.TransformGroup tg = new SWM.TransformGroup();
            translateTransform = new SWM.TranslateTransform();
            rotateTransform = new SWM.RotateTransform();
            effectsTransform = new SWM.ScaleTransform();
            effectsTransform.ScaleX = 1;
            effectsTransform.ScaleY = 1;
            scaleTransform = new SWM.ScaleTransform();
            tg.Children.Add(translateTransform);
            tg.Children.Add(effectsTransform);
            tg.Children.Add(scaleTransform);
            tg.Children.Add(rotateTransform);
            Element.RenderTransform = tg;
        }

        public float Rotation
        {
            get
            {
                return rotation;
            }
            set
            {
                if (float.IsNaN(value)) return;
                if (rotateTransform == null)
                {
                    if (value == 0) return;
                    SetTransforms();
                }
                if (value != rotation)
                {
                    rotation = value;
                    rotateTransform.Angle = (180 / Math.PI) * rotation;
                }
            }
        }

        public Vector2 Scale
        {
            get
            {
                return scale;
            }
            set
            {
                if (scaleTransform == null)
                {
                    if (value.X == 1 && value.Y == 1) return;
                    SetTransforms();
                }
                if (value != scale)
                {
                    scale = value;
                    scaleTransform.ScaleX = value.X;
                    scaleTransform.ScaleY = value.Y;
                }
            }
        }

        public int ZIndex
        {
            get
            {
                return zIndex;
            }
            set
            {
                if (zIndex != value)
                {
                    Element.SetValue(Canvas.ZIndexProperty, value);
                    zIndex = value;
                }
            }
        }

        public bool InUse
        {
            get;
            set;
        }

        public bool Active
        {
            get;
            set;
        }

        public FrameworkElement ChildElement
        {
            get
            {
                return child;
            }
            set
            {
                child = value;
                root.Children.Clear();
                root.Children.Add(child);
            }
        }

        public FrameworkElement Element
        {
            get;
            set;
        }

        public float PositionX
        {
            set
            {
                if (positionX != value)
                {
                    positionX = value;
                    Canvas.SetLeft(Element, value);
                    //                    Element.SetValue(Canvas.LeftProperty, (double)value.X);
                }
            }
            get
            {
                return positionX;
            }
        }

        public float PositionY
        {
            set
            {
                if (positionY != value)
                {
                    positionY = value;
                    Canvas.SetTop(Element, value);
                    //                    Element.SetValue(Canvas.TopProperty, (double)value.Y);
                }
            }
            get
            {
                return positionY;
            }
        }

        public void SetOriginAndEffects(Vector2 origin, SpriteEffects spriteEffects)
        {
            if ((spriteEffects & SpriteEffects.FlipHorizontally) == SpriteEffects.FlipHorizontally)
            {
                origin.X = -origin.X;
            }
            if ((spriteEffects & SpriteEffects.FlipVertically) == SpriteEffects.FlipVertically)
            {
                origin.Y = -origin.Y;
            }
            Origin = origin;
            Effects = spriteEffects;
        }

        public SpriteEffects Effects
        {
            set
            {
                if (value == SpriteEffects.None)
                {
                    if (effectsTransform != null)
                    {
                        if (effectsTransform.ScaleX != 1)
                        {
                            effectsTransform.ScaleX = 1;
                            effectsScale.X = 1;
                        }
                        if (effectsTransform.ScaleY != 1)
                        {
                            effectsTransform.ScaleY = 1;
                            effectsScale.Y = 1;
                        }
                    }
                }
                else
                {
                    if (effectsTransform == null)
                    {
                        SetTransforms();
                    }
                    if ((value & SpriteEffects.FlipVertically) == SpriteEffects.FlipVertically)
                    {
                        if (effectsScale.Y != -1)
                        {
                            effectsTransform.ScaleY = -1;
                            effectsScale.Y = -1;
                        }
                    }
                    else
                    {
                        if (effectsScale.Y != 1)
                        {
                            effectsTransform.ScaleY = 1;
                            effectsScale.Y = 1;
                        }
                    }
                    if ((value & SpriteEffects.FlipHorizontally) == SpriteEffects.FlipHorizontally)
                    {
                        if (effectsScale.X != -1)
                        {
                            effectsTransform.ScaleX = -1;
                            effectsScale.X = -1;
                        }
                    }
                    else
                    {
                        if (effectsScale.X != 1)
                        {
                            effectsTransform.ScaleX = 1;
                            effectsScale.X = 1;
                        }
                    }


                    //Todo: This code below isn't always good. In my porting of the Xna Platformer starter kit
                    //I needed to uncomment the lines below, to avoid my main char "teleport" when turning left and right.
                    //See my blog post and see the source provided for the porting of this starter kit:
                    //http://laumania.net/post/Porting-XNA-starter-kit-Platformere2809d-to-Silverlight-(SilverSprite).aspx
                    //By Qbus/Laumania.net
                    if (effectsTransform.CenterX != Element.ActualWidth / 2)
                    {
                        effectsTransform.CenterX = Element.ActualWidth / 2;
                    }
                    if (effectsTransform.CenterY != Element.ActualHeight / 2)
                    {
                        effectsTransform.CenterY = Element.ActualHeight / 2;
                    }
                }
            }
        }

        protected void SetTintEffectAndColor(Color newColor)
        {
            byte newOpacity = color.A;
            if (newOpacity != opacity)
            {
                opacity = newOpacity;
                root.Opacity = color.A / 255.0f;
                root.Opacity = color.A / 255.0f;
            }
            newColor.A = 255;
            if (newColor != opaqueColor)
            {
                opaqueColor = newColor;
                if (color.R == 255 && color.G == 255 && color.B == 255)
                {
                    Element.Effect = null;
                    if (tintEffect != null)
                    {
                        tintEffect.Release();
                    }
                    tintEffect = null;
                }
                else
                {
                    if (tintEffect == null)
                    {
                        tintEffect = TintEffect.Create();
                        Element.Effect = tintEffect;
                    }
                    tintEffect.Color = System.Windows.Media.Color.FromArgb(255, color.R, color.G, color.B);
                }
            }
        }

        #region IDisposable Members

        public virtual void Dispose()
        {
            if (tintEffect != null) tintEffect.Release();
        }

        #endregion
    }
}
