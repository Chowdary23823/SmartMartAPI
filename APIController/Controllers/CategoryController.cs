using ApplicationServicesOfAPI;

using Microsoft.AspNetCore.Mvc;
using SmartMarkDomain;
using System.Web.Http.Cors;


namespace APIController.Controllers
{
    //[EnableCors(origins: "*", headers: "*", methods: "*")]
    [ApiController]
    [Route("/[controller]/[action]")]
    
    public class CategoryController : ControllerBase
    {

        



        CategoryOperations categoryOperations;
        public CategoryController(CategoryOperations categoryOperations)
        {
            this.categoryOperations = categoryOperations;
        }



        [HttpGet]
        public List<Category> GetAllCategories()
        {
            return  categoryOperations.GetCategories();//_debDemoContext.Categories.ToList();
        }

        [HttpPost]
        public Category NewCategory(Category newCategory)
        {
            return categoryOperations.NewCategory(newCategory);
        }


        [HttpDelete]
        public bool DeleteCategory(int id)
        {
            return categoryOperations.DeleteCategory(id);
        }


        [HttpPut]
        public Category UpdateCategoryDiscription(int id, [FromBody] string newDescription)
        {
            return categoryOperations.UpdateCategoryDiscription(id,newDescription);
        }







    }
}
