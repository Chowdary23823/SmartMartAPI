using DataBaseContext;
using Microsoft.EntityFrameworkCore;
using SmartMarkDomain;

namespace ApplicationServicesOfAPI.UserOperationsFile
{
    public class UserOperations
    {
        public static DatabaseContext _dbObj;

        public UserOperations(DatabaseContext dbContext)
        {
            _dbObj = dbContext;
        }

        public List<Product> GetProductsWithName(String keyProductName)
        {
            
            List<Product> products;
            try
            {
                products = _dbObj.Products
                        .Include(obj => obj.SubCategory)
                        .Include(obj => obj.SubCategory.Category)
                        .Where(obj => obj.Name == keyProductName)
                        .ToList();
                if (products == null || products.Count <= 0)
                    return null;
                return products;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public List<Product> SearchingByAnyCategoryName(string catName)
        {

            try
            {
                List<Product> products = _dbObj.Products.Include(obj => obj.SubCategory)
                                            .Include(obj => obj.SubCategory.Category)
                                            .Where(obj => obj.SubCategory.Name.Contains(catName) || obj.SubCategory.Category.Name.Contains(catName))
                                            .ToList();
                if (products == null || products.Count <= 0)
                {
                    return null;
                }
                else
                    return products;
            }catch(Exception e)
            {
                return null;
            }



        }

        public Product GetProductWithId(int id)
        {
            try
            {
                Product product = _dbObj.Products.Include(obj => obj.SubCategory).FirstOrDefault(obj => obj.Id == id);
                if (product != null)
                {
                    return product;

                }
                else
                {
                    return null;
                }
            }catch(Exception e)
            {
                return null;
            }
            //return product;

        }

        public List<Product> FilterByPriceRange(double startRange, double endRage)
        {
            if (endRage <= startRange)
            {
                return null;
                /*return null;*/
            }
            List<Product> products;
            try
            {
                products = _dbObj.Products
                                            .Include(obj => obj.SubCategory)
                                            .Include(obj => obj.SubCategory.Category)
                                            .Where(obj => obj.Price >= startRange && obj.Price <= endRage)
                                            .ToList();
                if (products == null || products.Count <= 0)
                {
                    return null;
                    //return null;
                }
                return products;
            }
            catch (Exception e)
            {
                return null;
            }


        }


        public List<Product> SortProductsByName()
        {

            List<Product> products;
            try
            {
                products = _dbObj.Products
                                            .Include(obj => obj.SubCategory)
                                            .Include(obj => obj.SubCategory.Category)
                                            .OrderBy(obj => obj.Name)
                                            .ToList();
                if (products == null || products.Count <= 0)
                {
                    //return NotFound("No Products Found");
                    return null;
                }
                return products;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public List<Product> GetProductsUsingPagination(int pageNumber)
        {
            int noOfProductsPerPage = 12;
            if (pageNumber <= 0)
            {
                return null;
            }
            List<Product> products;
            try
            {
                products = _dbObj.Products
                                          .Include(obj => obj.SubCategory)
                                          .Include(obj => obj.SubCategory.Category)
                                          .Skip((pageNumber - 1) * noOfProductsPerPage)
                                          .Take(noOfProductsPerPage)
                                          .ToList();
                if (products == null || products.Count <= 0)
                {
                    return null;
                }
                return products;
            }
            catch (Exception e)
            {
                return null;
            }
        }

    }
}
