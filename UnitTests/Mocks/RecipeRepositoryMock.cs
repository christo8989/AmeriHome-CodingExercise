using System;
using System.Collections.Generic;
using AmeriHome.DataAccess.Models;
using AmeriHome.Root.Behavior.Repositories;
using AmeriHome.Root.Data.Dto;

namespace UnitTests.Mocks
{
	internal class RecipeRepositoryMock	: IRecipeRepository
	{	   	 
		public IDataRecipe Get(int id)
		{
			var success = new DataRecipe {
				Id = id,
				Name = "Mock Data Recipe",
			};
			IDataRecipe fail = null;
			return id < 0 ? fail : success;
		}

		public List<IDataRecipe> GetAll()
		{
			throw new NotImplementedException();
		}

		public List<int> GetAllIds()
		{
			return new List<int> { 0, 1, 2, 3 };
		}
	}
}
