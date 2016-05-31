namespace AmeriHome.Root.Data.Dto
{
	public interface IDataRecipeIngredient
	{
		int RecipeId { get; set; }
		int IngredientId { get; set; }
		double Amount { get; set; }
	}
}
