using Microsoft.EntityFrameworkCore;
using SmartMarkDomain;
using System.Collections.Generic;

namespace DataBaseContext
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        //Here the DbSet should be used for creating table 
        // if product table has to be created then the DbSet<Product> identifier {set; get;}

        public DbSet<Category> Categories { get; set; }

        public DbSet<SubCategory> SubCategories { get; set; }


        public DbSet<Product> Products { get; set; }
    }
}
