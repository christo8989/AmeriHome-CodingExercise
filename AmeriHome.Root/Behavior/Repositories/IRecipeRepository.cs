using System.Collections.Generic;
using AmeriHome.Root.Data.Dto;

namespace AmeriHome.Root.Behavior.Repositories
{
	public interface IRecipeRepository
	{
		IDataRecipe Get(int id);
		List<int> GetAllIds();
	}
}
