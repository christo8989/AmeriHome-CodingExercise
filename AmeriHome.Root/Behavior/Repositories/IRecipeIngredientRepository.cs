using System.Collections.Generic;
using AmeriHome.Root.Data.Dto;

namespace AmeriHome.Root.Behavior.Repositories
{
	public interface IRecipeIngredientRepository
	{
		List<IDataRecipeIngredient> Get(int recipeId);
	}
}
