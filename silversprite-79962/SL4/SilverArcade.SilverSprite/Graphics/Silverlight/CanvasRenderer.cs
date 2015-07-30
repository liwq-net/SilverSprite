using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.Generic;
using System.Windows.Media;

using Microsoft.Xna.Framework.Graphics;
using G = Microsoft.Xna.Framework.Graphics;

using Local = Microsoft.Xna.Framework;
using System.Windows.Media.Imaging;

namespace SilverArcade.SilverSprite.Graphics
{
    public class CanvasRenderer : SilverlightRenderBase
    {
        List<ChildCanvasRenderer> renderers = new List<ChildCanvasRenderer>();
        int canvasIndex = 0;
        int canvasZIndex = 0;

        // made public for FRB
        public Canvas Canvas;
        SpriteSortMode currentSortMode;
        ChildCanvasRenderer _childRenderer;
        G.Color backgroundColor;

        public override bool BitmapCacheEnabled
        {
            get
            {
                return base.BitmapCacheEnabled;
            }
            set
            {
                base.BitmapCacheEnabled = value;
                foreach (ChildCanvasRenderer renderer in renderers)
                {
                    renderer.BitmapCacheEnabled = value;
                }
            }
        }

        public override double RenderAtScale
        {
            get
            {
                return base.RenderAtScale;
            }
            set
            {
                base.RenderAtScale = value;
                foreach (ChildCanvasRenderer renderer in renderers)
                {
                    renderer.RenderAtScale = value;
                }
            }
        }

        public override void Begin(GraphicsDevice device, SpriteBlendMode blendMode, SpriteSortMode sortMode, SaveStateMode stateMode, Local.Matrix transformMatrix)
        {
            _childRenderer = GetCurrentRenderer();
            _childRenderer.Begin(device, blendMode, sortMode, stateMode, transformMatrix);
            currentSortMode = sortMode;
            base.Begin(device, blendMode, sortMode, stateMode, transformMatrix);
        }

        public void DisposeTextureAssets(Texture2D texture)
        {
            foreach (ChildCanvasRenderer renderer in renderers)
            {
                renderer.DisposeTextureAssets(texture);
            }
        }

        public CanvasRenderer()
        {
            Canvas = new Canvas();
            Root = Canvas;
        }

        public CanvasRenderer(int width, int height)
        {
            Canvas = new Canvas();
            Canvas.Width = width;
            Canvas.Height = height;
            Root = Canvas;
        }

        ChildCanvasRenderer GetCurrentRenderer()
        {
            ChildCanvasRenderer renderer;
            if (canvasIndex >= renderers.Count)
            {
                renderer = new ChildCanvasRenderer();
                renderer.BitmapCacheEnabled = BitmapCacheEnabled;
                renderer.RenderAtScale = RenderAtScale;
                renderers.Add(renderer);
                renderer.Visible = false;
                Canvas.Children.Add(renderer.Canvas);
                canvasIndex++;
            }
            else
            {
                renderer = renderers[canvasIndex];
                canvasIndex++;
            }
            renderer.InUse = true;
            renderer.Canvas.SetValue(Canvas.ZIndexProperty, canvasZIndex);
            canvasZIndex++;
            return renderer;
        }

        internal override void Draw(DrawCommand cmd)
        {
            _childRenderer.Draw(cmd);
        }

        public override void Clear(G.Color color)
        {
            if (color != backgroundColor)
            {
                Canvas.Background = new SolidColorBrush(color.ToSilverlightColor());
                backgroundColor = color;
            }
        }

        public override void End()
        {
            base.End();
            _childRenderer.End();
        }

        public override void BeforeDraw()
        {
            canvasIndex = 0;
            for (int i = 0; i < renderers.Count; i++)
            {
                renderers[i].InUse = false;
            }
        }

        public override void AfterDraw()
        {
            for (int i = 0; i < renderers.Count; i++)
            {
                ChildCanvasRenderer r = renderers[i];
                if (r.Visible && r.InUse == false)
                {
                    r.Visible = false;
                }
                else if (r.Visible == false && r.InUse == true)
                {
                    r.Visible = true;
                }
            }
        }
    }
}
