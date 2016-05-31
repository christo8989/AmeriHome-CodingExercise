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
	public class IngredientRepository : IIngredientRepository
	{
		private readonly IFileClient client;


		public IngredientRepository(IFileClient client)
		{
			this.client = client;
		}


		public List<IDataIngredient> Get(IEnumerable<int> ids)
		{
			if (ids == null)
				throw new ArgumentNullException("ids"); //nameof(ids)

			if (!ids.Any())
				throw new ArgumentException("Empty list of ids", "ids");

			var json = client.ReadFromFile(Constants.TABLE_INGREDIENT);
			var allIngredients = JsonConvert.DeserializeObject<List<DataIngredient>>(json);
			var result = allIngredients.Where(m => ids.Contains(m.Id));
			return result.Cast<IDataIngredient>().ToList();
		}
	}
}
