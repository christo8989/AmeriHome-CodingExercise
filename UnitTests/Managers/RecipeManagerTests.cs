using System;
using System.Linq;
using AmeriHome.Logic.Managers;
using AmeriHome.Root.Behavior.Manager;
using AmeriHome.Root.Behavior.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTests.Mocks;

namespace UnitTests.Managers
{
	[TestClass]
	public class RecipeManagerTests
	{
		//private IFileClient client = new FileClientMock(); //Leave out for now.
		private IIngredientRepository ingredientRepository;
		private IRecipeRepository recipeRepository;
		private IRecipeIngredientRepository recipeIngredientRepository;
		private IRecipeManager recipeManager;

		[TestInitialize]
		public void Initialize()
		{
			this.ingredientRepository = new IngredientRepositoryMock();
			this.recipeRepository = new RecipeRepositoryMock();
			this.recipeIngredientRepository = new RecipeIngredientRepositoryMock();
			this.recipeManager = new RecipeManager(
					this.ingredientRepository,
					this.recipeRepository,
					this.recipeIngredientRepository
				);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void Constructor_ThrowsArgumentNullExceptionOnIngredientRepository()
		{
			Action action = () => new RecipeManager(null, this.recipeRepository, this.recipeIngredientRepository);
			action();
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void Constructor_ThrowsArgumentNullExceptionOnRecipeRepository()
		{
			Action action = () => new RecipeManager(this.ingredientRepository, null, this.recipeIngredientRepository);
			action();
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void Constructor_ThrowsArgumentNullExceptionOnRecipeIngredientRepository()
		{
			Action action = () => new RecipeManager(this.ingredientRepository, this.recipeRepository, null);
			action();
		}


		[TestMethod]
		public void Get_ShouldNotThrowAnExceptionWithValidInput()
		{
			Action action = () => this.recipeManager.Get(1);
			action();
		}

		[TestMethod]
		public void Get_ShouldReturnNullWithInvalidInput()
		{
			//-1 is based on the mock classes. 
			//So, the negative id is just for testing purposes.
			var actual = this.recipeManager.Get(-1);
			Assert.IsNull(actual);
		}

		[TestMethod]
		public void GetAll_ShouldNotThrowAnException()
		{
			var actual = this.recipeManager.GetAll();
			Assert.IsTrue(actual != null && actual.Any());
			CollectionAssert.AllItemsAreNotNull(actual);
			actual.ForEach(m => {
				Assert.IsTrue(m.Ingredients != null && m.Ingredients.Any());
				CollectionAssert.AllItemsAreNotNull(m.Ingredients);
			});
		}
	}
}
