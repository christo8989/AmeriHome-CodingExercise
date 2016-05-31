using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmeriHome.Root.Behavior.Clients
{
	public interface IFileClient
	{
		string GetLocalPath(string relativePath);
		string ReadFromFile(string relativePath);
		string Root { get; }
		void WriteToFile(string relativePath, string text);
	}
}
