using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExWebApi.DAL;
using ExWebApi.Models;

namespace ExWebApi.BAL
{
    public class ProductService
    {
        IProductRepository _productRepository = null;

        public ProductService()
        {
            _productRepository = new ProductRepository();
        }

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<Product> GetProducts()
        {
            throw new InvalidProductsException();

            var products = _productRepository.GetProducts();

            if (products == null)
            {
               
            }

            return products;
        }

        public void Test()
        {
            throw new Exception();
        }
    }

    public class InvalidProductsException : Exception
    {
        public InvalidProductsException()
        {
        }

        public InvalidProductsException(string message):base(message)
        {
        }

        public InvalidProductsException(string message, Exception innerException):base(message, innerException)
        {

        }

    }
}
