using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Entities
{
    public class Product : BaseInformation
    {
        public int Id { get; set; }
        public string? Name { get; set; }        
        public string? Desc { get; set; }                                                    
        public decimal Price { get; set; }
        public string? Url { get; set; }
        public int CartItemId { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
