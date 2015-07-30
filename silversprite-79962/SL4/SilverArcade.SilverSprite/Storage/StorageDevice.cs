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
    }
}
