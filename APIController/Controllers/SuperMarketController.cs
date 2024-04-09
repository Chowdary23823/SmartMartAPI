using ApplicationServicesOfAPI.SuperMarketOperations;
using Domain.SmartMarket;
using Microsoft.AspNetCore.Mvc;
using SmartMarkDomain;

namespace APIController.Controllers
{
    [Route("/[controller]/[action]")]
    [ApiController]
    public class SuperMarketController : ControllerBase
    {

        SuperMarketOperations superMarketOperations;
        public SuperMarketController(SuperMarketOperations supMarketOperations)
        {
            superMarketOperations = supMarketOperations;
        }

        [HttpPost]
        public Product AddNewProduct(Product product)
        {
            return superMarketOperations.NewProduct(product);
        }

        [HttpGet]
        public List<Product> GetAllProducts()
        {
            return superMarketOperations.GetAllProducts();
        }

        [HttpPut]
        public Product AddQuantityOfProduct(int productId,int newQuantity)
        {
            return superMarketOperations.UpdateAddQuantityOfProduct(productId, newQuantity);
        }

        [HttpPut]
        public Product SubQuantityOfProduct(int productId,int quantityToSub)
        {
            return superMarketOperations.SubQuantityOfProduct(productId, quantityToSub);
        }

        [HttpDelete]
        public Product DeleteProduct(int id)
        {
            return superMarketOperations.DeleteProduct(id);
        }

        [HttpPost]
        public void AddSoldItems(List<SoldItems> list)
        {
            superMarketOperations.AddSoldItems(list);
        }




    }
}
