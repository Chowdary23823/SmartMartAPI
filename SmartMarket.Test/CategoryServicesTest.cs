using APIController.Controllers;
using ApplicationServicesOfAPI;
using DataBaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SmartMarkDomain;
using System.Diagnostics.CodeAnalysis;

namespace SmartMarket.Test
{
    internal class CategoryServicesTest
    {


        private CategoryController _operations;

        private DatabaseContext _dataBase;

        /*public CategoryServicesTest(CategoryOperations testObj,DatabaseContext dataBase)
        {
            operations = testObj;
            databaseContext = dataBase;
        }*/

        [SetUp]
        public void SetUp() {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDbContext<DatabaseContext>(options =>
            {
                options.UseNpgsql("Server=192.168.5.150;Port=5432;User Id=postgres;Password=n@v@yUg@kw!x##;Database=SmartMarket;Pooling=true;");
            });
           
            serviceCollection.AddTransient<CategoryOperations>();
            serviceCollection.AddTransient<CategoryController>(); 
            var serviceProvider = serviceCollection.BuildServiceProvider();
            _dataBase = serviceProvider.GetRequiredService<DatabaseContext>();
            CategoryOperations catOperations = serviceProvider.GetRequiredService<CategoryOperations>();
            _operations = new CategoryController(catOperations);

        }
        
       



        [Test]
        public void GetCategoriesComapreList()
        {
//            Assert.Pass();
            Assert.AreEqual(_operations.GetAllCategories(), _dataBase.Categories.ToList());

        }


        public static IEnumerable<TestCaseData> CategoryData
        {
            get
            {
                yield return new TestCaseData(new Category { Id = 6, Name = "Electronics", Description = "Electronic devices" });
                yield return new TestCaseData(new Category { Id = 7, Name = "", Description = null }); 
                yield return new TestCaseData(new Category { Id = 3, Name = null, Description = "Some description" }); 
                yield return new TestCaseData(new Category { Id = 9, Name = "123", Description = "Non-alphanumeric characters" });
                yield return new TestCaseData(new Category { Id = 5, Name = "Long Name Longer ", Description = "Description can be long" }); 
            }
        
        }

        [Test]
        [TestCaseSource(nameof(CategoryData))]
        public void TestingAddingNewCategory(Category category)
        {

            //int idByDesc = _dataBase.Categories.OrderByDescending(obj => obj.Id).First().Id;
            Category temp = _dataBase.Categories.FirstOrDefault(category => category.Id == category.Id);
            var result = _operations.NewCategory(category);
            
            if (temp!=null)
            {
                Assert.AreEqual(result, null);
            }
            else
            {
                //NotNullAttribute temp;

                Assert.IsNotNull(result);
            }
        }



        [Test]
        [TestCase(1,false)]
        [TestCase(6,true)]
        public void TestingRemoveCategory(int id,bool expected) {
            bool result = _operations.DeleteCategory(id);
            Assert.AreEqual(expected, result);
        }

        public static IEnumerable<TestCaseData> UpdateCategoryDescriptionData
        {
            get
            {
                yield return new TestCaseData(1, "Updated description", true); // Valid ID and description
                yield return new TestCaseData(100, "New description", false); // Non-existent ID
                yield return new TestCaseData(1, null, false); // Null description
                yield return new TestCaseData(20, "", false) ; // Empty description          
            }
        }


        [Test]
        [TestCaseSource(nameof(UpdateCategoryDescriptionData))]
        public void UpdateCategoryDescriptionTest(int id, string newDescription, bool expectedSuccess)
        {
            

            
            var updatedCategory = _operations.UpdateCategoryDiscription(id, newDescription);

            // Assert
            if (expectedSuccess)
            {
                Assert.IsNotNull(updatedCategory);
                Assert.AreEqual(id, updatedCategory.Id);
                Assert.AreEqual(newDescription, updatedCategory.Description);
            }
            else
            {
               
                Assert.AreEqual(null, updatedCategory);
            }
        }

        [TearDown]
        public void TearDown()
        {
            _dataBase.Dispose();
        }
    }
}
