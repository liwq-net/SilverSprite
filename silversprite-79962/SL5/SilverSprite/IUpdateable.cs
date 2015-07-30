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
    public interface IUpdateable
    {
        bool Enabled { get; }
        int UpdateOrder { get; }

        event EventHandler EnabledChanged;
        event EventHandler UpdateOrderChanged;

        void Update(GameTime gameTime);
    }
}
