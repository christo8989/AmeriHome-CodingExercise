using System.Collections.Generic;

namespace AmeriHome.Root.Data.Domain
{
	public interface IRecipe
	{
		List<IIngredient> Ingredients { get; }
		string Name { get; }
		double SalesTax { get; }
		double TotalCost { get; }
		double WellnessDiscount { get; }
	}
}
