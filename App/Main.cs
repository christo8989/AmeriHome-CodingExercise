public class Main
{
    public static void Main(string[] args)
    {
        var ingredientRepository = new IngredientRepository();
        var recipeRepository = new RecipeRepository();
        var recipeIngredientRespository = new IngredientRecipeRepository();
        var recipeManager = new RecipeManager(
            ingredientRepository,
            recipeRepository,
            recipeIngredientRespository
        );

        var receipts = recipeManager.GetAll();
        foreach (var receipt in receipts)
        {
            Console.WriteLine(receipt.ToString());
        }

        Console.WriteLine("\n\n---------- END ----------");
    }
}
