﻿using System;
using System.Collections.Generic;
using System.Linq;
using AmeriHome.DataAccess.Models;
using AmeriHome.Root.Behavior.Clients;
using AmeriHome.Root.Behavior.Repositories;
using AmeriHome.Root.Common;
using AmeriHome.Root.Data.Dto;
using Newtonsoft.Json;

namespace AmeriHome.DataAccess.Repositories
{
	public class RecipeIngredientRepository	: IRecipeIngredientRepository
	{			
		private readonly IFileClient client;


		public RecipeIngredientRepository(IFileClient client)
		{
			this.client = client;
		}


		public List<IDataRecipeIngredient> Get(int recipeId)
		{
			var json = this.client.ReadFromFile(Constants.TABLE_RECIPE_INGREDIENT);
			var allRecipeIngredients = JsonConvert.DeserializeObject<List<DataRecipeIngredient>>(json);
			var result = allRecipeIngredients.Where(m => m.RecipeId == recipeId);
			return result.Cast<IDataRecipeIngredient>().ToList();
		}
	}
}
