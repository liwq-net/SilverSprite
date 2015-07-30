using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;

namespace SerialData
{
    public class SharedResourceList<T> : List<T> 
    {
        public SharedResourceList()
            : base()
        {
        }

        public SharedResourceList(int capacity)
            : base(capacity)
        {
        }

        public SharedResourceList(IEnumerable<T> collection)
            : base(collection)
        {
        }

        #region Content Type Reader

        public class Reader : ContentTypeReader<SharedResourceList<T>>
        {
            protected override SharedResourceList<T> Read(ContentReader input, SharedResourceList<T> existingInstance)
            {
                SharedResourceList<T> c3 = existingInstance;
                if (c3 == null) {
                    c3 = new SharedResourceList<T>();
                }

                int count = input.ReadInt32();
                for (int i = 0; i < count; ++i)
                    input.ReadSharedResource<T>(o => c3.Add(o));

                return c3;
            }
        }

        #endregion
    }
}
