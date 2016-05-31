using System.Collections.Generic;
using System.Linq;
using AmeriHome.Logic.Models;
using AmeriHome.Root.Data.Domain;
using AmeriHome.Root.Data.Dto;

namespace AmeriHome.Logic.Utilities
{
	public static class Map
	{
		// This would be better in an stored procedure.
		public static Recipe ToRecipe(
			IDataRecipe recipe,
			List<IDataIngredient> ingredients,
			List<IDataRecipeIngredient> recipeIngredients)
    {
        //if any are null or empty, throw an exception;

        // Build recipe list.
        var recipeItems = new List<IIngredient>();
        foreach (var recipeIngredient in recipeIngredients)
        {
            var dataIngredient = ingredients.SingleOrDefault(m => m.Id == recipeIngredient.IngredientId);
            // If null then that's an error.

            var recipeItem = new Ingredient(
                amount: recipeIngredient.Amount,
                foodItem: Map.ToFoodItem(dataIngredient)
            );
            recipeItems.Add(recipeItem);
        }

        // Build Recipe
        var result = new Recipe (
            name: recipe.Name,
            ingredients: recipeItems
        );
        return result;
    }

		public static FoodItem ToFoodItem(IDataIngredient ingredient)
		{
			//if ingredient is null, throw exception.
			var result = new FoodItem(ingredient.Name, ingredient.Price, ingredient.IsProduce, ingredient.IsOrganic);
			return result;
		}
	}
}
