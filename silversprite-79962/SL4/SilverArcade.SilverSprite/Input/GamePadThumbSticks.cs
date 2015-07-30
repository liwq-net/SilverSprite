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
    

    public struct GamePadThumbSticks
    {
        KeyboardState _keyBoardState;

        public GamePadThumbSticks(KeyboardState keyBoardState)
        {
            _keyBoardState = keyBoardState;
        }

        public Vector2 Left
        {
            get
            {
                //TODO: Not sure if there is any type of implementation we can do here.
                return Vector2.Zero;
            }
        }

        public Vector2 Right
        {
            get
            {
                //TODO: Not sure if there is any type of implementation we can do here.
                return Vector2.Zero;
            }
        }
    }
}
