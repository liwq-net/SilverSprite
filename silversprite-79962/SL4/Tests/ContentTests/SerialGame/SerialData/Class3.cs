using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;

namespace SerialData
{
    public class Class3 : SerialDataBase
    {
        public string OneString { get; set; }

        [ContentSerializerIgnore]
        public string DerivedString { get; set; }

        public Class2 SharedClass2Res { get; set; }

        public List<string> ListStr { get; set; }

        #region Content Type Reader

        public class Reader : ContentTypeReader<Class3>
        {
            protected override Class3 Read(ContentReader input, Class3 existingInstance)
            {
                Class3 c3 = existingInstance;
                if (c3 == null) {
                    c3 = new Class3();
                }

                c3.OneString = input.ReadString();
                c3.DerivedString = input.ReadString() + c3.OneString.ToUpper(); // see writer
                input.ReadSharedResource<Class2>(o => c3.SharedClass2Res = o);
                c3.ListStr = input.ReadObject<List<string>>();

                return c3;
            }
        }

        #endregion
    }
}
