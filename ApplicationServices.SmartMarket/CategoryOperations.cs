using DataBaseContext;
using Microsoft.EntityFrameworkCore;
using SmartMarkDomain;

namespace ApplicationServicesOfAPI
{


    public interface ICategoryOperations
    {
        List<Category> GetCategories();
    }


    public class CategoryOperations : ICategoryOperations

    {
        public static DatabaseContext _dbObj;

        


        public CategoryOperations(DatabaseContext dbContext)
        {
            _dbObj = dbContext;
        }



        public List<Category> GetCategories()
        {
            List<Category> categories;
            categories = _dbObj.Categories.ToList();
            return categories;
        }




        public Category NewCategory(Category newCategory)
        {
            int id = newCategory.Id;
            try
            {
                _dbObj.Categories.Add(newCategory);
                _dbObj.SaveChanges();
            }catch(Exception e)
            {
                return null;
            }
            return _dbObj.Categories.FirstOrDefault(obj=>obj.Id==id);
        }





        public bool DeleteCategory(int id)
        {
            Category category;
            if (_dbObj.Products
                    .Include(obj => obj.SubCategory)
                    .Include(obj => obj.SubCategory.Category)
                    .Any(obj => obj.SubCategory.Category.Id == id && obj.Quantity > 0))
                return false;

            category = _dbObj.Categories.FirstOrDefault(obj => obj.Id == id);
           
            _dbObj.Categories.Remove(category);
            _dbObj.SaveChanges();
            return true;


        }



        public Category UpdateCategoryDiscription(int id, string newDescription)
        {
            Category category;
            category = _dbObj.Categories.FirstOrDefault(obj => obj.Id == id);
            if (category == null)
                return null;
            category.Description = newDescription;
            _dbObj.SaveChanges();
            return category;
        }

    }
}
