/* 
 * Thanks to Alex Golesh for the content and resource enumeration code
 * 
 * Alex's blog: http://blogs.microsoft.co.il/blogs/alex_golesh/
*/
using System;
using System.Net;
using System.Windows;
using System.Xml;
using System.Reflection;
using System.Resources;
using System.IO;
using System.Threading;
using System.Collections;
using System.Collections.Generic;

namespace SilverSprite.Manifest
{
	public class Discovery
	{
		static List<string> resources = new List<string>();
		static List<string> content = new List<string>();
		static string entryPointAssembly;

		static bool ready = false;

		public static void Initialize()
		{
			GetResourcesInternal();
//			GetContentInternal();
			ready = true;
		}

		public static bool Ready
		{
			get { return ready; }
		}

		public static string EntryPointAssembly
		{
			get { return entryPointAssembly; }
			set { entryPointAssembly = value; }
		}

		static public List<string> Resources
		{
			get
			{
				return resources;
			}
		}

		static public List<string> Content
		{
			get
			{
				return content;
			}
		}


		static void GetContentInternal()
		{
			string xapFile = Application.Current.Host.Source.LocalPath;
			int idx = xapFile.LastIndexOf("/");
			xapFile = xapFile.Substring(idx + 1);
			WebClient wc = new WebClient();
			wc.OpenReadCompleted += new OpenReadCompletedEventHandler(wc_OpenReadCompleted);
			wc.OpenReadAsync(new Uri(xapFile, UriKind.Relative));
		}

		static void wc_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
		{
			Stream s = e.Result;

			Unzipper unzip = new Unzipper(s);

			foreach (string filename in unzip.GetFileNamesInZip())
			{
				content.Add("/" + filename);
			}
			ready = true;
		}

		static void GetResourcesInternal()
		{
			AssemblyPartCollection parts = Deployment.Current.Parts;
			EntryPointAssembly = Deployment.Current.EntryPointAssembly;
			foreach (var part in parts)
			{
				Stream ss = Application.GetResourceStream(new Uri(part.Source, UriKind.Relative)).Stream;
				Assembly assy = part.Load(ss);
				string[] resources = assy.GetManifestResourceNames();

				foreach (var resource in resources)
				{
					ResourceManager rm = new ResourceManager(resource.Replace(".resources", ""), assy);
					Stream DUMMY = rm.GetStream("app.xaml"); //Donno why, but without getting any real stream next statement doesn't work....

					ResourceSet rs = rm.GetResourceSet(Thread.CurrentThread.CurrentUICulture, false, true);

					IDictionaryEnumerator enumerator = rs.GetEnumerator();
					while (enumerator.MoveNext())
					{
						string assembly = part.Source;
						int idx = assembly.LastIndexOf(".");
						assembly = assembly.Substring(0, idx);
						string path = string.Format("/{0};component/{1}", assembly, (string)enumerator.Key);
						Discovery.resources.Add(path);
					}

				}

			}
		}
	}
}
