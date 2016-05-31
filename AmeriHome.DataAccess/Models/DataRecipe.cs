using AmeriHome.Root.Data.Dto;

namespace AmeriHome.DataAccess.Models
{
	public class DataRecipe	: IDataRecipe
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}
}
