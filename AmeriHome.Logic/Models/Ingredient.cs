using System;
using AmeriHome.Root.Data.Domain;

namespace AmeriHome.Logic.Models
{
	// Doesn't need to be immutable but why not given the requirements.
	public class Ingredient : IIngredient
	{
		private readonly double amount;
		public double Amount
		{
			get { return this.amount; }
		}
		//TODO: Decorator pattern for this one.
		//http://www.codeproject.com/Articles/479635/UnderstandingplusandplusImplementingplusDecoratorp
		private readonly IFoodItem item;
		public IFoodItem Item
		{
			get { return this.item; }
		}


		public Ingredient(double amount, IFoodItem foodItem)
		{
			//throw if foodItem is null. throw if amount is negative.
			this.amount = amount;
			this.item = foodItem;
		}


		public override string ToString()
		{
			return String.Format("{0} - {1}", this.ToFraction(Amount), this.Item.Name);
		}

		#region Fraction Helpers
		//Just for fun. Should be in another class.
		private string ToFraction(double value)
		{
			var result = "";
			if ((value % 1) == 0)
			{
				result = ((int) value).ToString();
			}
			else
			{
				var i = 0;
				do
				{
					i++;
					value *= 10;
				} while ((value % 1) != 0);

				var multiple = (uint) Math.Pow(10, i);
				var gcd = GCD(multiple, (uint) value);
				var numerator = (int)(value / gcd);
				var denominator = (int)(multiple / gcd);
				result = String.Format("{0}/{1}", numerator, denominator);
			}

			return result;
		}

		private uint GCD(uint larger, uint smaller)
		{
			if (larger < smaller)
			{
				var temp = larger;
				larger = smaller;
				smaller = larger;
			}

			while (true)
			{
				uint remainder = larger % smaller;
				if (remainder == 0)
				{
					return smaller;
				}

				larger = smaller;
				smaller = remainder;
			}
		}
		#endregion
	}
}
