using AmeriHome.Root.Data.Dto;

namespace AmeriHome.DataAccess.Models
{
	public class DataIngredient : IDataIngredient
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public double Price { get; set; }
		public bool IsProduce { get; set; }
		public bool IsOrganic { get; set; }
	}
}
