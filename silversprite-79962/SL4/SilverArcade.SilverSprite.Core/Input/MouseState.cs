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
    public class MouseState
    {
        int x;
        int y;
        ButtonState left;
        ButtonState right;


        // Vic says:  I decided to make the setters public.
        // Why?  The GC sucks in Silverlight and I think that
        // the every-frame new for MouseState is hurting us.
        // This allows for modifying these objects outside of the libs
        // to help make avoiding new allocations.

        public int X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }

        public int Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }

        public ButtonState LeftButton
        {
            get
            {
                return left;
            }
            set
            {
                left = value;
            }
        }

        public ButtonState RightButton
        {
            get
            {
                return right;
            }
            set
            {
                right = value;
            }
        }
    
    }
}
