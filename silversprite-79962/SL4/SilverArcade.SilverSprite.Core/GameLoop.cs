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

using Input = Microsoft.Xna.Framework.Input;

namespace SilverArcade.SilverSprite
{
	public class GameLoop : IDisposable
	{
		DateTime lastUpdate;
		TimeSpan _targetElapsedTime;

		TimeSpan _timeSinceLast = TimeSpan.Zero;
		EventHandler rendering;
		public event EventHandler<SimpleEventArgs<TimeSpan>> Update;
		public event EventHandler<SimpleEventArgs<TimeSpan>> Draw;

		public TimeSpan TargetElapsedTime
		{
			get
			{
				return _targetElapsedTime;
			}
			set
			{
				_targetElapsedTime = value;
			}
		}

		public bool IsFixedTimeStep
		{
			get;
			set;
		}

		public GameLoop()
		{
			lastUpdate = DateTime.Now;
			_targetElapsedTime = TimeSpan.FromTicks(0x28b0bL);
			rendering = new EventHandler(CompositionTarget_Rendering);
			CompositionTarget.Rendering += rendering;
		}

		void CompositionTarget_Rendering(object sender, EventArgs e)
		{
#if !WP7
			Input.Keyboard.Update();
			Input.Mouse.Update();
#endif
            DateTime now = DateTime.Now;
			if (IsFixedTimeStep == false)
			{
				_timeSinceLast = (now - lastUpdate);
			}
			else
			{
				_timeSinceLast += (now - lastUpdate);
			}

			if (Update != null)
			{
				if (IsFixedTimeStep)
				{
					while (_timeSinceLast >= _targetElapsedTime)
					{
						Update(this, new SimpleEventArgs<TimeSpan>(_targetElapsedTime));
						_timeSinceLast -= _targetElapsedTime;
					}
				}
				else
				{
					Update(this, new SimpleEventArgs<TimeSpan>(_timeSinceLast));
				}
			}
			if (Draw != null)
			{
				Draw(this, new SimpleEventArgs<TimeSpan>((now - lastUpdate)));
			}
			lastUpdate = now;
		}

		#region IDisposable Members

		public void Dispose()
		{
			CompositionTarget.Rendering -= rendering;
		}

		#endregion
	}
}
