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
using ShaderEffect = System.Windows.Media.Effects.ShaderEffect;
#if USE_FARSEER
using FarseerGames.FarseerPhysics.Mathematics;
#endif

namespace SilverArcade.SilverSprite.Graphics
{
    public class Sprite
    {
        Vector2 position;
        int zIndex;
        ScaleTransform scaleTransform = null;
        ScaleTransform effectsTransform = null;
        TranslateTransform translateTransform = null;
        Vector2 scale = new Vector2(1, 1);
        RotateTransform rotateTransform = null;
        float rotation = 0;
        Vector2 origin;
        SpriteEffects effects = SpriteEffects.None;
        BitmapCache bitmapCache;
        double _renderAtScale = 1;

        public bool BitmapCacheEnabled
        {
            set
            {
                if (value == true)
                {
                    if (bitmapCache == null)
                    {
                        bitmapCache = new BitmapCache();
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

        public ScaleTransform ScaleTransform
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
            TransformGroup tg = new TransformGroup();
            translateTransform = new TranslateTransform();
            rotateTransform = new RotateTransform();
            effectsTransform = new ScaleTransform();
            effectsTransform.ScaleX = 1;
            effectsTransform.ScaleY = 1;
            scaleTransform = new ScaleTransform();
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

        public FrameworkElement Element
        {
            get;
            set;
        }

        public Vector2 Position
        {
            set
            {
                if (position.X != value.X)
                {
                    position.X = value.X;
                    Element.SetValue(Canvas.LeftProperty, (double)value.X);
                }
                if (position.Y != value.Y)
                {
                    position.Y = value.Y;
                    Element.SetValue(Canvas.TopProperty, (double)value.Y);
                }
            }
            get
            {
                return position;
            }
        }

        public SpriteEffects Effects
        {
            set
            {
                if (value == SpriteEffects.None)
                {
                    if (effectsTransform != null)
                    {
                        if (effectsTransform.ScaleX != 1) effectsTransform.ScaleX = 1;
                        if (effectsTransform.ScaleY != 1) effectsTransform.ScaleY = 1;
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
                        if (effectsTransform.ScaleY != -1) effectsTransform.ScaleY = -1;
                    }
                    else
                    {
                        if (effectsTransform.ScaleY != 1) effectsTransform.ScaleY = 1;
                    }
                    if ((value & SpriteEffects.FlipHorizontally) == SpriteEffects.FlipHorizontally)
                    {
                        if (effectsTransform.ScaleX != -1) effectsTransform.ScaleX = -1;
                    }
                    else
                    {
                        if (effectsTransform.ScaleX != 1) effectsTransform.ScaleX = 1;
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

    }
}
