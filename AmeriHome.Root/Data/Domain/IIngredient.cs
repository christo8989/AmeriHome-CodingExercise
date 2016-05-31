namespace AmeriHome.Root.Data.Domain
{
	public interface IIngredient
	{
		double Amount { get; }
		IFoodItem Item { get; }
		string ToString();
	}
}
