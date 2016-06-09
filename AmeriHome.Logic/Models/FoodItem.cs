using System;
using AmeriHome.Root.Data.Domain;
using AmeriHome.Root.Data.Dto;

namespace AmeriHome.Logic.Models
{
	public class FoodItem : IFoodItem
	{
		private readonly string name;
		public string Name 
		{
			get { return this.name; }
		}

		private readonly double price;
		public double Price
		{
			get { return this.price; }
		}

		private readonly bool isProduce;
		public bool IsProduce
		{
			get { return this.isProduce; }
		}

		private readonly bool isOrganic;
		public bool IsOrganic
		{
			get { return this.isOrganic; }
		}


		public FoodItem(string name, double price, bool isProduce, bool isOrganic)
		{
			if (name == null)
				throw new ArgumentNullException("name"); //nameof(name)

			if (String.IsNullOrWhiteSpace(name))
				throw new ArgumentException("'name' cannot be empty or whitespace.", "name");

			if (price < 0)
				throw new ArgumentException("'price' cannot be negative.", "price"); //nameof(price)

			this.name = name;
			this.price = price;
			this.isProduce = isProduce;
			this.isOrganic = isOrganic;
		}

		public FoodItem(IDataIngredient ingredient)
			: this(ingredient.Name, ingredient.Price, ingredient.IsProduce, ingredient.IsOrganic) { }

		//Can't find where to upgrade to C# 5... :/
		//public FoodItem(IDataIngredient ingredient)
		//  : this(ingredient?.Name, ingredient?.Price, ingredient?.IsProduce, ingredient?.IsOrganic) { }
	}
}
