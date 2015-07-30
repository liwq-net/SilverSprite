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
using System.IO.IsolatedStorage;
using System.IO;

namespace SilverArcade.SilverSprite.IO
{
    public class File
    {
        static IsolatedStorageFile isoStore =
                       IsolatedStorageFile.GetUserStoreForApplication();
        public static bool Exists(string path)
        {
            path = path.Replace("\\", "_");
            return isoStore.FileExists(path);
        }

        public static void Delete(string path)
        {
            try
            {
                path = path.Replace("\\", "_");
                isoStore.DeleteFile(path);
            }
            catch
            {
            }
        }

        public static void Move(string source, string target)
        {
            source = source.Replace("\\", "_");
            target = target.Replace("\\", "_");
            IsolatedStorageFileStream writeStream = isoStore.OpenFile(target, System.IO.FileMode.Create, System.IO.FileAccess.Write);
            IsolatedStorageFileStream readStream = isoStore.OpenFile(source, System.IO.FileMode.Open, System.IO.FileAccess.Read);
            
            byte [] buffer = new byte[readStream.Length];
            readStream.Read(buffer, 0, (int)readStream.Length);
            writeStream.Write(buffer, 0, buffer.Length);
            writeStream.Close();
            readStream.Close();
            writeStream.Dispose();
            readStream.Dispose();
            Delete(source);
        }

        public static FileStream OpenRead(string filename)
        {
            filename = filename.Replace("\\", "_");
            IsolatedStorageFileStream fs = isoStore.OpenFile(filename, FileMode.Open, FileAccess.Read);
            return fs as FileStream;
        }

        public static FileStream Create(string filename)
        {
            filename = filename.Replace("\\", "_");
            IsolatedStorageFileStream fs = isoStore.OpenFile(filename, FileMode.Create, FileAccess.ReadWrite);
            return fs as FileStream;
        }

    }
}
