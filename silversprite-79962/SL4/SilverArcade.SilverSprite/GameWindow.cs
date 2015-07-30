#region License
/*
MIT License
Copyright � 2006 The Mono.Xna Team

All rights reserved.

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/
#endregion License

using System;
using System.Collections.Generic;
using System.Text;


namespace Microsoft.Xna.Framework
{
    public abstract class GameWindow
    {
        #region Private Fields

        string _title;
        protected Game _game;

        #endregion Private Fields

        #region Constructors

        protected GameWindow(Game game)
        {
            _game = game;
        }

        #endregion Constructors

        public abstract void BeginScreenDeviceChange(bool willBeFullScreen);

        public void EndScreenDeviceChange(string screenDeviceName)
        {
            throw new NotImplementedException();
        }

        public abstract void EndScreenDeviceChange(string screenDeviceName, int clientWidth, int clientHeight);

        protected void OnActivated()
        {
        }

        protected void OnClientSizeChanged()
        {
            if (ClientSizeChanged != null)
                ClientSizeChanged(this, EventArgs.Empty);
        }

        protected void OnDeactivated()
        {
        }

        protected void OnPaint()
        {
            throw new NotImplementedException();
        }

        protected void OnScreenDeviceNameChanged()
        {
            if (ScreenDeviceNameChanged != null)
                ScreenDeviceNameChanged(this, EventArgs.Empty);
        }

        protected abstract void SetTitle(string title);

        public abstract bool AllowUserResizing { get; set; }

        public abstract Rectangle ClientBounds { get; }

        public abstract IntPtr Handle { get; }

        public abstract string ScreenDeviceName { get; }

        public string Title
        {
            get { return _title; }
            set
            {
                if (_title != value)
                {
                    _title = value;
                    SetTitle(_title);
                }
            }
        }

        public event EventHandler ClientSizeChanged;

        public event EventHandler ScreenDeviceNameChanged;

        #region Protected Members

        protected Game Game
        {
            get { return _game; }
        }

        #endregion Protected Members
    }
}
