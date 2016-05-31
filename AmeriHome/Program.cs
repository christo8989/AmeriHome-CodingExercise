using System;
using AmeriHome.DataAccess.Repositories;
using AmeriHome.Logic.Managers;

namespace AmeriHome
{
	class Program
	{
		public static void Main(string[] args)
		{
			//Poor Man DI
			var ingredientRepository = new IngredientRepository();
			var recipeRepository = new RecipeRepository();
			var recipeIngredientRespository = new RecipeIngredientRepository();
			var recipeManager = new RecipeManager(
				ingredientRepository,
				recipeRepository,
				recipeIngredientRespository
			);

			/*
			var receipts = recipeManager.GetAll();
			foreach (var receipt in receipts)
			{
				Console.WriteLine(receipt.ToString());
			}
			 * */

			Console.WriteLine("\n\n---------- END ----------");
			while (true) { }
		}
	}
}
