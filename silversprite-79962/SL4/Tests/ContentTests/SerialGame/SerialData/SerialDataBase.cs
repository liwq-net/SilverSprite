using Microsoft.Xna.Framework.Content;
using System.Text;
using System.Reflection;
using System.Collections.Generic;
using System.Collections;

namespace SerialData
{
    public abstract class SerialDataBase
    {
        /// <summary>
        /// The name of the content pipeline asset that contained this object.
        /// </summary>
        private string assetName;

        /// <summary>
        /// The name of the content pipeline asset that contained this object.
        /// </summary>
        [ContentSerializerIgnore]
        public string AssetName
        {
            get { return assetName; }
            set { assetName = value; }
        }

        #region Helpers

        public string GetDebugInfo()
        {
            discovered.Clear();
            return GetDebugInfo(this, string.Empty);
        }

        static List<object> discovered = new List<object>();

        private static string GetDebugInfo(object o, string prefix)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(prefix + o.GetType().FullName + ": " + o.GetHashCode());

            if (discovered.Contains(o)) {
                sb.AppendLine(prefix + "- ... (see above)");
                return sb.ToString();
            }

            discovered.Add(o);

            PropertyInfo[] pi = o.GetType().GetProperties();
            foreach (PropertyInfo prop in pi) {
                object pval = prop.GetValue(o, null);
                sb.AppendLine(prefix + "- Property " + prop.Name + ": " + pval);
                if (pval is SerialDataBase)
                    sb.Append(GetDebugInfo(pval, prefix + "    "));
                if (pval is IList)
                    foreach (object i in pval as IList)
                        sb.AppendLine(prefix + "    - Value: " + i.ToString() + " HashCode: " + i.GetHashCode());
            }

            FieldInfo[] fi = o.GetType().GetFields();
            foreach (FieldInfo field in fi) {
                object fval = field.GetValue(o);
                sb.AppendLine(prefix + "- Field " + field.Name + ": " + fval);
                if (fval is SerialDataBase)
                    sb.Append(GetDebugInfo(fval, prefix + "    "));
                if (fval is IList)
                    foreach (object i in fval as IList)
                        sb.AppendLine(prefix + "    - Value: " + i.ToString() + " HashCode: " + i.GetHashCode());
            }

            return sb.ToString();
        }

        #endregion
    }
}
