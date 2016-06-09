using System;
using AmeriHome.Root.Data.Domain;

namespace UnitTests.Mocks
{
	internal class IngredientMock : IIngredient
	{
		public double Amount
		{
			get { throw new NotImplementedException(); }
		}

		public bool IsOrganic
		{
			get { throw new NotImplementedException(); }
		}

		public bool IsProduce
		{
			get { throw new NotImplementedException(); }
		}

		public string Name
		{
			get { throw new NotImplementedException(); }
		}

		public double Price
		{
			get { throw new NotImplementedException(); }
		}
	}
}
