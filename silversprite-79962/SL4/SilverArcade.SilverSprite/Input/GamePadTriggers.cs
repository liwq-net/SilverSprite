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
    public struct GamePadTriggers
    {
        KeyboardState _keyBoardState;

        public GamePadTriggers(KeyboardState keyBoardState)
        {
            _keyBoardState = keyBoardState;
        }


        public float Left
        {
            get
            {
                return GamePadState.GetButtonState(_keyBoardState, Buttons.LeftTrigger) == ButtonState.Pressed ? 1.0f : 0.0f;
            }
        }
        public float Right
        {
            get
            {
                return GamePadState.GetButtonState(_keyBoardState, Buttons.RightTrigger) == ButtonState.Pressed ? 1.0f : 0.0f;
            }
        }
    }
}
