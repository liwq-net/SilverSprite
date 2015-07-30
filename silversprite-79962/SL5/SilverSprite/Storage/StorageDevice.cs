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
    public class StorageDevice
    {
        public bool IsConnected
        {
            get
            {
                return true;
            }
        }

        public StorageContainer OpenContainer(string containerName)
        {
            return new StorageContainer(this, containerName);
        }

        public IAsyncResult BeginOpenContainer(string displayName, AsyncCallback callback, object state)
        {
            StorageContainerOpenAsyncResult result = new StorageContainerOpenAsyncResult();
            result.AsyncState = state;
            result.DisplayName = displayName;
            if (callback != null) callback(result);
            return result;
        }

        public StorageContainer EndOpenContainer(IAsyncResult result)
        {
            return new StorageContainer(this, (result as StorageContainerOpenAsyncResult).DisplayName);
        }

        public static IAsyncResult BeginShowSelector(AsyncCallback callback, object state)
        {
            StorageDeviceAsyncResult result = new StorageDeviceAsyncResult();
            result.AsyncState = state;
            if (callback != null)
            {
                callback(result);
            }
            return result;
        }

        public static StorageDevice EndShowSelector(IAsyncResult result)
        {
            return new StorageDevice();
        }
    }
}
