using SalesDb.Data.Models;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesDb.Data.Models
{
    public class Product
    {
        public Product()
        {
            this.Sales = new List<Sale>();
        }
        [Key]
        public int ProductId { get; set; }

        public string Name { get; set; }

        public decimal Quantity { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public ICollection<Sale> Sales { get; set; }
    }
}
