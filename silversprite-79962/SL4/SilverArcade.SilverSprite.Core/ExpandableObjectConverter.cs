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
using System.Globalization;
using System.Collections;

namespace System.ComponentModel
{
    public class ExpandableObjectConverter
    {

        public virtual object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            throw new NotImplementedException();
        }

        public virtual object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            throw new NotImplementedException();
        }

        public virtual object CreateInstance(ITypeDescriptorContext context, IDictionary propertyValues)
        {
            throw new NotImplementedException();
        }

        public virtual bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            throw new NotImplementedException();
        }

        public virtual bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            throw new NotImplementedException();
        }

        public virtual bool GetCreateInstanceSupported(ITypeDescriptorContext context)
        {
            throw new NotImplementedException();
        }

        public virtual PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            throw new NotImplementedException();
        }

        public virtual bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            throw new NotImplementedException();
        }

    }
}
