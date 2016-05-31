using System;
using System.IO;
using AmeriHome.DataAccess.Clients;
using AmeriHome.Root.Behavior.Clients;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Clients
{
	[TestClass]
	public class FileClientTests
	{
		private IFileClient client;

		[TestInitialize]
		public void Initialize()
		{
			client = new FileClient();
		}

		[TestMethod]  
		[ExpectedException(typeof(ArgumentNullException))]
		public void GetLocalPath_ThrowsArgumentNullException()
		{
			Action action = () => client.GetLocalPath(null);
			action();
		}

		[TestMethod]
		public void GetLocalPath_ReturnsCorrectString()
		{
			var path = @"some\path";
			var expected = String.Format(@"{0}{1}", client.Root, path);
			var actual = client.GetLocalPath(path);

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void WriteToFile_ThrowsArgumentNullException()
		{		 
			Action action = () => client.WriteToFile(null, "");
			action();
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void ReadFromFile_ThrowsArgumentNullException()
		{		
			Action action = () => client.ReadFromFile(null);
			action();
		}

		//TODO: Test full cycle. WriteToFile, ReadFromFile, DeleteFile
		//Not doing because I'm not adding a DeleteFile just for this test.

		[TestMethod]
		[ExpectedException(typeof(DirectoryNotFoundException))]
		public void ReadFromFile_ThrowsDirectoryNotFoundException()
		{
			var path = @"some\path";
			Action action = () => client.ReadFromFile(path);
			action();
		}
	}
}
