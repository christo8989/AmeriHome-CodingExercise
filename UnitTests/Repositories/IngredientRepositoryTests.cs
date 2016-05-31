using System;
using System.Collections;
using System.Collections.Generic;
using AmeriHome.DataAccess.Models;
using AmeriHome.DataAccess.Repositories;
using AmeriHome.Root.Behavior.Clients;
using AmeriHome.Root.Behavior.Repositories;
using AmeriHome.Root.Common;
using AmeriHome.Root.Data.Dto;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTests.Mocks;

namespace UnitTests.Repositories
{
	[TestClass]
	public class IngredientRepositoryTests
	{
		private IFileClient client;
		private IIngredientRepository ingredientRepository;

		[TestInitialize]
		public void Initialize()
		{
			this.client = new FileClientMock();
			this.ingredientRepository = new IngredientRepository(this.client);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void Get_ThrowsArgumentNullException()
		{
			Action action = () => this.ingredientRepository.Get(null);
			action();
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void Get_ThrowsArgumentException()
		{
			Action action = () => this.ingredientRepository.Get(new List<int>());
			action();
		}

		[TestMethod]
		public void Get_ReturnIngredientsForRecipe2()
		{
			var recipeId = new List<int> { 0, 2 };
			var expected = new List<IDataIngredient> {
				new DataIngredient {
					Id = 0,
					Name = "Organic Garlic",
					Price = 0.67,
					IsProduce = true,
					IsOrganic = true
				},	
				new DataIngredient {
					Id = 2,
					Name = "Corn",
					Price = 0.87,
					IsProduce = true,
					IsOrganic = false
				},	  
			};

			var actual = this.ingredientRepository.Get(recipeId);
			CollectionAssert.AreEqual(expected, actual, new DataIngredientComparer());
		}
	}

	internal class DataIngredientComparer : IComparer
	{
		public int Compare(object xObj, object yObj)
		{
			var x = (IDataIngredient) xObj;
			var y = (IDataIngredient) yObj;
			var result = x.Id == y.Id
				&& x.Name == y.Name
				&& x.Price == y.Price //I think this is okay in this case...
				&& x.IsProduce == y.IsProduce
				&& x.IsOrganic == y.IsOrganic;
			return result ? 0 : 1;
		}
	}
}
