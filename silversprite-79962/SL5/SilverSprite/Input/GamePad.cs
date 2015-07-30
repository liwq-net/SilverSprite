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
    public class GamePad
    {
        static GamePad()
        {
        }

        public static bool IsEnabled
        {
            get;
            set;
        }

        public static GamePadState GetState(PlayerIndex index)
        {
            GamePadState state = new GamePadState();
            state.IsConnected = IsEnabled;
            if (state.IsConnected)
            {
                state.SetCurrentState(Keyboard.GetState());
            }
            return state;
        }

        public static void SetVibration(PlayerIndex index, float x, float y)
        {
        }
    }
}
