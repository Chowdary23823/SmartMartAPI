using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartMarkDomain
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }

        [ForeignKey("FromProductToSubCategory")]
        public int SubCategoryId { get; set; }

        public SubCategory? SubCategory { get; set; }


    }
}
