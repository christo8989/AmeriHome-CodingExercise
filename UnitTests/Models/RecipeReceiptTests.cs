using System;
using System.Collections.Generic;
using System.Text;
using AmeriHome.Logic.Models;
using AmeriHome.Models;
using AmeriHome.Root.Common;
using AmeriHome.Root.Common.Utilities;
using AmeriHome.Root.Data.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTests.Mocks;

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
			this.recipe = new RecipeMock();
			this.recipeReceipt = new RecipeReceipt(this.recipe);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void Constructor_ThrowsArgumentNullException()
		{
			Action action = () => new RecipeReceipt(null);
			action();
		}

		[TestMethod]
		public void SalesTax_ReturnsCurrencyString()
		{
			var expected = this.recipe.SalesTax.ToString("C");
			var actual = this.recipeReceipt.SalesTax;
			Assert.IsTrue(StringAssert.Equals(expected, actual));
		}

		[TestMethod]
		public void WellnessDiscount_ReturnsCurrencyString()
		{
			var expected = this.recipe.WellnessDiscount.ToString("C");
			var actual = this.recipeReceipt.WellnessDiscount;
			Assert.IsTrue(StringAssert.Equals(expected, actual));
		}

		[TestMethod]
		public void TotalCost_ReturnsCurrencyString()
		{
			var expected = this.recipe.TotalCost.ToString("C");
			var actual = this.recipeReceipt.TotalCost;
			Assert.IsTrue(StringAssert.Equals(expected, actual));
		}

		[TestMethod]
		public void ToString_ReturnsOutputString()
		{
			var str = new StringBuilder();
			str.Append(String.Format("{0}\n\n", this.recipe.Name));

			#if DEBUG
			str.Append("\t\tDEBUG MODE ONLY\n\n");
			foreach (var ingredient in this.recipe.Ingredients)
			{
				str.Append(String.Format("\t\t{0}\n", ingredient.ToString()));
				str.Append(String.Format("\t\tCost: {0}\n", ingredient.Price));
				str.Append(String.Format("\t\tTaxed: {0}, Organic: {1}\n\n", !ingredient.IsProduce, ingredient.IsOrganic));
			}
			#endif

			str.Append(String.Format("\tTax = {0}\n", this.recipe.SalesTax.ToString("C")));
			str.Append(String.Format("\tDiscount = ({0})\n", this.recipe.WellnessDiscount.ToString("C")));
			str.Append(String.Format("\tTotal = {0}\n", this.recipe.TotalCost.ToString("C")));
			str.Append("\n");
			var expected = str.ToString();

			var actual = this.recipeReceipt.ToString();
			Assert.IsTrue(StringAssert.Equals(expected, actual));
		}
	}
}
