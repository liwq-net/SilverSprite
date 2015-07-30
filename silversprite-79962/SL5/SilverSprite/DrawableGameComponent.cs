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

namespace Microsoft.Xna.Framework
{
    public class DrawableGameComponent : GameComponent, IDrawable
    {
        private bool _isVisible;
        private int _drawOrder;
		bool visibleSet = false;
        public event EventHandler DrawOrderChanged;        
        public event EventHandler VisibleChanged;
		bool oldVisible = false;

        public DrawableGameComponent(Game game)
            : base(game)
        {
			Visible = true;
        }

		public override void Initialize()
		{
			base.Initialize();
			if (visibleSet == false)
			{
				Visible = true;
			} 
		}

        #region IDrawable Members


        public int DrawOrder
        {
            get{return _drawOrder;}
            set
            {
                _drawOrder = value;
                if(DrawOrderChanged != null)
                    DrawOrderChanged(this, null);

                OnDrawOrderChanged(this, null);
            }
        }

		internal override void BeforeUpdate()
		{
			base.BeforeUpdate();
			if (Visible != oldVisible)
			{
				if (VisibleChanged != null)
					VisibleChanged(this, null);

				OnVisibleChanged(this, null);
			}
			oldVisible = Visible;
		}

        public bool Visible
        {
            get{return _isVisible;}
            set
            {
                _isVisible = value;              
            }
             
        }

        public virtual void Draw(GameTime gameTime)
        {
        }

        protected virtual void OnVisibleChanged(object sender, EventArgs args)
        {
        }

        protected virtual void OnDrawOrderChanged(object sender, EventArgs args)
        {
        }
        #endregion

        protected override void Dispose(bool disposing)
        {
        }
    }
}
