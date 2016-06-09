using System;
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
	public class RecipeRepository : IRecipeRepository
	{		
		private readonly IFileClient client;


		public RecipeRepository(IFileClient client)
		{
			if (client == null)
				throw new ArgumentNullException();

			this.client = client;
		}


		public IDataRecipe Get(int id)
		{
			var result = this.GetAll().SingleOrDefault(m => m.Id == id);
			return result;
		}

		public List<IDataRecipe> GetAll()
		{
			var json = this.client.ReadFromFile(Constants.TABLE_RECIPE) ?? String.Empty;
			var result = JsonConvert.DeserializeObject<List<DataRecipe>>(json) ?? new List<DataRecipe>();
			return result.Cast<IDataRecipe>().ToList();
		}

		public List<int> GetAllIds()
		{			   
			var result = this.GetAll().Select(m => m.Id).ToList();
			return result;
		}
	}
}
