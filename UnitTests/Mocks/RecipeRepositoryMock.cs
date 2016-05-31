using System;
using System.Collections.Generic;
using AmeriHome.Root.Behavior.Clients;
using AmeriHome.Root.Behavior.Repositories;
using AmeriHome.Root.Data.Dto;

namespace UnitTests.Mocks
{
	internal class RecipeRepositoryMock	: IRecipeRepository
	{	   	 
		public IDataRecipe Get(int id)
		{
			throw new NotImplementedException();
		}

		public List<IDataRecipe> GetAll()
		{
			throw new NotImplementedException();
		}

		public List<int> GetAllIds()
		{
			throw new NotImplementedException();
		}
	}
}
