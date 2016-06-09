using AmeriHome.Root.Data.Domain.Abstract;
namespace AmeriHome.Root.Data.Domain
{
	public interface IIngredient : IFoodItem
	{
		double Amount { get; }
		string ToString();
	}
}
