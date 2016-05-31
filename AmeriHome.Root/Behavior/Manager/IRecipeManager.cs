using System.Collections.Generic;
using AmeriHome.Root.Data.Domain;

namespace AmeriHome.Root.Behavior.Manager
{
	public interface IRecipeManager
	{
		IRecipe Get(int id);
		List<IRecipe> GetAll();
	}
}
