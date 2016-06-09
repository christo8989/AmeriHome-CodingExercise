using System;
using AmeriHome.Data;
using AmeriHome.DataAccess.Clients;
using AmeriHome.DataAccess.Repositories;
using AmeriHome.Logic.Managers;
using AmeriHome.Models;

namespace AmeriHome
{
	class Program
	{
		public static void Main(string[] args)
		{
			//Setup Database
			var mj = new MakeJsonFiles(new FileClient());
			mj.CreateAllTables();

			//Poor Man DI
			var ingredientRepository = new IngredientRepository(new FileClient());
			var recipeRepository = new RecipeRepository(new FileClient());
			var recipeIngredientRespository = new RecipeIngredientRepository(new FileClient());
			var recipeManager = new RecipeManager(
				ingredientRepository,
				recipeRepository,
				recipeIngredientRespository
			);

			//Start Program
			var recipes = recipeManager.GetAll();
			foreach (var recipe in recipes)
			{
				var receipt = new RecipeReceipt(recipe);
				Console.WriteLine(receipt.ToString());
			}
		}
	}
}
