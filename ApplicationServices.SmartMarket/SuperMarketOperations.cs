using DataBaseContext;
using Domain.SmartMarket;
using Microsoft.EntityFrameworkCore;
using SmartMarkDomain;

namespace ApplicationServicesOfAPI.SuperMarketOperations
{
    public class SuperMarketOperations
    {

        public static DatabaseContext _dbObj;

        public SuperMarketOperations(DatabaseContext dbContext)
        {
            _dbObj = dbContext;
        }

        public Product NewProduct(Product product)
        {
            try
            {
                _dbObj.Products.Add(product);
                _dbObj.SaveChanges();
                return product;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public List<Product> GetAllProducts()
        {
            try
            {
                List<Product> products;
                products = _dbObj.Products
                        .Include(obj => obj.SubCategory)
                        .Include(obj => obj.SubCategory.Category)
                        .ToList();
                if (products == null || products.Count <= 0)
                    return null; 
                return products;

            }catch(Exception e)
            {
                return null;
            }
        }


        public Product UpdateAddQuantityOfProduct(int productId, int newQuantity)
        {
            Product productObj = _dbObj.Products.ToList().Find(obj => obj.Id == productId); //productId);
            //Product productObj = products.Find(obj => obj.ProductId==productId);

            if (productObj == null)
            {
                return null;
            }
            try
            {
                productObj.Quantity += newQuantity;
                _dbObj.SaveChanges();
                return productObj;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public Product SubQuantityOfProduct(int productId, int quantityTOSub)
        {
            Product productObj = _dbObj.Products.ToList().Find(obj => obj.Id == productId); //productId);
            //Product productObj = products.Find(obj => obj.ProductId==productId);

            if (productObj == null)
            {
                return null;
            }
            try
            {
                productObj.Quantity -= quantityTOSub;
                _dbObj.SaveChanges();
                return productObj;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public Product DeleteProduct(int id)
        {
            Product product;
            try
            {
                product = _dbObj.Products.FirstOrDefault(obj => obj.Id == id);
                if (product.Quantity > 0)
                    return null;
                _dbObj.Products.Remove(product);
                _dbObj.SaveChanges();
                return product;
            }
            catch (Exception ex)
            {
                return null;
            }
        }



        public void AddSoldItems(List<SoldItems> list)
        {
            
            foreach (var item in list)
            {
                try
                {
                    _dbObj.SoldItems.Add(item);
                    SubQuantityOfProduct(item.ItemId, item.Quantity);
                    _dbObj.SaveChanges();
                }catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

        }


    }
}
