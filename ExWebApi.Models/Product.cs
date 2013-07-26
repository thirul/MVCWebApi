using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExWebApi.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }

    public class ProductViewModel
    {
        public IEnumerable<Product> Products { get; set; }
    
        public Product Product { get; set; }
    }
}