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

namespace SilverSprite
{
    public class SimpleEventArgs<T> : EventArgs
    {
        public T Result { get; set; }

        public SimpleEventArgs(T result)
        {
            Result = result;
        }
    }
}
