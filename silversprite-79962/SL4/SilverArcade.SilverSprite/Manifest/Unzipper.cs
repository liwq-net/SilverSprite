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
using System.IO;
using System.Windows.Resources;
using System.Collections.Generic;

namespace SilverArcade.SilverSprite.Manifest
{
	public class Unzipper
	{
		private Stream stream;

		public Unzipper(Stream zipFileStream)
		{
			this.stream = zipFileStream;
		}

		public Stream GetFileStream(string filename)
		{
			Uri fileUri = new Uri(filename, UriKind.Relative);
			StreamResourceInfo info = new StreamResourceInfo(this.stream, null);
			StreamResourceInfo stream = System.Windows.Application.GetResourceStream(info, fileUri);
			if (stream != null)
				return stream.Stream;
			return null;
		}

		public IEnumerable<string> GetFileNamesInZip()
		{
			BinaryReader reader = new BinaryReader(stream);
			stream.Seek(0, SeekOrigin.Begin);
			string name = null;
			while (ParseFileHeader(reader, out name))
			{
				yield return name;
			}
		}

		private static bool ParseFileHeader(BinaryReader reader, out string filename)
		{
			filename = null;
			if (reader.BaseStream.Position < reader.BaseStream.Length)
			{
				int headerSignature = reader.ReadInt32();
				if (headerSignature == 67324752) //PKZIP
				{
					reader.BaseStream.Seek(14, SeekOrigin.Current); //ignore unneeded values
					int compressedSize = reader.ReadInt32();
					int unCompressedSize = reader.ReadInt32();
					short fileNameLenght = reader.ReadInt16();
					short extraFieldLenght = reader.ReadInt16();
					filename = new string(reader.ReadChars(fileNameLenght));
					if (string.IsNullOrEmpty(filename))
						return false;
					//Seek to the next file header
					reader.BaseStream.Seek(extraFieldLenght + compressedSize, SeekOrigin.Current);
					if (unCompressedSize == 0) //Directory or not supported. Skip it
						return ParseFileHeader(reader, out filename);
					else
						return true;
				}
			}
			return false;
		}
	}
}
