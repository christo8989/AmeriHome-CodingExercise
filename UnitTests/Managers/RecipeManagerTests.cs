using System;
using AmeriHome.Logic.Managers;
using AmeriHome.Root.Behavior.Clients;
using AmeriHome.Root.Behavior.Manager;
using AmeriHome.Root.Behavior.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTests.Mocks;

namespace UnitTests.Managers
{
	[TestClass]
	public class RecipeManagerTests
	{
		//private IFileClient client = new FileClientMock(); //Leave out for now.
		private IIngredientRepository ingredientRepository;
		private IRecipeRepository recipeRepository;
		private IRecipeIngredientRepository recipeIngredientRepository;
		private IRecipeManager recipeManager;

		[TestInitialize]
		public void Initialize()
		{
			this.ingredientRepository = new IngredientRepositoryMock();
			this.recipeRepository = new RecipeRepositoryMock();
			this.recipeIngredientRepository = new RecipeIngredientRepositoryMock();
			this.recipeManager = new RecipeManager(
					this.ingredientRepository,
					this.recipeRepository,
					this.recipeIngredientRepository
				);
		}

		//TODO: GetAll_ReturnsAllRecipes //which is all the data
		//TODO: Get_IdShouldReturnNull
	}
}
