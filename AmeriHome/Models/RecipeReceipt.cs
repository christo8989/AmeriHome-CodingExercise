using System;
using System.Globalization;
using System.Text;
using AmeriHome.Root.Data.Domain;

namespace AmeriHome.Models
{
	public class RecipeReceipt : IRecipeReceipt
	{
		private readonly IRecipe recipe;
		public string SalesTax
		{
			get
			{
				var salesTax = this.recipe.SalesTax;
				return salesTax.ToString("C", CultureInfo.CreateSpecificCulture("en-US"));
			}
		}
		public string WellnessDiscount
		{
			get
			{
				var wellnessDiscount = this.recipe.WellnessDiscount;
				return wellnessDiscount.ToString("C", CultureInfo.CreateSpecificCulture("en-US"));
			}
		}
		public string TotalCost
		{
			get
			{
				var totalCost = this.recipe.TotalCost;
				return totalCost.ToString("C", CultureInfo.CreateSpecificCulture("en-US"));
			}
		}


		public RecipeReceipt(IRecipe recipe)
		{
			// if recipe is null, throw and error
			this.recipe = recipe;
		}


		public override string ToString()
		{
			//TODO: Can I remove String.Format?
			var str = new StringBuilder();
			str.Append(String.Format("{0}\n",this.recipe.Name));
			str.Append(String.Format("\tTax = {0}\n", this.SalesTax));
			str.Append(String.Format("\tDiscount = ({0})\n", this.WellnessDiscount));
			str.Append(String.Format("\tTotal = {0}\n", this.TotalCost));
			str.Append("\n");
			return str.ToString();
		}
	}
}
