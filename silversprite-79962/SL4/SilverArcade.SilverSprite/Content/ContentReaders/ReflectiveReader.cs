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
using Microsoft.Xna.Framework.Content;
using System.Reflection;

namespace Microsoft.Xna.Framework.Content
{
    public class ReflectiveReader<T> : ContentTypeReader
    {
        ConstructorInfo constructor;
        PropertyInfo[] properties;
        FieldInfo[] fields;
        ContentTypeReaderManager manager;

        public ReflectiveReader() : base(typeof(T))
        {
        }

        protected internal override void Initialize(ContentTypeReaderManager manager)
        {
            base.Initialize(manager);
            this.manager = manager;
            BindingFlags attrs = BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly;
            constructor = typeof(T).GetConstructor(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance, null, new Type[0], null);
            properties = typeof(T).GetProperties(attrs);
            fields = typeof(T).GetFields(attrs);
        }

        object CreateChildObject(PropertyInfo property, FieldInfo field)
        {
            object obj = null;
            Type t;
            if (property != null)
            {
                t = property.PropertyType;
            }
            else
            {
                t = field.FieldType;
            }
            if (t.IsClass)
            {
                ConstructorInfo constructor = t.GetConstructor(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance, null, new Type[0], null);
                if (constructor != null)
                {
                    obj = constructor.Invoke(null);                
                }
            }
            return obj;
        }

        private void Read(object parent, ContentReader input, MemberInfo member)
        {
            PropertyInfo property = member as PropertyInfo;
            FieldInfo field = member as FieldInfo;
            if (property != null && property.CanWrite == false) return;
            Attribute attr = Attribute.GetCustomAttribute(member, typeof(ContentSerializerIgnoreAttribute));
            if (attr != null) return;
            Attribute attr2 = Attribute.GetCustomAttribute(member, typeof(ContentSerializerAttribute));
            bool isSharedResource = false;
            if (attr2 != null)
            {
                var cs = attr2 as ContentSerializerAttribute;
                isSharedResource = cs.SharedResource;
            }
            else
            {
                if (property != null)
                {
                    foreach (MethodInfo info in property.GetAccessors(true))
                    {
                        if (info.IsPublic == false) return;
                    }
                }
                else
                {
                    if (!field.IsPublic) return;
                }
            }
            ContentTypeReader reader = null;
            if (property != null)
            {
                reader = manager.GetTypeReader(property.PropertyType);
            }
            else
            {
                reader = manager.GetTypeReader(field.FieldType);
            }
            if (!isSharedResource)
            {
                object existingChildObject = CreateChildObject(property, field);
                object obj2 = null;
                obj2 = input.ReadObject<object>(reader, existingChildObject);
                if (property != null)
                {
                    property.SetValue(parent, obj2, null);
                }
                else
                {
                    if (field.IsPrivate == false) field.SetValue(parent, obj2);
                }
            }
            else
            {
                Action<object> action = delegate(object value)
                {
                    if (property != null)
                    {
                        property.SetValue(parent, value, null);
                    }
                    else
                    {
                        field.SetValue(parent, value);
                    }
                };
                input.ReadSharedResource<object>(action);
            }
        }
        
        protected internal override object Read(ContentReader input, object existingInstance)
        {
            T obj;
            if (existingInstance != null)
            {
                obj = (T)existingInstance;
            }
            else
            {
                obj = (T)constructor.Invoke(null);
            }
            foreach (PropertyInfo property in properties)
            {
                Read(obj, input, property);
            }
            foreach (FieldInfo field in fields)
            {
                Read(obj, input, field);
            }
            return obj;
        }
    }
}
