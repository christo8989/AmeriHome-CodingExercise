using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmeriHome.Root.Behavior.Clients;
using AmeriHome.Root.Common;

namespace UnitTests.Mocks
{
	//A lot of this kind of mock work can be done with 3rd Party libraries.
	internal class FileClientMock : IFileClient
	{
		public string GetLocalPath(string relativePath)
		{
			throw new NotImplementedException();
		}

		public string ReadFromFile(string relativePath)
		{
			string result = null;
			switch (relativePath)
			{
				case Constants.TABLE_INGREDIENT:
					result = MockData.DATA_INGREDIENTS;
					break;
				case Constants.TABLE_RECIPE:
					result = MockData.DATA_RECIPES;
					break;
				case Constants.TABLE_RECIPE_INGREDIENT:
					result = MockData.DATA_RECIPE_INGREDIENTS;
					break;
			}

			return result;
		}

		public string Root
		{
			get { throw new NotImplementedException(); }
		}

		public void WriteToFile(string relativePath, string text)
		{
			throw new NotImplementedException();
		}
	}
}
