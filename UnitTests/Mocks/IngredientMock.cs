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

		public IFoodItem Item
		{
			get { throw new NotImplementedException(); }
		}
	}
}
