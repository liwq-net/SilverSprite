using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Media.Effects;
using System.Linq;
using System.Windows.Media.Imaging;
using System.Collections.Generic;

using Local = Microsoft.Xna.Framework;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SilverArcade.SilverSprite.Graphics
{
    public abstract class SilverlightRenderBase 
    {
        double _renderAtScale = 1;
        bool _bitmapCacheEnabled = false;
        Matrix transMatrix = Matrix.Identity;
        System.Windows.Media.MatrixTransform transform = new System.Windows.Media.MatrixTransform();
        FrameworkElement _root;
        bool visible = true;
        internal DrawCommandQueue _commands = new DrawCommandQueue();
        protected SpriteSortMode sortMode;
        protected SpriteBlendMode blendMode;
		protected Texture2D texture;
		WriteableBitmap bmp;

        internal DrawCommand GetAvailableCommand()
        {
            return _commands.GetNextAvailable();
        }

        public void ResetCommands()
        {
            _commands.Reset();
        }

        public SilverlightRenderBase()
        {
        }

        public bool InUse
        {
            get;
            set;
        }

        public virtual bool BitmapCacheEnabled
        {
            set
            {
                _bitmapCacheEnabled = value;
            }
            get
            {
                return _bitmapCacheEnabled;
            }
        }

        public virtual double RenderAtScale
        {
            set
            {
                _renderAtScale = value;
            }
            get
            {
                return _renderAtScale;
            }
        }

        public FrameworkElement Root
        {
            get
            {
                return _root;
            }
            set
            {
                _root = value;
                transform.Matrix = System.Windows.Media.Matrix.Identity;
                _root.RenderTransform = transform;
            }
        }


        bool MatricesAreEqual(Matrix m1, Matrix m2)
        {
            if (m1.M11 != m2.M11) return false;
            if (m1.M12 != m2.M12) return false;
            if (m1.M13 != m2.M13) return false;
            if (m1.M14 != m2.M14) return false;
            if (m1.M21 != m2.M21) return false;
            if (m1.M22 != m2.M22) return false;
            if (m1.M23 != m2.M23) return false;
            if (m1.M24 != m2.M24) return false;
            if (m1.M31 != m2.M31) return false;
            if (m1.M32 != m2.M32) return false;
            if (m1.M33 != m2.M33) return false;
            if (m1.M34 != m2.M34) return false;
            if (m1.M41 != m2.M41) return false;
            if (m1.M42 != m2.M42) return false;
            if (m1.M43 != m2.M43) return false;
            if (m1.M44 != m2.M44) return false;
            return true;
        }

        public Matrix TransformMatrix
        {
            get
            {
                return transMatrix;
            }
            set
            {
                if (MatricesAreEqual(transMatrix, value) == false)
                {
                    System.Windows.Media.Matrix t = new System.Windows.Media.Matrix(value.M11, value.M12, value.M21, value.M22, value.M41, value.M42);
                    transform.Matrix = t;
                    transMatrix = value;
                }
            }
        }

        protected virtual void Draw(Texture2D texture, Vector2 position, ref DoubleRectangle sourceRectangle, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth)
        {
        }

        protected virtual void Draw(Texture2D texture, Vector2 position, ref DoubleRectangle sourceRectangle, ShaderEffect shaderEffect, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth)
        {
        }

        public virtual void DrawString(SpriteFont spriteFont, string text, Vector2 position, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth)
        {
		}

        public bool Visible
        {
            set
            {
                if (value != visible)
                {
                    visible = value;
                    if (visible == false)
                    {
                        _root.Visibility = Visibility.Collapsed;
                    }
                    else
                    {
                        _root.Visibility = Visibility.Visible;
                    }
                }
            }
            get
            {
                return visible;
            }
        }

        internal virtual void Draw(DrawCommand cmd)
        {
                switch (cmd.CommandType)
                {
                    case DrawCommand.DrawCommandType.String:
                        DrawString(cmd.Font, cmd.Text, cmd.Position, cmd.Color, cmd.Rotation, cmd.Origin, cmd.Scale, cmd.Effects, cmd.LayerDepth);
                        break;
                    case DrawCommand.DrawCommandType.Texture:
                        if (float.IsInfinity(cmd.Scale.X)) cmd.Scale.X = 0;
                        if (float.IsInfinity(cmd.Scale.Y)) cmd.Scale.Y = 0;
                        if (cmd.ShaderEffect != null)
                        {
                            Draw(cmd.Texture, cmd.Position, ref cmd.SourceRectangle, cmd.ShaderEffect, cmd.Rotation, cmd.Origin, cmd.Scale, cmd.Effects, cmd.LayerDepth);
                        }
                        else
                        {
                            Draw(cmd.Texture, cmd.Position, ref cmd.SourceRectangle, cmd.Color, cmd.Rotation, cmd.Origin, cmd.Scale, cmd.Effects, cmd.LayerDepth);
                        }
                        break;
                }
        }

		internal virtual void DrawAll(IEnumerable<DrawCommand> cmds)
		{
            foreach (DrawCommand cmd in cmds)
			{
				Draw(cmd);
			}
		}

        public virtual void End()
        {
            // if SpriteSortMode isn't immediate, do some Linq here to get the reight sorting.
            if (sortMode == SpriteSortMode.Immediate || sortMode == SpriteSortMode.Deferred || sortMode == SpriteSortMode.Texture)
            {
				DrawAll(_commands.Take<DrawCommand>(_commands.CommandCount));
            }
            else if (sortMode == SpriteSortMode.FrontToBack)
            {
                var query = from command in _commands.AsQueryable<DrawCommand>().Take<DrawCommand>(_commands.CommandCount)
                            orderby command.LayerDepth
                            select command;
				DrawAll(query);
            }
            else if (sortMode == SpriteSortMode.BackToFront)
            {
                var query = from command in _commands.AsQueryable<DrawCommand>().Take<DrawCommand>(_commands.CommandCount)
                            orderby command.LayerDepth descending
                            select command;
				DrawAll(query);
            }
        }

        public virtual void Begin(GraphicsDevice device, SpriteBlendMode blendMode, SpriteSortMode sortMode, SaveStateMode stateMode, Local.Matrix transformMatrix)
        {
            this.sortMode = sortMode;
            this.blendMode = blendMode;
            ResetCommands();
        }

        public virtual Texture2D GetTexture(GraphicsDevice device)
        {
			if (texture == null)
			{
				texture = new Texture2D(device, (int)Root.Width, (int)Root.Height);
			}
			else if (texture.Width != (int)Root.Width || texture.Height != (int)Root.Height)
			{
				texture = new Texture2D(device, (int)Root.Width, (int)Root.Height);
			}
			texture.ImageSource.Render(Root, null);
			texture.ImageSource.Invalidate();
			texture.IsDirty = true;
			return texture;
        }

        public virtual void Clear(Color color)
        {

        }

        public virtual void BeforeDraw()
        {
        }

        public virtual void AfterDraw()
        {
        }
    }
}
