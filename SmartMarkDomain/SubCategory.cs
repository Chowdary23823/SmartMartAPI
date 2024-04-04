using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SmartMarkDomain
{
    public class SubCategory
    {
        [Key] public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }


        [ForeignKey("FromSubCategoryToCategory")]
        public int CategoryId { get; set; }


        public Category? Category { get; set; }
    }
}
