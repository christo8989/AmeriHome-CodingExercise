using System;
using System.Collections.Generic;
using AmeriHome.DataAccess.Models;
using AmeriHome.Root.Behavior.Repositories;
using AmeriHome.Root.Common.Utilities;
using AmeriHome.Root.Data.Dto;

namespace UnitTests.Mocks
{
	internal class RecipeIngredientRepositoryMock : IRecipeIngredientRepository
	{
		private Random rand = new Random();


		public List<IDataRecipeIngredient> Get(int recipeId)
		{
			var success = new List<IDataRecipeIngredient>();
			for (var i = 0; i < 5; ++i)			
			{
				success.Add(new DataRecipeIngredient {
					RecipeId = recipeId,
					IngredientId = i,
					Amount = GetRandomAmount(),
				});
			}
			var fail = new List<IDataRecipeIngredient>();
			return recipeId < 0 ? fail : success;
		}

		private double GetRandomAmount(int max = 3)
		{
			var result = rand.NextDouble() * max;
			result = MathExtension.ToCeiling(result, 0.05);
			return result;
		}
	}
}
