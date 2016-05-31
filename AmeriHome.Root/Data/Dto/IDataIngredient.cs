namespace AmeriHome.Root.Data.Dto
{
	public interface IDataIngredient
	{
		int Id { get; set; }
		bool IsOrganic { get; set; }
		bool IsProduce { get; set; }
		string Name { get; set; }
		double Price { get; set; }
	}
}
