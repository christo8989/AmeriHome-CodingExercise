using System;
using System.Collections.Generic;
using AmeriHome.Root.Behavior.Repositories;
using AmeriHome.Root.Data.Dto;

namespace AmeriHome.DataAccess.Repositories
{
	public class IngredientRepository : IIngredientRepository
	{
		public List<IDataIngredient> Get(IEnumerable<int> ids)
		{
			//if ids is null or empty, throw error.
			throw new NotImplementedException();
		}
	}
}
