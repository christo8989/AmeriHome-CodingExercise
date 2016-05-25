// Doesn't need to be immutable but why not given the requirements.
public class FoodItem
{
    public readonly string Name { get; private set; }
    public readonly string Price { get; private set; }
    public readonly bool IsProduce { get; private set; }
    public readonly bool IsOrganic { get; private set; }


    public Ingredient(string name, double price, bool isProduce, bool isOrganic)
    {
        //throw if name is null or empty, throw if price is negative
        this.Name = name;
        this.Price = price;
        this.IsProduce = isProduce;
        this.IsOrganic = isOrganic;
    }
}
