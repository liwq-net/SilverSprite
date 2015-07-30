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
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Reflection;
using System.Windows.Markup;

namespace SilverArcade.SilverSprite.Manifest
{
	public class Directory
	{
		static public string[] GetFiles(string path)
		{
			path = path.Replace("\\", "/");
			List<string> files = Discovery.Resources;
			List<string> result = new List<string>();
			foreach (string file in files)
			{
				int idx = file.IndexOf(";component/");
				string f = file.Substring(idx + 11);
				if (f.Length >= path.Length &&
					f.Substring(0, path.Length).ToLower() == path.ToLower())
				{
					result.Add(file);					
				}
			}
			files = Discovery.Content;
			foreach (string file in files)
			{
				int idx = file.IndexOf("/");
				string f = file.Substring(idx + 1);
				if (f.Length >= path.Length &&
					f.Substring(0, path.Length).ToLower() == path.ToLower())
				{
					result.Add(file);
				}
			}
			return result.ToArray();
		}
	}
}
