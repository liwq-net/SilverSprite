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
using System.IO.IsolatedStorage;
using System.IO;

namespace Microsoft.Xna.Framework.Storage
{
    public class StorageContainer : IDisposable
    {
        StorageDevice _device;
        string _path = "";
        IsolatedStorageFile _file;

        public StorageContainer()
        {
            _device = new StorageDevice();
        }

        public StorageContainer(StorageDevice device, string containerName)
        {
            _device = device;
            _path = containerName;
        }

        public void DeleteFile(string filename)
        {
        }

        public bool FileExists(string filename)
        {
            return false;
        }

        public string[] GetFileNames(string match)
        {
            return new string[0];
        }

        public Stream OpenFile(string fileName, FileMode mode)
        {
            return null;
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
