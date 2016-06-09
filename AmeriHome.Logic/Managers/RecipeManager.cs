using System;
using System.Collections.Generic;
using System.Linq;
using AmeriHome.Logic.Models;
using AmeriHome.Root.Behavior.Manager;
using AmeriHome.Root.Behavior.Repositories;
using AmeriHome.Root.Data.Domain;

namespace AmeriHome.Logic.Managers
{
	public class RecipeManager : IRecipeManager
	{
		private readonly IIngredientRepository ingredientRepository;
		private readonly IRecipeRepository recipeRepository;
		private readonly IRecipeIngredientRepository recipeIngredientRepository;


		public RecipeManager(
			IIngredientRepository ingredientRepository,
			IRecipeRepository recipeRepository,
			IRecipeIngredientRepository recipeIngredientRepository)
		{
			if (ingredientRepository == null)
				throw new ArgumentNullException("ingredientRepository"); //nameof(ingredientRepository)

			if (recipeRepository == null)
				throw new ArgumentNullException("recipeRepository"); //nameof(recipeRepository)

			if (recipeIngredientRepository == null)
				throw new ArgumentNullException("recipeIngredientRepository"); //nameof(recipeIngredientRepository)
			
			this.ingredientRepository = ingredientRepository;
			this.recipeRepository = recipeRepository;
			this.recipeIngredientRepository = recipeIngredientRepository;
		}


		public IRecipe Get(int id)
		{
			// Some of this should be in a stored procedure.
			var dataRecipe = this.recipeRepository.Get(id);
			var dataRecipeIngredients = this.recipeIngredientRepository.Get(id);
			var ingredientIds = dataRecipeIngredients.Select(m => m.IngredientId);
			var dataIngredients = this.ingredientRepository.Get(ingredientIds);

			var result = new Recipe(dataRecipe, dataIngredients, dataRecipeIngredients);
			return result;
		}

		// Not efficient in real life app. Easy for a fake database (this situation).
		// Making multiple IO calls is significantly costly and not scallable.
		public List<IRecipe> GetAll()
		{
			var dataRecipeIds = this.recipeRepository.GetAllIds();
			var result = new List<IRecipe>();
			foreach (var id in dataRecipeIds)
			{
				var recipe = this.Get(id);
				result.Add(recipe);
			}

			return result;
		}
	}
}
