using DataBaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SmartMarkDomain;

namespace ApplicationServicesOfAPI
{
    public class CategoryOperations
    {
        public static DatabaseContext _dbObj;




        public CategoryOperations(DatabaseContext dbContext)
        {
            _dbObj = dbContext;
        }



        public List<Category> GetCategories()
        {
            try
            {
                List<Category> categories;
                categories = _dbObj.Categories.ToList();
                if (categories == null || categories.Count == 0)
                {

                    return null;

                }
                return categories;
            }
            catch (Exception ex)
            {
                return null;
            }

        }




        public Category NewCategory(Category newCategory)
        {
            try
            {
                _dbObj.Categories.Add(newCategory);
                _dbObj.SaveChanges();
                return newCategory;
            }
            catch (Exception ex)
            {
                return null;
            }
        }





        public bool DeleteCategory(int id)
        {
            Category category;
            try
            {
                if (_dbObj.Products
                    .Include(obj => obj.SubCategory)
                    .Include(obj => obj.SubCategory.Category)
                    .Any(obj => obj.SubCategory.Category.Id == id && obj.Quantity > 0))
                    return false;

                category = _dbObj.Categories.FirstOrDefault(obj => obj.Id == id);
                if (category == null)
                    return false;
                _dbObj.Categories.Remove(category);
                _dbObj.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }



        public Category UpdateCategoryDiscription(int id, [FromBody] string newDescription)
        {
            Category category;
            try
            {
                category = _dbObj.Categories.FirstOrDefault(obj => obj.Id == id);
                if (category == null)
                    return null;
                category.Description = newDescription;
                _dbObj.SaveChanges();
                return category;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
