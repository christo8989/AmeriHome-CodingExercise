using System;
using AmeriHome.Root.Data.Domain;

namespace UnitTests.Mocks
{
	internal class FoodItemMock	: IFoodItem
	{
		public bool IsOrganic
		{
			get { return new Random().Next(0, 1) == 0 ? true : false; }
		}

		public bool IsProduce
		{
			get { return new Random().Next(0, 1) == 0 ? true : false; }
		}

		public string Name
		{
			get { return "Mock Item"; }
		}

		public double Price
		{
			get { return 1.50; }
		}
	}
}
