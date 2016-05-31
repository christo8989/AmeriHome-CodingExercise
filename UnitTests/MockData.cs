﻿namespace UnitTests
{
	internal static class MockData
	{
		public const string DATA_INGREDIENTS = "[{\"Id\":0,\"Name\":\"Organic Garlic\",\"Price\":0.67,\"IsProduce\":true,\"IsOrganic\":true},{\"Id\":1,\"Name\":\"Lemon\",\"Price\":2.03,\"IsProduce\":true,\"IsOrganic\":false},{\"Id\":2,\"Name\":\"Corn\",\"Price\":0.87,\"IsProduce\":true,\"IsOrganic\":false},{\"Id\":3,\"Name\":\"Chicken Breast\",\"Price\":2.19,\"IsProduce\":false,\"IsOrganic\":false},{\"Id\":4,\"Name\":\"Bacon\",\"Price\":0.24,\"IsProduce\":false,\"IsOrganic\":false},{\"Id\":5,\"Name\":\"Pasta\",\"Price\":0.31,\"IsProduce\":false,\"IsOrganic\":false},{\"Id\":6,\"Name\":\"Organic Olive Oil\",\"Price\":1.92,\"IsProduce\":false,\"IsOrganic\":true},{\"Id\":7,\"Name\":\"Vinegar\",\"Price\":1.26,\"IsProduce\":false,\"IsOrganic\":false},{\"Id\":8,\"Name\":\"Salt\",\"Price\":0.16,\"IsProduce\":false,\"IsOrganic\":false},{\"Id\":9,\"Name\":\"Pepper\",\"Price\":0.17,\"IsProduce\":false,\"IsOrganic\":false}]";
		public const string DATA_RECIPES = "[{\"Id\":0,\"Name\":\"Recipe 1\"},{\"Id\":1,\"Name\":\"Recipe 2\"},{\"Id\":2,\"Name\":\"Recipe 3\"}]";
		public const string DATA_RECIPE_INGREDIENTS = "[{\"RecipeId\":0,\"IngredientId\":0,\"Amount\":1},{\"RecipeId\":0,\"IngredientId\":1,\"Amount\":1},{\"RecipeId\":0,\"IngredientId\":6,\"Amount\":0.75},{\"RecipeId\":0,\"IngredientId\":8,\"Amount\":0.75},{\"RecipeId\":0,\"IngredientId\":9,\"Amount\":0.5},{\"RecipeId\":1,\"IngredientId\":0,\"Amount\":1},{\"RecipeId\":1,\"IngredientId\":3,\"Amount\":4},{\"RecipeId\":1,\"IngredientId\":6,\"Amount\":0.5},{\"RecipeId\":1,\"IngredientId\":7,\"Amount\":0.5},{\"RecipeId\":2,\"IngredientId\":0,\"Amount\":1},{\"RecipeId\":2,\"IngredientId\":2,\"Amount\":4},{\"RecipeId\":2,\"IngredientId\":4,\"Amount\":4},{\"RecipeId\":2,\"IngredientId\":5,\"Amount\":8},{\"RecipeId\":2,\"IngredientId\":6,\"Amount\":0.3333333333333333},{\"RecipeId\":2,\"IngredientId\":8,\"Amount\":1.25},{\"RecipeId\":2,\"IngredientId\":9,\"Amount\":0.75}]";
	}
}