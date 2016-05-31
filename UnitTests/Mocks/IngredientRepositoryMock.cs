using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmeriHome.Root.Behavior.Clients;
using AmeriHome.Root.Behavior.Repositories;
using AmeriHome.Root.Data.Dto;

namespace UnitTests.Mocks
{
	internal class IngredientRepositoryMock	: IIngredientRepository
	{	  	
		public List<IDataIngredient> Get(IEnumerable<int> ids)
		{
			throw new NotImplementedException();
		}
	}
}
