using System;
using System.IO;
using System.Reflection;
using AmeriHome.Root.Behavior.Clients;

namespace AmeriHome.DataAccess.Clients
{
	public class FileClient : IFileClient
	{
		private readonly string root;
		public string Root
		{
			get { return this.root; }
		}


		public FileClient()
		{						
			var tempRoot = String.Format(@"{0}\..\..\..", Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase));
			this.root = new Uri(tempRoot).LocalPath;
		}  


		public string GetLocalPath(string relativePath)
		{
			if (relativePath == null)
				throw new ArgumentNullException("relativePath"); //nameof(relativePath)

			var result = String.Format(@"{0}{1}", this.Root, relativePath);
			return result;
		}

		public void WriteToFile(string relativePath, string text)
		{
			if (relativePath == null)
				throw new ArgumentNullException("relativePath"); //nameof(relativePath)

			File.WriteAllText(GetLocalPath(relativePath), text);
		}

		public string ReadFromFile(string relativePath)
		{
			if (relativePath == null)
				throw new ArgumentNullException("relativePath"); //nameof(relativePath)

			var result = File.ReadAllText(GetLocalPath(relativePath));
			return result;
		}
	}
}
