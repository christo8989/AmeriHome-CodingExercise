using System.Collections.Generic;
using AmeriHome.Root.Data.Domain;

namespace UnitTests.Mocks
{
	internal class RecipeMock : IRecipe
	{
		public List<IIngredient> Ingredients
		{
			get { return new List<IIngredient>(); }
		}

		public string Name
		{
			get { return "Mock Recipe"; }
		}

		public double SalesTax
		{
			get { return 0.21; }
		}

		public double TotalCost
		{
			get { return 3.57; }
		}

		public double WellnessDiscount
		{
			get { return 0.13; }
		}
	}
}
