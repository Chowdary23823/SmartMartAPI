using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.SmartMarket
{
    public class SoldItems
    {
        [Key]
        public int Id { get; set; }

        public DateOnly Date {  get; set; }
        public string Name { get; set; }

        public int ItemId { get; set; }

        public int Quantity { get; set; }


        public double TotalPrice { get; set; }
    }
}
