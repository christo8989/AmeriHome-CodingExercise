public class RecipeManager
{
    private readonly IngredientRepository ingredientRepository;
    private readonly RecipeRepository recipeRepository;
    private readonly IngredientRecipeRepository ingredientRecipeRepository;


    public RecipeManager(
        IngredientRepository ingredientRepository,
        RecipeRepository recipeRepository,
        IngredientRecipeRepository ingredientRecipeRepository)
    {
        //if any are null, throw an exception.
        this.ingredientRepository = ingredientRepository;
        this.recipeRepository = recipeRepository;
        this.ingredientRecipeRepository = ingredientRecipeRepository;
    }


    public Recipe Get(int id)
    {
        // Some of this should be in a stored procedure.
        var dataRecipe = this.recipeRepository.Get(id);
        var dataRecipeIngredients = this.ingredientRecipeRepository.Get(id);
        var ingredientIds = dataRecipeIngredients.Select(m => m.IngredientId);
        var dataIngredients = this.ingredientRepository.Get(ingredientIds);

        // Joins in a stored procedure would be more efficient and easier.
        var result = Map.ToRecipe(dataRecipe, dataIngredients, dataRecipeIngredients);
        return result;
    }

    // Not efficient in real life app. Easy for a fake database (this situation).
    // Making multiple IO calls is significantly costly and not scallable.
    public List<Recipe> GetAll()
    {
        var dataRecipeIds = this.recipeRepository.GetAllIds();
        var result = new List<Recipe>();
        foreach (var id in dataRecipeIds)
        {
            var recipe = this.Get(id);
            result.Add(recipe);
        }

        return result;
    }
}
