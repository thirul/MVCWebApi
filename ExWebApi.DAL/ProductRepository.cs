using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExWebApi.Models;

namespace ExWebApi.DAL
{
    public class ProductRepository:IProductRepository
    {
        public static IEnumerable<Product> _products = new List<Product>() 
                                                        { 
                                                             new Product(){Id=1, Name ="Raj", Price =123.36},       
                                                             new Product(){Id=2, Name ="KoRaj", Price =236},
                                                             new Product(){Id=3, Name ="Johj", Price =13.36},
                                                             new Product(){Id=4, Name ="Dave", Price =12.36},
                                                        };


        public IEnumerable<Product> GetProducts()
        {   


            return _products;
        }

        public Product GetProduct(int? id)
        {
            if (id == null)
            {
                throw new ArgumentException("invalid argument", "id");
            }

            var product = (from p in _products
                           where p.Id == id
                           select p).FirstOrDefault();

            return product;
        }

    }

    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        Product GetProduct(int? id);
    }
}
