using System;
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
	public class RecipeIngredientRepositoryTests
	{
		private IFileClient client;
		private IRecipeIngredientRepository recipeIngredientRepository;

		[TestInitialize]
		public void Initialize()
		{
			this.client = new FileClientMock();
			this.recipeIngredientRepository = new RecipeIngredientRepository(this.client);
		}


		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void Constructor_ThrowsArgumentNullExceptionOnIngredientRepository()
		{
			Action action = () => new RecipeIngredientRepository(null);
			action();
		}

		[TestMethod]
		public void Get_ReturnsValidList()
		{
			var recipeId = 1;
			var expected = new List<IDataRecipeIngredient> {
				new DataRecipeIngredient {
					RecipeId = recipeId,
					IngredientId = 0,
					Amount = 1,
				},	  
				new DataRecipeIngredient {
					RecipeId = recipeId,
					IngredientId = 3,
					Amount = 4,
				},
				new DataRecipeIngredient {
					RecipeId = recipeId,
					IngredientId = 6,
					Amount = 0.5,
				},
				new DataRecipeIngredient {
					RecipeId = recipeId,
					IngredientId = 7,
					Amount = 0.5,
				},
			};
			var actual = this.recipeIngredientRepository.Get(recipeId);
			Assert.IsNotNull(actual);
			Assert.IsTrue(actual.Any());
			expected.ForEach(m => {
				var item = actual.Single(o => o.IngredientId == m.IngredientId);
				Assert.IsNotNull(item);
				Assert.AreEqual(recipeId, item.RecipeId);
				Assert.AreEqual(m.Amount, item.Amount);
			});
		}

		[TestMethod]
		public void Get_ReturnsEmptyListFromInvalidInput()
		{
			var actual = this.recipeIngredientRepository.Get(-1);
			Assert.IsNotNull(actual);
			Assert.IsFalse(actual.Any());
		}

		[TestMethod]
		public void Get_ReturnsEmptyList()
		{
			this.recipeIngredientRepository = new RecipeIngredientRepository(new FileClientMockFails());
			var actual = this.recipeIngredientRepository.Get(0);
			Assert.IsNotNull(actual);
			Assert.IsFalse(actual.Any());
		}
	}
}
