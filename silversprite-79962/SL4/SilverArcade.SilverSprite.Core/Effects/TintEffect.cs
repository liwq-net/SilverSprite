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
using System.Windows.Media.Effects;
using System.Windows.Resources;
using System.IO;
using System.Collections.Generic;

namespace SilverArcade.SilverSprite.Effects
{
    public class TintEffect : ShaderEffect
    {
		static Stack<TintEffect> effectPool = new Stack<TintEffect>();
        public static DependencyProperty ColorProperty = DependencyProperty.Register("Color", typeof(System.Windows.Media.Color), typeof(TintEffect), new PropertyMetadata(new System.Windows.Media.Color(), PixelShaderConstantCallback(2)));

		public static TintEffect Create()
		{
			if (effectPool.Count > 0)
			{
				return effectPool.Pop();
			}
			else
			{
				return new TintEffect();
			}
		}

		public void Release()
		{
			effectPool.Push(this);
		}

        public TintEffect()
        {
            Uri u = new Uri(@"/SilverArcade.SilverSprite.Core;component/Effects/ssdrawcolor.ps", UriKind.Relative);
            PixelShader = new PixelShader() { UriSource = u };
        }

        public virtual System.Windows.Media.Color Color
        {
            get
            {
                return ((System.Windows.Media.Color)(GetValue(ColorProperty)));
            }
            set
            {
                SetValue(ColorProperty, value);
            }
        }

    }
}
