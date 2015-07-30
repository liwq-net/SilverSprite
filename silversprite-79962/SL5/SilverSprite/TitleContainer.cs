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
using System.IO;
using Microsoft.Xna.Framework.Content;

namespace Microsoft.Xna.Framework
{
    public static class TitleContainer
    {
        public static Stream OpenStream(string path)
        {
            return Application.GetResourceStream(new Uri(path, UriKind.Relative)).Stream;
        }
    }
}
