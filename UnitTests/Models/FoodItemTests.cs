using System;
using AmeriHome.Logic.Models;
using AmeriHome.Root.Data.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Models
{
	[TestClass]
	public class FoodItemTests
	{
		private IFoodItem foodItem;
		private string name;
		private double price;

		[TestInitialize]
		public void Initialize()
		{
			this.name = "Test Item";
			this.price = 1.50;
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void Constructor_ThrowsArgumentNullExceptionOnName()
		{
			Action action = () => new FoodItem(null, this.price, false, false);
			action();
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void Constructor_ThrowsArgumentNullExceptionOnNameIsEmpty()
		{
			Action action = () => new FoodItem(String.Empty, this.price, false, false);
			action();
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void Constructor_ThrowsArgumentNullExceptionOnNameIsWhitespace()
		{
			Action action = () => new FoodItem(" ", this.price, false, false);
			action();
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void Constructor_ThrowsArgumentNullExceptionOnPriceIsNegative()
		{
			Action action = () => new FoodItem(this.name, -1, false, false);
			action();
		}

		[TestMethod]
		[ExpectedException(typeof(NullReferenceException))]
		public void Constructor_ThrowsNullExceptionOnDataIngredient()
		{
			Action action = () => new FoodItem(null);
			action();
		}
	}
}
