using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;

namespace SerialData
{
    public class Class2 : SerialDataBase
    {
        #region Properties

        public string Foo { get; set; }

        [ContentSerializer(SharedResource = true)]
        public Class3 Bar { get; set; }

        #endregion
    }
}
