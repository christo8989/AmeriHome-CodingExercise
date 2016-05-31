using System;
using System.Collections.Generic;
using AmeriHome.Root.Behavior.Clients;
using AmeriHome.Root.Behavior.Repositories;
using AmeriHome.Root.Data.Dto;

namespace UnitTests.Mocks
{
	internal class RecipeIngredientRepositoryMock : IRecipeIngredientRepository
	{			
		public List<IDataRecipeIngredient> Get(int recipeId)
		{
			throw new NotImplementedException();
		}
	}
}
