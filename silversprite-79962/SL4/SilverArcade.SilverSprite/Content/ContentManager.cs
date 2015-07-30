#region License
/*
MIT License
Copyright � 2006 The Mono.Xna Team

All rights reserved.

Authors:
Alan McGovern <alan.mcgovern@gmail.com>
 
Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/
#endregion License

using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Reflection;
using System.Windows.Media.Imaging;
using System.Windows;
using System.Windows.Resources;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

using Silverlight.Samples;
using SilverArcade.SilverSprite.Manifest;
using System.Text.RegularExpressions;

namespace Microsoft.Xna.Framework.Content
{

    public class ContentManager : IDisposable
    {
        #region Private Members

        private Dictionary<string, object> assets;
        private bool disposed;
        private string rootDirectory;
        private IServiceProvider serviceProvider;
		Type frameworkType;
		Type contentType;
		
		#endregion


        #region Public Properties

        public string RootDirectory
        {
            get
            {
                return rootDirectory;
            }
            set
            {
                rootDirectory = value;
            }
        }

        public IServiceProvider ServiceProvider
        {
            get { return this.serviceProvider; }
        }

        #endregion


        #region Public Constructors

		void InitializeRuntimeTypes()
		{
			frameworkType = typeof(Microsoft.Xna.Framework.Rectangle);
			contentType = typeof(Microsoft.Xna.Framework.Content.ListReader<int>);
		}

        public ContentManager(IServiceProvider serviceProvider)
            : this(serviceProvider, string.Empty)
        {
            // Empty
			InitializeRuntimeTypes();
        }

        public ContentManager(IServiceProvider serviceProvider, string rootDirectory)
        {
            if (serviceProvider == null)
                throw new ArgumentNullException("serviceProvider");

            if (rootDirectory == null)
                throw new ArgumentNullException("rootDirectory");

            this.assets = new Dictionary<string, object>();
            this.rootDirectory = rootDirectory;
            this.serviceProvider = serviceProvider;
			InitializeRuntimeTypes();
		}

        #endregion


        #region Destructor

        ~ContentManager()
        {
            Dispose(false);
        }

        #endregion


        #region Protected Methods

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    // Dispose any managed resources
                    Unload();
                }
                // Dispose any unmanaged resources

                this.disposed = true;
            }
        }


        protected virtual Stream OpenStream(string assetName)
        {
            Stream stream;
            try
            {
                string path = Path.Combine(rootDirectory, assetName + ".xnb");
                stream = File.OpenRead(path);
            }
            catch (FileNotFoundException fileNotFound)
            {
                throw new ContentLoadException("The content file was not found.", fileNotFound);
            }
            catch (DirectoryNotFoundException directoryNotFound)
            {
                throw new ContentLoadException("The directory was not found.", directoryNotFound);
            }
            catch (Exception exception)
            {
                throw new ContentLoadException("Opening stream error.", exception);
            }
            return stream;
        }

        #endregion Protected Methods


        #region Public Methods

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        int ReadLittleEndianShort(BinaryReader r)
        {
            int ret = 0;
            for (int i = 0; i < 2; i++)
            {
                ret *= 256;
                ret += r.ReadByte();
            }
            return ret;
        }

        int ReadLittleEndianInt(BinaryReader r)
        {
            int ret = 0;
            for (int i = 0; i < 4; i++)
            {
                ret *= 256;
                ret += r.ReadByte();
            }
            return ret;
        }

        Vector2 ParseJpgHeader(Stream stream)
        {
            BinaryReader br = new BinaryReader(stream);
            try
            {
                int s = ReadLittleEndianShort(br);
                if (s != 0xFFD8) return Vector2.Zero;
                s = ReadLittleEndianShort(br);
                if (s != 0xFFE0) return Vector2.Zero;
                int len = ReadLittleEndianShort(br);
                br.ReadBytes(len - 2);
                while (true)
                {
                    s = br.ReadByte();
                    if (s != 0xFF)
                    {
                        break;
                    }
                    s = br.ReadByte();
                    if (s == 0xD9 || s == 0xDA) break;
                    len = ReadLittleEndianShort(br);
                    if (s == 0xC0 || s == 0xC1 || s == 0xC2 || s == 0xC3 ||
                        s == 0xC5 || s == 0xC6 || s == 0xC7 ||
                        s == 0xC9 || s == 0xCA || s == 0xCB ||
                        s == 0xCD || s == 0xCE || s == 0xCF
                        )
                    {
                        br.ReadByte();
                        int height = ReadLittleEndianShort(br);
                        int width = ReadLittleEndianShort(br);
                        return new Vector2(width, height);
                    }
                    br.ReadBytes(len - 2);
                }
            }
            catch
            {
            }
            finally
            {
                br.Close();
                stream.Dispose();
            }
            return Vector2.Zero;
        }

        Vector2 ParsePngHeader(Stream stream)
        {
            BinaryReader br = new BinaryReader(stream);
            for (int i = 0; i < 8; i++)
            {
                br.ReadByte();
            }
            int hdrLen = ReadLittleEndianInt(br);
            char[] hdrType = br.ReadChars(4);
            if (hdrType[0] == 'I' &&
                hdrType[1] == 'H' &&
                hdrType[2] == 'D' &&
                hdrType[3] == 'R')
            {
                for (int i = 0; i < 4; i++)
                {
                }
                int width = ReadLittleEndianInt(br);
                int height = ReadLittleEndianInt(br);
                br.Close();
                stream.Dispose();
                return new Vector2(width, height);
            }
            return Vector2.Zero;
        }

        Texture2D GetXAMLTexture(string assetName, Stream stream)
        {
            GraphicsDevice graphicsDevice = ((IGraphicsDeviceService)this.serviceProvider.GetService(typeof(IGraphicsDeviceService))).GraphicsDevice;
            var xamlTexture = new Texture2D(stream, graphicsDevice);
            xamlTexture.AssetName = assetName;
            return xamlTexture;
        }

        Texture2D TryLoadBmp(string assetName)
        {
            Vector2 size = Vector2.Zero;

			Stream stream = GetAssetStream(assetName, ".bmp");
            if (stream == null) return null;
            BmpTexture t = BMPDecoder.Decode(stream);
            size = new Vector2(t.Width, t.Height);
            GraphicsDevice graphicsDevice = ((IGraphicsDeviceService)this.serviceProvider.GetService(typeof(IGraphicsDeviceService))).GraphicsDevice;
            Texture2D texture = new Texture2D(t.GetWriteableBitmap());
            texture.AssetName = assetName;
            return texture;
        }

        Texture2D TryLoadJpg(string assetName)
        {
			Vector2 size = Vector2.Zero;
			Stream stream = GetAssetStream(assetName, ".jpg");
			if (stream == null) return null;
            size = ParseJpgHeader(stream);
			stream = GetAssetStream(assetName, ".jpg");
			GraphicsDevice graphicsDevice = ((IGraphicsDeviceService)this.serviceProvider.GetService(typeof(IGraphicsDeviceService))).GraphicsDevice;

            Texture2D texture = new Texture2D(stream, graphicsDevice, size);
            texture.AssetName = assetName;
            return texture;
        }

        Texture2D TryLoadPng(string assetName)
        {
			Vector2 size = Vector2.Zero;
			Stream stream = GetAssetStream(assetName, ".png");
			if (stream == null) return null;
			size = ParsePngHeader(stream);
			stream = GetAssetStream(assetName, ".png");
			GraphicsDevice graphicsDevice = ((IGraphicsDeviceService)this.serviceProvider.GetService(typeof(IGraphicsDeviceService))).GraphicsDevice;

            Texture2D texture = new Texture2D(stream, graphicsDevice, size);
            texture.AssetName = assetName;
            return texture;
        }

        Texture2D LoadTextureFromBitmap(string assetName)
        {
            Vector2 size = Vector2.Zero;

			Stream stream = GetAssetStream(assetName, ".xaml");
            if (stream != null)
                return GetXAMLTexture(assetName, stream);
            Texture2D texture = TryLoadPng(assetName);
            if (texture == null)
            {
                texture = TryLoadJpg(assetName);
            }
            if (texture == null)
            {
                texture = TryLoadBmp(assetName);
            }

            return texture;
        }

        public virtual T Load<T>(string assetName)
        {
            assetName = assetName.Replace("\\", "/");
            object obj = null;
			if (assets.ContainsKey(assetName))
			{
				try
				{
					T asset = (T)assets[assetName];
					return asset;
				}
				catch
				{
				}
			}
            if (typeof(T) == typeof(Texture2D))
            {
                obj = LoadTextureFromBitmap(assetName);
                if (obj == null)
                {
                    Texture2D texture = LoadXnb<T>(assetName) as Texture2D;
                    texture.AssetName = assetName;
					obj = texture;
                }
            }
            else if (typeof(T) == typeof(SpriteFont))
            {
                string path = assetName + ".spritefont";
                if (RootDirectory != "")
                {
                    path = RootDirectory + "/" + path;
                }

				Stream stream = GetAssetStream(assetName, ".spritefont");
                if (stream != null)
                {
                    SpriteFont font = new SpriteFont(stream);
                    stream.Close();
                    font.AssetName = assetName;
                    obj = font;
                }
                else
                {
                    SpriteFont spriteFont = LoadXnb<T>(assetName) as SpriteFont;
                    spriteFont.AssetName = assetName;
                    obj = spriteFont;
                }
            }
            else if (typeof(T) == typeof(SoundEffect))
            {
				obj = new SoundEffect(this, assetName);				
            }
            else if (typeof(T) == typeof(Song))
            {
                string path = assetName;
                if (RootDirectory != "")
                {
                    path = RootDirectory + "/" + path;
                }
				obj = new Song(this, path);
            }
            if (obj != null)
            {
                assets.Add(assetName, obj);
            }
            else
            {
                obj = LoadXnb<T>(assetName);
            }
            return (T)obj;
        }

        public virtual T LoadXnb<T>(string assetName)
        {
            if (this.disposed)
                throw new ObjectDisposedException(base.ToString());   // Prints out the full type information as the message

            if (string.IsNullOrEmpty(assetName))
                throw new ArgumentNullException("assetName");       // We can't load an asset if we don't know it's name

            // Try to get a stream for the supplied asset
            Stream assetStream = GetAssetStream(assetName, ".xnb");

            // Get the graphics device from the service provider to pass to the contentreader
            GraphicsDevice graphicsDevice = ((IGraphicsDeviceService)this.serviceProvider.GetService(typeof(IGraphicsDeviceService))).GraphicsDevice;

            // Create a contentreader for the stream to read out the asset (whatever it is)
            ContentReader reader = new ContentReader(this, assetStream, graphicsDevice);

            // Get the asset's type readers. There can be a few of these like for the model class.
//            ContentTypeReader[] assetReaders = GetAssetReaders<T>(contentReader);
//            contentReader.TypeReaders = assetReaders;
            ContentTypeReaderManager manager = new ContentTypeReaderManager(reader);
//            foreach (ContentTypeReader r in assetReaders)
//            {
//                r.Initialize(manager);
//            }
            // billreiss need to read a byte here for things to work out, not sure why
  //          assetStream.ReadByte();
            byte[] headerBuffer = new byte[4];
            reader.Read(headerBuffer, 0, 4);
            string headerString = Encoding.UTF8.GetString(headerBuffer, 0, 4);
            if (string.Compare(headerString, "XNBw", StringComparison.InvariantCultureIgnoreCase) != 0)
                throw new ContentLoadException("Asset does not appear to be a valid XNB file.  Did you process your content for Windows Live not XBOX?");

            // I think these two bytes are some kind of version number. Either for the XNB file or the type readers
            byte version = reader.ReadByte();
            byte compressed = reader.ReadByte();
            // The next int32 is the length of the XNB file
            int xnbLength = reader.ReadInt32();

            if (compressed != 0)
            {
                throw new NotImplementedException("SilverSprite cannot read compressed XNB files. Please use the XNB files from the Debug build of your XNA game instead. If someone wants to contribute decompression logic, that would be fantastic.");
            }
            // Get the 1-based index of the typereader we should use to start decoding with

            T asset = reader.ReadAsset<T>();

            return asset;
        }

		string ParseReaderType(string readerTypeString)
		{
			string child = "";
			if (readerTypeString.Contains("["))
			{
				string[] s = readerTypeString.Split("[]".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
				child = ParseReaderType(s[1]);
				readerTypeString = readerTypeString.Replace(s[1], "{child}");
			}
			string[] r = readerTypeString.Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
			string version = "";
			if (r.Length > 2)
			{
				version = r[2];
			}
			if (r.Length > 1)
			{
				if (r[1] == "Microsoft.Xna.Framework")
				{
					if (r[0].Contains("Content"))
					{
						string[] u = contentType.AssemblyQualifiedName.Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
						r[1] = u[1];
						version = u[2];
					}
					else
					{
						string[] u = frameworkType.AssemblyQualifiedName.Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
						r[1] = u[1];
						version = u[2];
					}
				}
			}
			string result = r[0];
			if (r.Length > 1)
			{
				result += ", " + r[1];
			}
			if (version != "")
			{
				result += ", " + version;
			}
			result = result.Replace("{child}", child);
			return result;
		}

		Type GetReaderType(string readerTypeString)
		{
			Type type = Type.GetType(readerTypeString);
			if (type != null) return type;
			string tmp = ParseReaderType(readerTypeString);
			type = Type.GetType(tmp);
			return type;
		}

        private ContentTypeReader[] GetAssetReaders<T>(ContentReader reader)
        {
            int numberOfReaders;
            ContentTypeReader[] contentReaders;
            //            BinaryReader binaryReader = new BinaryReader(assetStream);
            // The first 4 bytes should be the "XNBw" header. i use that to detect an invalid file

            byte[] headerBuffer = new byte[4];
            reader.Read(headerBuffer, 0, 4);
            string headerString = Encoding.UTF8.GetString(headerBuffer, 0, 4);
            if (string.Compare(headerString, "XNBw", StringComparison.InvariantCultureIgnoreCase) != 0)
                throw new ContentLoadException("Asset does not appear to be a valid XNB file.  Did you process your content for Windows Live not XBOX?");

            // I think these two bytes are some kind of version number. Either for the XNB file or the type readers
            byte version = reader.ReadByte();
            byte compressed = reader.ReadByte();
            // The next int32 is the length of the XNB file
            int xnbLength = reader.ReadInt32();

            if (compressed != 0)
            {
                throw new NotImplementedException("SilverSprite cannot read compressed XNB files. Please use the XNB files from the Debug build of your XNA game instead. If someone wants to contribute decompression logic, that would be fantastic.");
            }

            // The next byte i read tells me the number of content readers in this XNB file
            numberOfReaders = reader.ReadByte();
            contentReaders = new ContentTypeReader[numberOfReaders];
            // For each reader in the file, we read out the length of the string which contains the type of the reader,
            // then we read out the string. Finally we instantiate an instance of that reader using reflection
            for (int i = 0; i < numberOfReaders; i++)
            {
                // This string tells us what reader we need to decode the following data
                string readerTypeString = reader.ReadString();

                // I think the next 4 bytes refer to the "Version" of the type reader,
                // although it always seems to be zero
                int typeReaderVersion = reader.ReadInt32();

//                int idx = readerTypeString.IndexOf(", Microsoft.Xna.Framework, Version=");
//                if (idx >= 0)
//                {
//                    readerTypeString = readerTypeString.Substring(0, idx) + "]";
//                    readerTypeString = readerTypeString.Replace("[[", "[");

//                }
                // Get the type of the reader
				Type readerType = GetReaderType(readerTypeString);

                // Get the default constructor for the reader
                ConstructorInfo info = readerType.GetConstructor(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.CreateInstance, null, Type.EmptyTypes, null);
                
                // Instantiate an instance of the reader
                contentReaders[i] = (ContentTypeReader)info.Invoke(null);
            }

            return contentReaders;
        }

internal static string CleanPath(string path) 
 { 
 int lastindex; 
 path = path.Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar); 
 for (int i = 1; i < path.Length; i = Math.Max(lastindex - 1, 1)) 
 { 
 i = path.IndexOf(@"\..\", i); 
 if (i < 0) 
 { 
 return path; 
 } 
 lastindex = path.LastIndexOf(Path.DirectorySeparatorChar, i - 1) + 1; 
 path = path.Remove(lastindex, (i - lastindex) + @"\..\".Length); 
 } 
 return path; 
 } 
 
        public virtual void Unload()
        {
            if (this.disposed)
                throw new ObjectDisposedException(this.GetType().ToString());

            GraphicsDevice graphicsDevice = ((IGraphicsDeviceService)this.serviceProvider.GetService(typeof(IGraphicsDeviceService))).GraphicsDevice;
			foreach (object o in assets)
			{
				if (o is Texture2D)
				{
					Texture2D tex = o as Texture2D;
					graphicsDevice.CleanupTexture(tex);
				}
				IDisposable disposableObject = o as IDisposable;
				if (disposableObject != null)
					disposableObject.Dispose();
			}

			assets.Clear();

            
            this.disposed = true;
        }

        #endregion



        #region Private Methods

		private Stream GetResourceStream(string assetName, string extension)
		{
            Stream stream = null;
			
            string path = Path.Combine(this.rootDirectory, assetName + extension);
            path = path.Replace("\\", "/");
			path = string.Format("/{0};component/{1}", Discovery.EntryPointAssembly, path);
			StreamResourceInfo info = Application.GetResourceStream(new Uri(path, UriKind.Relative));
			if (info == null) return null;
			stream = info.Stream;
            return stream;
		}

        internal Stream GetAssetStream(string assetName, string extension)
        {
            Stream stream = null;
            string path = Path.Combine(this.rootDirectory, assetName + extension);
            path = path.Replace("\\", "/");
            // If the file doesn't exist, don't even try to open it. Throw an exception
            //       if (!File.Exists(path))
            //                throw new ContentLoadException("File could not be found");


			//           stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
            StreamResourceInfo info = Application.GetResourceStream(new Uri(path, UriKind.Relative));
			if (info == null) return GetResourceStream(assetName, extension);
			stream = info.Stream;
            return stream;
        }

        #endregion
    }
}
