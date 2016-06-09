using System;
using System.Collections.Generic;
using System.Linq;
using AmeriHome.Root.Common;
using AmeriHome.Root.Common.Utilities;
using AmeriHome.Root.Data.Domain;
using AmeriHome.Root.Data.Dto;

namespace AmeriHome.Logic.Models
{
	public class Recipe : IRecipe
	{																
		private readonly string name;
		public string Name
		{
			get { return this.name; }
		}

		private readonly List<IIngredient> ingredients;
		public List<IIngredient> Ingredients
		{
			get { return this.ingredients; }
		}

		private double salesTax;
		public double SalesTax
		{
			get
			{
				if (this.salesTax == default(double))
				{
					this.salesTax = this.CalculateSalesTax();
				}
				return this.salesTax;
			}
		}

		private double wellnessDiscount;
		public double WellnessDiscount
		{
			get
			{
				if (this.wellnessDiscount == default(double))
				{
					this.wellnessDiscount = this.CalculateWellnessDiscount();
				}
				return this.wellnessDiscount;
			}
		}

		private double totalCost;
		public double TotalCost
		{
			get
			{
				if (this.totalCost == default(double))
				{
					this.totalCost = this.CalculateTotalCost();
				}
				return this.totalCost;
			}
		}


		public Recipe(string name, List<IIngredient> ingredients)
		{
			if (name == null)
				throw new ArgumentNullException("name"); //nameof(name)	   

			if (String.IsNullOrWhiteSpace(name))
				throw new ArgumentException("'name' is empty or whitespace.", "name");

			if (ingredients == null)
				throw new ArgumentNullException("ingredients"); //nameof(ingredients)

			if (!ingredients.Any())
				throw new ArgumentException("'ingredients' is empty.", "ingredients");

			if (!(ingredients.Count > 1))
				throw new ArgumentException("A recipe must contain more than 1 ingredient.", "ingredients");

			this.name = name;
			this.ingredients = ingredients;
		}

		public Recipe(
			IDataRecipe recipe,
			List<IDataIngredient> ingredients,
			List<IDataRecipeIngredient> recipeIngredients)
		{
			if (recipe == null)
				throw new ArgumentNullException("recipe"); //nameof(recipe)

			if (ingredients == null)
				throw new ArgumentNullException("ingredients"); //nameof(ingredients)

			if (!ingredients.Any())
				throw new ArgumentException("'ingredients' is empty.", "ingredients");

			if (recipeIngredients == null)
				throw new ArgumentNullException("recipeIngredients"); //nameof(recipeIngredients) 

			if (!recipeIngredients.Any())
				throw new ArgumentException("'recipeIngredients' is empty.", "recipeIngredients");

			// Build recipe list.
			var recipeItems = new List<IIngredient>();
			foreach (var recipeIngredient in recipeIngredients)
			{
				var dataIngredient = ingredients.Single(m => m.Id == recipeIngredient.IngredientId); //I'm being lazy...
				var recipeItem = new Ingredient(
					amount: recipeIngredient.Amount,
					foodItem: new FoodItem(dataIngredient)
				);
				recipeItems.Add(recipeItem);
			}

			this.name = recipe.Name;
			this.ingredients = recipeItems;
		}

		private double CalculateSalesTax()
		{
			var result = 0.0;
			foreach (var ingredient in this.Ingredients)
			{
				if (!ingredient.Item.IsProduce)
				{
					result += ingredient.Amount * ingredient.Item.Price * Constants.SALES_TAX;
				}
			}
			result = CentsToCeiling(result, Constants.SALES_TAX_INTERVAL);
			return result;
		}

		private double CalculateWellnessDiscount()
		{
			var result = 0.0;
			foreach (var ingredient in this.Ingredients)
			{
				if (ingredient.Item.IsOrganic)
				{
					result += ingredient.Amount * ingredient.Item.Price * Constants.WELLNESS_DISCOUNT;
				}
			}
			result = CentsToCeiling(result, Constants.WELLNESS_DISCOUNT_INTERVAL);
			return result;
		}

		private double CalculateTotalCost()
		{
			var result = 0.0;
			foreach (var ingredient in this.Ingredients)
			{
				result += ingredient.Amount * ingredient.Item.Price;
			}

			result += this.SalesTax;
			result -= this.WellnessDiscount;
			return result;
		}

		//TODO: 3.54 should be 3.56 or 3.57?
		// Basically, do I just round the cents or the total tax amount?
		private double CentsToCeiling(double value, double interval)
		{
			var dollars = (int) value;
			var cents = value - dollars;
			cents = MathExtension.ToCeiling(cents, interval);
			var result = dollars + cents;
			return result;
		}
	}
}
