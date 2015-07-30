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

namespace Microsoft.Xna.Framework.Audio
{
    public class AudioEngine : IDisposable
    {
        public AudioEngine(string path)
        {
            throw new NotImplementedException();
        }

        public AudioCategory GetCategory(string name)
        {
            throw new NotImplementedException();
        }

        public float GetGlobalVariable(string name)
        {
            throw new NotImplementedException();
        }        

        public void Update()
        {

        }

        #region IDisposable Members

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
