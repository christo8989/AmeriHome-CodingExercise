using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmeriHome.Root.Common.Utilities;
using AmeriHome.Root.Data.Domain;

namespace AmeriHome.Logic.Models
{
	// Doesn't need to be immutable but why not given the requirements.
	public class Recipe : IRecipe
	{
		// Not labeled as Input so I'm storing it here for ease.
		public const double SALES_TAX = 0.086;
		public const double SALES_TAX_INTERVAL = 0.07;
		public const double WELLNESS_DISCOUNT = 0.05;
		public const double WELLNESS_DISCOUNT_INTERVAL = 0.01;

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
					this.wellnessDiscount = this.CalculateSalesTax();
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
			//throw if recipe is null or empty.
			//throw if ingredients are null or empty.
			this.name = name;
			this.ingredients = ingredients;
		}

		private double CalculateSalesTax()
		{
			var result = 0.0;
			foreach (var ingredient in this.Ingredients)
			{
				if (!ingredient.Item.IsProduce)
				{
					result += ingredient.Item.Price * SALES_TAX;
				}
			}
			result = CentsToCeiling(result, SALES_TAX_INTERVAL);
			return result;
		}

		private double CalculateWellnessDiscount()
		{
			var result = 0.0;
			foreach (var ingredient in this.Ingredients)
			{
				if (ingredient.Item.IsOrganic)
				{
					result += ingredient.Item.Price * WELLNESS_DISCOUNT;
				}
			}
			result = CentsToCeiling(result, WELLNESS_DISCOUNT_INTERVAL);
			return result;
		}

		private double CalculateTotalCost()
		{
			var result = 0.0;
			foreach (var ingredient in this.Ingredients)
			{
				result += ingredient.Item.Price;
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
