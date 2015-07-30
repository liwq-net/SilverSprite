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
using Microsoft.Xna.Framework.Storage;
using System.Collections.Generic;

namespace Microsoft.Xna.Framework.GamerServices
{
	public enum MessageBoxIcon
	{
		None = 0,
		Error = 1,
		Warning = 2,
		Alert = 3,
	}

    public class Guide
    {
        static SignedInGamerCollection _signedInGamers = new SignedInGamerCollection();
        public static bool IsVisible
        {
            get
            {
                return false;
            }
        }

        public static bool IsTrialMode
        {
            get
            {
                return false;
            }
        }

        public static void ShowMarketplace(PlayerIndex playerIndex)
        {
        }

        public static SignedInGamerCollection SignedInGamers
        {
            get
            {
                return _signedInGamers;
            }
        }

        public static IAsyncResult BeginShowKeyboardInput(PlayerIndex player, string title, string description, string defaultText, AsyncCallback callback, object state)
        {
            callback(null);
            return null;
        }

        public static string EndShowKeyboardInput(IAsyncResult result)
        {
            return "";
        }

        public static IAsyncResult BeginShowStorageDeviceSelector(AsyncCallback callback, object state)
        {
            callback(null);
            return null;
        }

		public static IAsyncResult BeginShowMessageBox(PlayerIndex player, string title, string text, IEnumerable<string> buttons, int focusButton, MessageBoxIcon icon, AsyncCallback callback, object state)
		{
			callback(null);
			return null;
		}

		public static IAsyncResult BeginShowStorageDeviceSelector(PlayerIndex player, AsyncCallback callback, object state)
        {
            callback(null);
            return null;
        }

        public static IAsyncResult BeginShowStorageDeviceSelector(int sizeInBytes, int directoryCount, AsyncCallback callback, object state)
        {
            callback(null);
            return null;
        }

        public static IAsyncResult BeginShowStorageDeviceSelector(PlayerIndex player, int sizeInBytes, int directoryCount, AsyncCallback callback, object state)
        {
            callback(null);
            return null;
        }

        public static StorageDevice EndShowStorageDeviceSelector(IAsyncResult result)
        {
            return new StorageDevice();
        }

		public static int? EndShowMessageBox(IAsyncResult result)
		{
			return 0;
		}
    }
}
