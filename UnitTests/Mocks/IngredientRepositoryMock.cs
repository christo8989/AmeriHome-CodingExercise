using System;
using System.Collections.Generic;
using System.Linq;
using AmeriHome.DataAccess.Models;
using AmeriHome.Root.Behavior.Repositories;
using AmeriHome.Root.Data.Dto;

namespace UnitTests.Mocks
{
	internal class IngredientRepositoryMock	: IIngredientRepository
	{	  	
		private Random rand = new Random();


		public List<IDataIngredient> Get(IEnumerable<int> ids)
		{
			var success = new List<IDataIngredient>();
			for (var i = 0; i < ids.Count(); ++i)
			{
				success.Add(new DataIngredient {
					Id = ids.Single(m => m == i),
					Name = "Mock Ingredient",
					Price = GetRandomPrice(),
					IsOrganic = RandomBoolean(),
					IsProduce = RandomBoolean(),					
				});
			}
			var fail = new List<IDataIngredient>();
			return ids != null && ids.Any() ? success : fail;
		}

		private bool RandomBoolean()
		{
			var result = rand.Next(0, 1) == 0 ? true : false;
			return result;
		}	

		private double GetRandomPrice(int max = 3)
		{
			var result = rand.NextDouble() * max;
			return result;
		}
	}
}
