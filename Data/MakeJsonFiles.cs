using System.Web.Script.Serialization.JavaScriptSerializer;

public class MakeJsonFiles
{
    private JavaScriptSerializer serializer = new JavaScriptSerializer();

    public string JsonIngredients()
    {
        var ingredients = new List<DataIngredient>();
        ingredients.Add(new DataIngredient {
            Id = 0,
            Name = "Organic Garlic",
            Price = 0.67,
            IsProduce = true,
            IsOrganic = true,
        });
        ingredients.Add(new DataIngredient {
            Id = 1,
            Name = "Lemon",
            Price = 2.03,
            IsProduce = true,
            IsOrganic = false,
        });
        ingredients.Add(new DataIngredient {
            Id = 2,
            Name = "Corn",
            Price = 0.87,
            IsProduce = true,
            IsOrganic = false,
        });
        ingredients.Add(new DataIngredient {
            Id = 3,
            Name = "Chicken Breast",
            Price = 2.19,
            IsProduce = false,
            IsOrganic = false,
        });
        ingredients.Add(new DataIngredient {
            Id = 4,
            Name = "Bacon",
            Price = 0.24,
            IsProduce = false,
            IsOrganic = false,
        });
        ingredients.Add(new DataIngredient {
            Id = 5,
            Name = "Pasta",
            Price = 0.31,
            IsProduce = false,
            IsOrganic = false,
        });
        ingredients.Add(new DataIngredient {
            Id = 6,
            Name = "Organic Olive Oil",
            Price = 1.92,
            IsProduce = false,
            IsOrganic = true,
        });
        ingredients.Add(new DataIngredient {
            Id = 7,
            Name = "Vinegar",
            Price = 1.26,
            IsProduce = false,
            IsOrganic = false,
        });
        ingredients.Add(new DataIngredient {
            Id = 8,
            Name = "Salt",
            Price = 0.16,
            IsProduce = false,
            IsOrganic = false,
        });
        ingredients.Add(new DataIngredient {
            Id = 9,
            Name = "Pepper",
            Price = 0.17,
            IsProduce = false,
            IsOrganic = false,
        });

        var result = this.serializer.Serialize(ingredients);
        return result;
    }

    public string JsonRecipes()
    {
        var recipes = new List<DataRecipe>();
        recipes.Add(new DataRecipe {
            Id = 0;
            Name = "Recipe 1",
        });
        recipes.Add(new DataRecipe {
            Id = 1;
            Name = "Recipe 2",
        });
        recipes.Add(new DataRecipe {
            Id = 2;
            Name = "Recipe 3",
        });

        var result = this.serializer.Serialize(recipes);
        return result;
    }

    public string JsonRecipeIngredients()
    {
        var recipeIngredients = new List<DataRecipeIngredient>();
        recipeIngredients.Add(new DataRecipeIngredient {
            RecipeId = 0,
            IngredientId = 0,
            Amount = 1,
        });
        recipeIngredients.Add(new DataRecipeIngredient {
            RecipeId = 0,
            IngredientId = 1,
            Amount = 1,
        });
        recipeIngredients.Add(new DataRecipeIngredient {
            RecipeId = 0,
            IngredientId = 6,
            Amount = 0.75,
        });
        recipeIngredients.Add(new DataRecipeIngredient {
            RecipeId = 0,
            IngredientId = 8,
            Amount = 0.75,
        });
        recipeIngredients.Add(new DataRecipeIngredient {
            RecipeId = 0,
            IngredientId = 9,
            Amount = 0.5,
        });
        recipeIngredients.Add(new DataRecipeIngredient {
            RecipeId = 1,
            IngredientId = 0,
            Amount = 1,
        });
        recipeIngredients.Add(new DataRecipeIngredient {
            RecipeId = 1,
            IngredientId = 3,
            Amount = 4,
        });
        recipeIngredients.Add(new DataRecipeIngredient {
            RecipeId = 1,
            IngredientId = 6,
            Amount = 0.5,
        });
        recipeIngredients.Add(new DataRecipeIngredient {
            RecipeId = 1,
            IngredientId = 7,
            Amount = 0.5,
        });
        recipeIngredients.Add(new DataRecipeIngredient {
            RecipeId = 2,
            IngredientId = 0,
            Amount = 1,
        });
        recipeIngredients.Add(new DataRecipeIngredient {
            RecipeId = 2,
            IngredientId = 2,
            Amount = 4,
        });
        recipeIngredients.Add(new DataRecipeIngredient {
            RecipeId = 2,
            IngredientId = 4,
            Amount = 4,
        });
        recipeIngredients.Add(new DataRecipeIngredient {
            RecipeId = 2,
            IngredientId = 5,
            Amount = 8,
        });
        recipeIngredients.Add(new DataRecipeIngredient {
            RecipeId = 2,
            IngredientId = 6,
            Amount = 1/3.0,
        });
        recipeIngredients.Add(new DataRecipeIngredient {
            RecipeId = 2,
            IngredientId = 8,
            Amount = 1.25,
        });
        recipeIngredients.Add(new DataRecipeIngredient {
            RecipeId = 2,
            IngredientId = 9,
            Amount = 0.75,
        });

        var result = this.serializer.Serialize(recipeIngredients);
        return result;
    }
}
