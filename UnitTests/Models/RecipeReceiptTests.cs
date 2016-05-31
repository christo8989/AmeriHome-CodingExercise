using System;
using System.Collections.Generic;
using AmeriHome.Logic.Models;
using AmeriHome.Models;
using AmeriHome.Root.Data.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Models
{
	[TestClass]
	public class RecipeReceiptTests
	{
		private IRecipe recipe;
		private IRecipeReceipt recipeReceipt;

		[TestInitialize]
		public void Initialize()
		{
			var ingredients = new List<IIngredient> {
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
			this.recipe = new Recipe("Test Recipe", ingredients);
			this.recipeReceipt = new RecipeReceipt(this.recipe);
		}

		///THESE TESTS ARE IMPORTANT!!!!
		//TODO: SalesTax_ReturnsCorrectAmount
		//TODO: WellnessDiscount_ReturnsCorrectAmount
		//TODO: TotalCost_ReturnsCorrectAmount
		//TODO: ToString_ReturnsCorrectString
	}
}
