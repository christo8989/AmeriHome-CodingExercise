using System;
using AmeriHome.DataAccess.Repositories;
using AmeriHome.Root.Behavior.Clients;
using AmeriHome.Root.Behavior.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTests.Mocks;

namespace UnitTests.Repositories
{
	[TestClass]
	public class RecipeIngredientRepositoryTests
	{
		private IFileClient client;
		private IIngredientRepository ingredientRepository;
		private IRecipeRepository recipeRepository;
		private IRecipeIngredientRepository recipeIngredientRepository;

		[TestInitialize]
		public void Initialize()
		{
			this.client = new FileClientMock();
			this.recipeIngredientRepository = new RecipeIngredientRepositoryMock(this.client);
		}

		//TODO:Get_CorrectObjectReturned
	}
}
