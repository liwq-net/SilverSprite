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
    public class GameTime
    {
        TimeSpan elapsedTime;
        TimeSpan totalTime;

        public TimeSpan ElapsedGameTime 
        {
            get
            {
                return elapsedTime;
            }
        }
        public TimeSpan ElapsedRealTime
        {
            get
            {
                return elapsedTime;
            }
        }

        public TimeSpan TotalGameTime
        {
            get
            {
                return totalTime;
            }
        }
        public TimeSpan TotalRealTime
        {
            get
            {
                return totalTime;
            }
        }

        public GameTime()
        {
            elapsedTime = totalTime = TimeSpan.Zero;
        }

        public void Update(TimeSpan elapsed)
        {
            elapsedTime = elapsed;
            totalTime += elapsed;
        }
    }
}
