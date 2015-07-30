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
    public struct GamePadDPad
    {        
        KeyboardState _keyBoardState;

        public GamePadDPad(KeyboardState keyBoardState)
        {
            _keyBoardState = keyBoardState;
        }

        public ButtonState Up
        {
            get
            {
                return GamePadState.GetButtonState(_keyBoardState, Buttons.DPadUp);
            }
        }
        public ButtonState Down
        {
            get
            {
                return GamePadState.GetButtonState(_keyBoardState, Buttons.DPadDown);
            }
        }
        public ButtonState Left
        {
            get
            {
                return GamePadState.GetButtonState(_keyBoardState, Buttons.DPadLeft);
            }
        }
        public ButtonState Right
        {
            get
            {
                return GamePadState.GetButtonState(_keyBoardState, Buttons.DPadRight);
            }
        }
    }
}
