namespace AmeriHome.Root.Data.Domain
{
	public interface IFoodItem
	{
		bool IsOrganic { get; }
		bool IsProduce { get; }
		string Name { get; }
		double Price { get; }
	}
}
