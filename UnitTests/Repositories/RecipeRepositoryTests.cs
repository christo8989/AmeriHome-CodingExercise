using System;
using System.Collections;
using System.Collections.Generic;
using AmeriHome.DataAccess.Models;
using AmeriHome.DataAccess.Repositories;
using AmeriHome.Root.Behavior.Clients;
using AmeriHome.Root.Behavior.Repositories;
using AmeriHome.Root.Data.Dto;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTests.Mocks;

namespace UnitTests.Repositories
{
	[TestClass]
	public class RecipeRepositoryTests
	{		   
		private IFileClient client;
		private IRecipeRepository recipeRepository;

		[TestInitialize]
		public void Initialize()
		{
			this.client = new FileClientMock();
			this.recipeRepository = new RecipeRepository(this.client);
		}

		//Do you implement Maybe instead of null?
		[TestMethod]
		public void Get_ReturnsNullIfIdDoesNotExist()
		{
			var recipeId = 1000;
			var actual = this.recipeRepository.Get(recipeId);

			Assert.IsNull(actual);
		}

		[TestMethod]
		public void Get_ReturnIngredientsForRecipe2()
		{
			var recipeId = 0;
			var expected = new DataRecipe {
				Id = 0,
				Name = "Recipe 1",
			};

			var actual = this.recipeRepository.Get(recipeId);
			var result = expected.Id == actual.Id
				&& expected.Name == actual.Name;
			Assert.IsTrue(result);
		}

		//TODO: GetAll_ReturnsAllValues
		//TODO: GetAllIds_ReturnsAllIds
		//TODO: GetAll_ThrowExceptionIfNullIsReturned
	}
}
