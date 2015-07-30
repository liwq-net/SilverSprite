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
using System.Threading;

namespace Microsoft.Xna.Framework.Storage
{
    public class StorageContainerOpenAsyncResult : IAsyncResult
    {
        ManualResetEvent waitHandle = new ManualResetEvent(false);

        public object AsyncState
        {
            get;
            internal set;
        }

        public System.Threading.WaitHandle AsyncWaitHandle
        {
            get { return waitHandle; }
        }

        public bool CompletedSynchronously
        {
            get { return true; }
        }

        public bool IsCompleted
        {
            get { return true; }
        }

        internal string DisplayName;
    }
}
