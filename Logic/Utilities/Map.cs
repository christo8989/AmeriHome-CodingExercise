public static class Map
{
    // This would be better in an stored procedure.
    public Recipe ToRecipe(
        DataRecipe recipe,
        List<DataIngredient> ingredients,
        List<dataRecipeIngredient> recipeIngredients)
    {
        //if any are null or empty, throw an exception;

        // Build recipe list.
        var recipeItems = new List<RecipeItem>();
        foreach (var recipeIngredient in recipeIngredients)
        {
            var dataIngredient = ingredients.SingleOrDefault(m => m.Id = recipeIngredient.Ingredient.Id);
            // If null then that's an error.

            var recipeItem = new Ingredient(
                Amount = recipeIngredient.Amount,
                Item = this.ToFoodItem(dataIngredient),
            );
            recipeItems.Add(recipeItem);
        }

        // Build Recipe
        var result = new Recipe {
            Name = recipe.name,
            Ingredients = recipeItems,
        };
        return result;
    }

    public FoodItem ToFoodItem(DataIngredient ingredient)
    {
        //if ingredient is null, throw exception.
        var result = new FoodItem(ingredient.Name, ingredient.Price, ingredient.IsProduce, ingredient.IsOrganic);
        return result;
    }
}
