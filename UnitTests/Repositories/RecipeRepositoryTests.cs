using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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


		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void Constructor_ThrowsArgumentNullExceptionOnIngredientRepository()
		{
			Action action = () => new RecipeRepository(null);
			action();
		}

		[TestMethod]
		public void Get_ReturnsNullIfIdDoesNotExist()
		{
			var recipeId = -1;
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

		[TestMethod]
		public void GetAllIds_ReturnsAllIds()
		{
			var expected = new List<int> { 0, 1, 2 };
			var actual = this.recipeRepository.GetAllIds();
			Assert.IsNotNull(actual);
			Assert.IsTrue(actual.Any());
			expected.ForEach(m => CollectionAssert.Contains(actual, m));
		}

		[TestMethod]
		public void GetAll_ReturnsAllRecipes()
		{
			var actual = this.recipeRepository.GetAll();
			Assert.IsNotNull(actual);
			Assert.IsTrue(actual.Any());
			CollectionAssert.AllItemsAreNotNull(actual);
			CollectionAssert.AllItemsAreUnique(actual);
		}

		[TestMethod]
		public void GetAll_ReturnsEmptyList()
		{
			this.recipeRepository = new RecipeRepository(new FileClientMockFails());
			var actual = this.recipeRepository.GetAll();
			Assert.IsNotNull(actual);
			Assert.IsFalse(actual.Any());
		}
	}
}
