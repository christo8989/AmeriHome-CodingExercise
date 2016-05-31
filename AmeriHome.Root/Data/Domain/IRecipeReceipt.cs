namespace AmeriHome.Root.Data.Domain
{
	public interface IRecipeReceipt
	{
		string SalesTax { get; }
		string ToString();
		string TotalCost { get; }
		string WellnessDiscount { get; }
	}
}
