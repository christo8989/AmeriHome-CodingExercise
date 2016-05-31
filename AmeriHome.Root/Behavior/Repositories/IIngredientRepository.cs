using System.Collections.Generic;
using AmeriHome.Root.Data.Dto;

namespace AmeriHome.Root.Behavior.Repositories
{
	public interface IIngredientRepository
	{
		List<IDataIngredient> Get(IEnumerable<int> ids);
	}
}
