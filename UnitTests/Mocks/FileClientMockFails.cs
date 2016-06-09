using System;
using AmeriHome.Root.Behavior.Clients;

namespace UnitTests.Mocks
{
	internal class FileClientMockFails : IFileClient
	{
		public string GetLocalPath(string relativePath)
		{
			return null;
		}

		public string ReadFromFile(string relativePath)
		{
			return null;
		}

		public string Root
		{
			get { return null; }
		}

		public void WriteToFile(string relativePath, string text)
		{
			throw new NotImplementedException();
		}
	}
}
