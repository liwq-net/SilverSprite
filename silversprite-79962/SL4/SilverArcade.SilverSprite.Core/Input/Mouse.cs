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

namespace Microsoft.Xna.Framework.Input
{
    public class Mouse
    {
        public static bool CreatesNewState = true;

        public static int X;
        public static int Y;
        public static bool LeftButtonDown;
        public static bool RightButtonDown = false;

        // Since there's no way to detect whether the mouse is on or off the
        // game window at a given time, this state is needed so that the GraphicsDevice
        // events can toggle it.
        public static bool IsOnGameWindow = true;

        static MouseState state = new MouseState();

        public static void Update()
        {
            if (CreatesNewState)
            {
                state = new MouseState();
            }
            state.X = X;
            state.Y = Y;
            if (LeftButtonDown)
            {
                state.LeftButton = ButtonState.Pressed;
            }
            else
            {
                state.LeftButton = ButtonState.Released;
            }
            state.RightButton = ButtonState.Released;
        }

        public static MouseState GetState()
        {
            return state;
        }
    }
}
