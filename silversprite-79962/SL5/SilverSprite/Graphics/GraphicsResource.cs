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

namespace Microsoft.Xna.Framework.Graphics
{
	public class GraphicsResource : IDisposable
	{
		public virtual GraphicsDevice GraphicsDevice { get; internal set; }
		protected bool _isDisposed = false;
		public void Dispose()
		{
			if (Disposing != null)
				Disposing(this, null);
			Dispose(false);
		}

		protected virtual void Dispose(bool disposing)
		{
		}

		public event EventHandler Disposing;
	}
}
