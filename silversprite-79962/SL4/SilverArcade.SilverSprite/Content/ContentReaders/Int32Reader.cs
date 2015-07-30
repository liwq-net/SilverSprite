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

namespace Microsoft.Xna.Framework.Content
{
    internal class Int32Reader : ContentTypeReader<int>
    {
        protected internal override int Read(ContentReader input, int existingInstance)
        {
            return input.ReadInt32();
        }

        protected internal override object Read(ContentReader input, object existingInstance)
        {
            int ret = 0;
            ret = Read(input, 0);
            return ret;
        }
    }
}
