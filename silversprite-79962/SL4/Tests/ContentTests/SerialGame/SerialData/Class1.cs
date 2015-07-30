using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;

namespace SerialData
{
    public class Class1 : SerialDataBase
    {
        public static Class1 CreateTestInstance()
        {
            Class2 c2c = new Class2() { Foo = "foo C", Bar = null }; // automatic serialization
            Class3 c3 = new Class3() { OneString = "lowercase", SharedClass2Res = c2c }; // manual reader/writer serialization
            Class2 c2a = new Class2() { Foo = "foo A", Bar = c3 }; // automatic serialization
            Class2 c2b = new Class2() { Foo = "foo B", Bar = c3 }; // automatic serialization

            Class1 c1 = new Class1(); // automatic serialization
            c1.SimpleString = "This is indeed a string";
            c1.privateField = "A private field"; // but serialized!
            c1.IgnoredString = "An ignored one"; // ignored
            c1.AnotherString = "Another string"; // <BasicString>..
            c1.StringList = new List<string>(new string[] {"a", "b", "c"}); // <ListOfStrings><StringItem>..
            c1.Class2Resource = c2a; // embedded
            c1.SharedClass2Resource = c2a; // shared
            c1.SharedClass2ResourceAgain = c2a; // shared
            c1.SharedClass2ResourceAnother = c2c; // shared
            c1.Class2List = new List<Class2>(new Class2[] { c2a, c2b });
            c1.SharedClass2List = new SharedResourceList<Class2>(new Class2[] { c2a, c2c });
            c1.SharedClass3Resource = c3;
            c1.OptionalNumber = 42;
            c1.AssetName = "c1"; // SerialDataBase

            return c1;
        }

        #region Properties

        public string SimpleString { get; set; }

#pragma warning disable 414 // The field is assigned but its value is never used
        [ContentSerializer] // don't skip this private field
        private string privateField;
#pragma warning restore 414 // The field is assigned but its value is never used

        [ContentSerializerIgnore] // ignore this property
        public string IgnoredString { get; set; }

        [ContentSerializer(ElementName = "BasicString")] // default: AnotherString
        public string AnotherString { get; set; }

        [ContentSerializer(ElementName = "ListOfStrings", CollectionItemName = "StringItem")] // default: StringList & Item
        public List<string> StringList { get; set; }

        public Class2 Class2Resource { get; set; }

        [ContentSerializer(SharedResource = true)]
        public Class2 SharedClass2Resource { get; set; }

        [ContentSerializer(SharedResource = true)]
        public Class2 SharedClass2ResourceAgain { get; set; }

        [ContentSerializer(SharedResource = true)]
        public Class2 SharedClass2ResourceAnother { get; set; }

        [ContentSerializer(SharedResource = true)]
        public Class3 SharedClass3Resource { get; set; }

        public List<Class2> Class2List { get; set; }

        public SharedResourceList<Class2> SharedClass2List { get; set; }

        [ContentSerializer(Optional = true)]
        public int OptionalNumber { get; set; }

        #endregion
    }
}
