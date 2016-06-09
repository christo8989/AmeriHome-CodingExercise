using System;
using AmeriHome.Root.Data.Domain;

namespace AmeriHome.Logic.Models
{
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
			if (amount < 0)
				throw new ArgumentException("'amount' cannot be a negative number.", "amount"); //nameof(amount)

			if (foodItem == null)
				throw new ArgumentNullException("foodItem"); //nameof(foodItem)

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
			var integer = (int) value;
			var real = value - integer;
			if (real == 0)
			{
				result = integer.ToString();
			}
			else
			{
				var i = 0;
				do
				{
					i++;
					real *= 10;
				} while ((real % 1) > 0.0001);

				var multiple = (uint) Math.Pow(10, i);
				var gcd = GCD(multiple, (uint) real);
				var numerator = (int)(real / gcd);
				var denominator = (int)(multiple / gcd);
				result = integer > 0 
					? String.Format("{0} {1}/{2}", integer, numerator, denominator)
					: String.Format("{0}/{1}", numerator, denominator);
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
