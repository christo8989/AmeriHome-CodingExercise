using AmeriHome.Root.Data.Domain;

namespace AmeriHome.Logic.Models
{
	// Doesn't need to be immutable but why not given the requirements.
	public class FoodItem : IFoodItem
	{
		private readonly string name;
		public string Name 
		{
			get { return this.name; }
		}

		private readonly double price;
		public double Price
		{
			get { return this.price; }
		}

		private readonly bool isProduce;
		public bool IsProduce
		{
			get { return this.isProduce; }
		}

		private readonly bool isOrganic;
		public bool IsOrganic
		{
			get { return this.isOrganic; }
		}


		public FoodItem(string name, double price, bool isProduce, bool isOrganic)
		{
			//throw if name is null or empty, throw if price is negative
			this.name = name;
			this.price = price;
			this.isProduce = isProduce;
			this.isOrganic = isOrganic;
		}
	}
}
