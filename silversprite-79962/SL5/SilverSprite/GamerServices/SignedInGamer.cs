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

namespace Microsoft.Xna.Framework.GamerServices
{
    public class SignedInGamer
    {
        public string Gamertag
        {
            get
            {
                return "";
            }
        }

        public PlayerIndex PlayerIndex
        {
            get
            {
                return PlayerIndex.One;
            }
        }

        GamerPrivileges _privileges = new GamerPrivileges();
        public GamerPrivileges Privileges
        {
            get
            {
                return _privileges;
            }
        }

		public GamerPresence Presence { get; internal set; }
    }
}
