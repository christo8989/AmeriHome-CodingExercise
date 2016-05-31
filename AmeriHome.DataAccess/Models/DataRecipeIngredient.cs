using AmeriHome.Root.Data.Dto;

namespace AmeriHome.DataAccess.Models
{
	public class DataRecipeIngredient : IDataRecipeIngredient
	{
		public int RecipeId { get; set; }
		public int IngredientId { get; set; }
		public double Amount { get; set; }
	}
}
