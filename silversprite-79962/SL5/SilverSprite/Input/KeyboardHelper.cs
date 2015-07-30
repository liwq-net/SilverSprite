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
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace Microsoft.Xna.Framework.Input
{
    public static class KeyboardHelper
    {
        public static KeyboardState GetState(PlayerIndex index)
        {
            return Keyboard.GetState();
        }
    }
}
