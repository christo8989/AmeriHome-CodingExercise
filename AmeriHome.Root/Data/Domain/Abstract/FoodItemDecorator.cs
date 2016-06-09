using System;

namespace AmeriHome.Root.Data.Domain.Abstract
{
	public abstract class FoodItemDecorator : IFoodItem
	{
		protected IFoodItem baseObject = null;

		public string Name
		{
			get { return this.baseObject.Name; }
		}

		public double Price
		{
			get { return this.baseObject.Price; }
		}

		public bool IsProduce
		{
			get { return this.baseObject.IsProduce; }
		}

		public bool IsOrganic
		{
			get { return this.baseObject.IsOrganic; }
		}

		protected FoodItemDecorator(IFoodItem foodItem)
		{
			if (foodItem == null)
				throw new ArgumentNullException("foodItem"); //nameof(foodItem)

			this.baseObject = foodItem;
		}
	}
}
