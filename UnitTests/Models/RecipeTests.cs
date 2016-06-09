using System;
using System.Collections.Generic;
using AmeriHome.DataAccess.Models;
using AmeriHome.Logic.Models;
using AmeriHome.Root.Common;
using AmeriHome.Root.Common.Utilities;
using AmeriHome.Root.Data.Domain;
using AmeriHome.Root.Data.Dto;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTests.Mocks;

namespace UnitTests.Models
{
	[TestClass]
	public class RecipeTests
	{
		private IRecipe recipe;
		private string name;
		private List<IIngredient> ingredients;

		[TestInitialize]
		public void Initialize()
		{
			this.ingredients = new List<IIngredient> {
				new Ingredient(1, new FoodItem(
					"Test Item 1",
					1.50,
					true,
					true)),	 
				new Ingredient(0.75, new FoodItem(
					"Test Item 2",
					2,
					false,
					true)),
				new Ingredient(4, new FoodItem(
					"Test Item 3",
					0.30,
					true,
					false)),
				new Ingredient(1, new FoodItem(
					"Test Item 4",
					0.15,
					false,
					false)),
			};
			this.name = "Test Recipe";
			this.recipe = new Recipe(this.name, this.ingredients);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void Constructor_ThrowsArgumentNullExceptionOnName()
		{
			Action action = () => new Recipe(null, this.ingredients);
			action();
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void Constructor_ThrowsArgumentExceptionOnNameEmtpy()
		{
			Action action = () => new Recipe(String.Empty, this.ingredients);
			action();
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void Constructor_ThrowsArgumentExceptionOnNameWhitespace()
		{
			Action action = () => new Recipe(" ", this.ingredients);
			action();
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void Constructor_ThrowsArgumentNullExceptionOnIngredients()
		{
			Action action = () => new Recipe(this.name, null);
			action();
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void Constructor_ThrowsArgumentExceptionOnIngredientsEmpty()
		{
			Action action = () => new Recipe(this.name, new List<IIngredient>());
			action();
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void Constructor_ThrowsArgumentExceptionOnOneIngredient()
		{
			Action action = () => new Recipe(this.name, new List<IIngredient> { new IngredientMock() });
			action();
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void Constructor_ThrowsArgumentNullExceptionOnDataRecipe()
		{
			IDataRecipe recipe = null;
			List<IDataIngredient> ingredients = new List<IDataIngredient> { new DataIngredient() };
			List<IDataRecipeIngredient> recipeIngredients = new List<IDataRecipeIngredient> { new DataRecipeIngredient() };
			Action action = () => new Recipe(recipe, ingredients, recipeIngredients);
			action();
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void Constructor_ThrowsArgumentNullExceptionOnDataIngredients()
		{
			IDataRecipe recipe = new DataRecipe();
			List<IDataIngredient> ingredients = null;
			List<IDataRecipeIngredient> recipeIngredients = new List<IDataRecipeIngredient> { new DataRecipeIngredient() };
			Action action = () => new Recipe(recipe, ingredients, recipeIngredients);
			action();
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void Constructor_ThrowsArgumentExceptionOnDataIngredients()
		{
			IDataRecipe recipe = new DataRecipe();
			List<IDataIngredient> ingredients = new List<IDataIngredient>();
			List<IDataRecipeIngredient> recipeIngredients = new List<IDataRecipeIngredient> { new DataRecipeIngredient() };
			Action action = () => new Recipe(recipe, ingredients, recipeIngredients);
			action();
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void Constructor_ThrowsArgumentNullExceptionOnDataRecipeIngredient()
		{
			IDataRecipe recipe = new DataRecipe();
			List<IDataIngredient> ingredients = new List<IDataIngredient> { new DataIngredient() };
			List<IDataRecipeIngredient> recipeIngredients = null;
			Action action = () => new Recipe(recipe, ingredients, recipeIngredients);
			action();
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void Constructor_ThrowsArgumentExceptionOnDataRecipeIngredient()
		{
			IDataRecipe recipe = new DataRecipe();
			List<IDataIngredient> ingredients = new List<IDataIngredient> { new DataIngredient() };
			List<IDataRecipeIngredient> recipeIngredients = new List<IDataRecipeIngredient>();
			Action action = () => new Recipe(recipe, ingredients, recipeIngredients);
			action();
		}

		//Constructor with DataRecipe, DataIngredients, DataRecipeIngredients
		// is tested in the RecipeManagerTests.


		[TestMethod]
		public void SalesTax_ReturnsCorrectAmount()
		{
			var expected = 0.0;
			foreach (var ingredient in this.recipe.Ingredients)
			{
				if (!ingredient.IsProduce)
				{
					expected += ingredient.Amount * ingredient.Price * Constants.SALES_TAX;
				}
			}
			var dollars = (int) expected;
			var cents = expected - dollars;
			cents = MathExtension.ToCeiling(cents, Constants.SALES_TAX_INTERVAL);
			expected = dollars + cents;

			var actual = recipe.SalesTax;
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void WellnessDiscount_ReturnsCorrectAmount()
		{
			var expected = 0.0;
			foreach (var ingredient in this.recipe.Ingredients)
			{
				if (ingredient.IsOrganic)
				{
					expected += ingredient.Amount * ingredient.Price * Constants.WELLNESS_DISCOUNT;
				}
			}
			var dollars = (int) expected;
			var cents = expected - dollars;
			cents = MathExtension.ToCeiling(cents, Constants.WELLNESS_DISCOUNT_INTERVAL);
			expected = dollars + cents;

			var actual = recipe.WellnessDiscount;
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void TotalCost_ReturnsCorrectAmount()
		{
			var expected = 0.0;
			foreach (var ingredient in this.recipe.Ingredients)
			{
				expected += ingredient.Amount * ingredient.Price;
			}
			expected += this.recipe.SalesTax;
			expected -= this.recipe.WellnessDiscount;

			var actual = recipe.TotalCost;
			Assert.AreEqual(expected, actual);
		}
	}
}
