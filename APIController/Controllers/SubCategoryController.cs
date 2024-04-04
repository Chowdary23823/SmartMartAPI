using ApplicationServicesOfAPI.SubCategoriesOperationsFile;
using Microsoft.AspNetCore.Mvc;
using SmartMarkDomain;

namespace APIController.Controllers
{
    [Route("/[controller]/[Action]")]
    [ApiController]
    public class SubCategoryController : ControllerBase
    {
        SubCategoriesOperations subCategoriesOperations;

        public SubCategoryController(SubCategoriesOperations subCatOperations)  {
            subCategoriesOperations = subCatOperations;
        }


        [HttpPost]
        public SubCategory NewSubCategory(SubCategory subCategory)
        {
            return subCategoriesOperations.NewSubCategory(subCategory);
        }


        [HttpGet]
        public List<SubCategory> GetAllSubCategories()
        {
            return subCategoriesOperations.GetSubCategories();
        }


        [HttpPut]
        public SubCategory UpdateDiscription(int id, string discription)
        {
            return subCategoriesOperations.UpdateDescription(id, discription);
        }



        [HttpDelete]
        public bool DeleteSubCategory(int id)
        {
            return subCategoriesOperations.DeleteSubCategory(id);
        }




    }
}
