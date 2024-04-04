using ApplicationServicesOfAPI.UserOperationsFile;
using Microsoft.AspNetCore.Mvc;
using SmartMarkDomain;

namespace APIController.Controllers
{
    [Route("/[controller]/[Action]")]
    [ApiController]
    public class UserOperationsController : ControllerBase
    {

        UserOperations userOperations;
        public UserOperationsController(UserOperations userOperations)
        {
            this.userOperations = userOperations;
        }

        [HttpGet]
        public List<Product> GetProductsByName(string nameKey)
        {
            return userOperations.GetProductsWithName(nameKey);
        }

        [HttpGet]

        public List<Product> GetProductsByCategoryName(string  categoryName)
        {
            return userOperations.SearchingByAnyCategoryName(categoryName);
        }

        [HttpGet]
        public Product GetProductById(int id)
        {
            return userOperations.GetProductWithId(id);
        }

        [HttpGet]
        public List<Product> FilterByPriceRange(double startRange, double endRage)
        {
            return userOperations.FilterByPriceRange(startRange, endRage);
        }

        [HttpGet]
        public List<Product> SortProductsByName()
        {
            return userOperations.SortProductsByName();
        }

        [HttpGet]
        public List<Product> GetProductsUsingPagination(int pageNumber)
        {
            return userOperations.GetProductsUsingPagination(pageNumber);
        }




    }
}
