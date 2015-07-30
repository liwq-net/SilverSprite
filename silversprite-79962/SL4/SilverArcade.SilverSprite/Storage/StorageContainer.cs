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

namespace Microsoft.Xna.Framework.Storage
{
    public class StorageContainer : IDisposable
    {
        StorageDevice _device;
        string _path = "";

        public StorageContainer()
        {
            _device = new StorageDevice();
        }

        public StorageContainer(StorageDevice device, string containerName)
        {
            _device = device;
            _path = containerName;
        }

        #region Public Properties

        public StorageDevice StorageDevice
        {
            get
            {
                return _device;
            }
        }

        public string Path
        {
            get
            {
                return _path;
            }
        }

        #endregion Public Properties

        #region Public Static Properties

        public static string TitleLocation 
        { 
            get { return ""; } 
        }

        #endregion Public Static Properties

        #region IDisposable Members

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
