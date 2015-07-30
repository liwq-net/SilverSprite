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

using Microsoft.Xna.Framework;
using Local = Microsoft.Xna.Framework;

namespace Microsoft.Xna.Framework
{
    public class SilverlightGameWindow : GameWindow
    {

        public SilverlightGameWindow(Game game) : base(game)
        {
        }

        public override void BeginScreenDeviceChange(bool willBeFullScreen)
        {
            throw new NotImplementedException();
        }

        public override void EndScreenDeviceChange(string screenDeviceName, int clientWidth, int clientHeight)
        {
            throw new NotImplementedException();
        }

        protected override void SetTitle(string title)
        {
        }

        public override bool AllowUserResizing
        {
            get;
            set;
        }

        public override Local.Rectangle ClientBounds
        {
            get { return new Local.Rectangle(0, 0, (int)_game.drawingSurface.Width, (int)_game.drawingSurface.Height); }
        }

        public override IntPtr Handle
        {
            get { throw new NotImplementedException(); }
        }

        public override string ScreenDeviceName
        {
            get { throw new NotImplementedException(); }
        }
    }
}
