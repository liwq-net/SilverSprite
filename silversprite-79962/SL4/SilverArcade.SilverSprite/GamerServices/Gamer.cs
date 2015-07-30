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
    public class Gamer
    {
        static SignedInGamerCollection _signedInGamers = new SignedInGamerCollection();
        public static SignedInGamerCollection SignedInGamers
        {
            get
            {
                return _signedInGamers;
            }
        }

    }
}
