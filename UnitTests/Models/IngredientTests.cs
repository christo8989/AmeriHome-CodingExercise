using System;
using AmeriHome.Logic.Models;
using AmeriHome.Root.Data.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTests.Mocks;

namespace UnitTests.Models
{
	[TestClass]
	public class IngredientTests
	{
		private IIngredient ingredient;
		private double amount;
		private IFoodItem foodItem;

		[TestInitialize]
		public void Initialize()
		{
			this.amount = 1;
			this.foodItem = new FoodItemMock();
			this.ingredient = new Ingredient(this.amount, this.foodItem);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void Constructor_ThrowsArgumentExceptionOnNegativeAmount()
		{
			Action action = () => new Ingredient(-1, this.foodItem);
			action();
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void Constructor_ThrowsArgumentNullExceptionOnFoodItem()
		{
			Action action = () => new Ingredient(this.amount, null);
			action();
		}

		[TestMethod]
		public void ToString_ReturnsCorrectStringNaturalNumber()
		{
			this.amount = 1;
			this.ingredient = new Ingredient(this.amount, this.foodItem);
			var expected = String.Format("1 - {0}", this.ingredient.Name);
			var actual = this.ingredient.ToString();
			Assert.IsTrue(StringAssert.Equals(expected, actual));
		}

		[TestMethod]
		public void ToString_ReturnsCorrectStringEasyFraction()
		{
			this.amount = 0.75;
			this.ingredient = new Ingredient(this.amount, this.foodItem);
			var expected = String.Format("3/4 - {0}", this.ingredient.Name);
			var actual = this.ingredient.ToString();
			Assert.IsTrue(StringAssert.Equals(expected, actual));
		}

		[TestMethod]
		public void ToString_ReturnsCorrectStringHardFraction()
		{
			this.amount = 0.115;
			this.ingredient = new Ingredient(this.amount, this.foodItem);
			var expected = String.Format("23/200 - {0}", this.ingredient.Name);
			var actual = this.ingredient.ToString();
			Assert.IsTrue(StringAssert.Equals(expected, actual));
		}

		[TestMethod]
		public void ToString_ReturnsCorrectStringAnotherHardFraction()
		{
			this.amount = 2.115;
			this.ingredient = new Ingredient(this.amount, this.foodItem);
			var expected = String.Format("2 23/200 - {0}", this.ingredient.Name);
			var actual = this.ingredient.ToString();
			Assert.IsTrue(StringAssert.Equals(expected, actual));
		}
	}
}
