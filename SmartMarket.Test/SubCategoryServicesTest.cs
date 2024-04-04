using APIController.Controllers;
using ApplicationServicesOfAPI;
using ApplicationServicesOfAPI.SubCategoriesOperationsFile;
using DataBaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SmartMarkDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMarket.Test
{
    internal class SubCategoryServicesTest
    {
        private SubCategoryController _operations;

        private DatabaseContext _dataBase;

        

        [SetUp]
        public void SetUp()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDbContext<DatabaseContext>(options =>
            {
                options.UseNpgsql("Server=192.168.5.150;Port=5432;User Id=postgres;Password=n@v@yUg@kw!x##;Database=SmartMarket;Pooling=true;");
            });

            serviceCollection.AddTransient<SubCategoriesOperations>();
            serviceCollection.AddTransient<SubCategoryController>();
            var serviceProvider = serviceCollection.BuildServiceProvider();
            _dataBase = serviceProvider.GetRequiredService<DatabaseContext>();
            _operations = serviceProvider.GetRequiredService<SubCategoryController>();


        }


        public static IEnumerable<TestCaseData> SubCategoryData
        {
            get
            {
                yield return new TestCaseData(
                    new SubCategory { Id = 1, Name = "Electronics", Description = "Electronic devices", CategoryId = 1 });
                yield return new TestCaseData(
                    new SubCategory { Id = 2, Name = "Clothing", Description = "Men's, women's and children's clothing", CategoryId = 2 });
                yield return new TestCaseData(
                    new SubCategory { Id = 3, Name = "Books", Description = "Fiction, non-fiction, and children's books", CategoryId = 3 });
                yield return new TestCaseData(
                    new SubCategory { Id = 4, Name = "Furniture", Description = "Living room, bedroom, and office furniture", CategoryId = 4 });

                
            }
        }

        [Test]
        [TestCaseSource(nameof(SubCategoryData))]
        public void NewSubCatogory(SubCategory subCategory)
        {
            SubCategory subNewCategory = _operations.NewSubCategory(subCategory);
            Assert.AreEqual(subNewCategory,null);

        }






        [TearDown]
        public void TearDown()
        {
            _dataBase.Dispose();
        }
    }
}
