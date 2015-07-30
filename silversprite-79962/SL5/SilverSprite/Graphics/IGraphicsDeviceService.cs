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

namespace Microsoft.Xna.Framework.Graphics
{
    // Summary:
    //     Defines a mechanism for retrieving GraphicsDevice objects.  Reference page
    //     contains links to related code samples.
    public interface IGraphicsDeviceService
    {
        GraphicsDevice GraphicsDevice { get; }
        event EventHandler DeviceCreated;
        event EventHandler DeviceDisposing;
        event EventHandler DeviceReset;
        event EventHandler DeviceResetting;
    }
}
