using DataBaseContext;
using Microsoft.EntityFrameworkCore;
using SmartMarkDomain;

namespace ApplicationServicesOfAPI.SubCategoriesOperationsFile
{
    public class SubCategoriesOperations
    {
        public static DatabaseContext _dbObj;




        public SubCategoriesOperations(DatabaseContext dbContext)
        {
            _dbObj = dbContext;
        }

        public SubCategory NewSubCategory(SubCategory newSubCategory)
        {
            try
            {
                _dbObj.SubCategories.Add(newSubCategory);
                _dbObj.SaveChanges();
                return newSubCategory;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<SubCategory> GetSubCategories()
        {
            try
            {
                List<SubCategory> subCategories = _dbObj.SubCategories
                                                        .Include(obj=>obj.Category)
                                                        .ToList();
                if (subCategories == null || subCategories.Count <= 0)
                    return null;
                return subCategories;
            }catch(Exception e)
            {
                return null;
            }
        }


        public SubCategory UpdateDescription(int id, string newDescription)
        {
            SubCategory subCategory;
            try
            {
                subCategory = _dbObj.SubCategories
                                             .Include(obj => obj.Category)
                                             .FirstOrDefault(obj => obj.Id == id);
                if (subCategory == null)
                    return null;
                subCategory.Description = newDescription;
                _dbObj.SaveChanges();
                return subCategory;
            }
            catch (Exception e)
            {
                return null;
            }
        }


        public bool DeleteSubCategory(int id)
        {
            SubCategory subCategory;
            try
            {
                //var some = _debDemoContext.Products.Include(obj => obj.SubCategory).Any(obj => obj.SubCategory.SubCatId == id && obj.ProductQuantity > 0);
                if (_dbObj.Products.Include(obj => obj.SubCategory).Any(obj => obj.SubCategory.Id == id && obj.Quantity > 0))
                    return false;

                subCategory = _dbObj.SubCategories.FirstOrDefault(obj => obj.Id == id);
                if (subCategory == null)
                    return false;
                _dbObj.SubCategories.Remove(subCategory);
                _dbObj.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
