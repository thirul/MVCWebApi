using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using ExWebApi.BAL;
using ExWebApi.DAL;
using Moq;
using ExWebApi.Models;

namespace ExWebApi.Tests
{
    [TestFixture]
    public class Product_Service_Layer_Test
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        [ExpectedException(typeof(InvalidProductsException))]
        public void get_all_products_test()
        {
            // arrange
            IEnumerable<Product> productList = new List<Product>() 
                                                        { 
                                                             new Product(){Id=1, Name ="Raj", Price =123.36},       
                                                             new Product(){Id=2, Name ="KoRaj", Price =236},
                                                             new Product(){Id=3, Name ="Johj", Price =13.36},
                                                             new Product(){Id=4, Name ="Dave", Price =12.36},
                                                        };

            var mockRepository = new Mock<IProductRepository>();
            mockRepository.Setup(x=>x.GetProducts()).Returns(()=>null);

            // act
           var productService = new ProductService(mockRepository.Object);
           var products =  productService.GetProducts();

            // assert           
          // mockRepository.VerifyAll(); // checking for mock everything is fine
          // mockRepository.Verify(x => x.GetProducts(), Times.Exactly(1));// checking for mock method called exactly no.of times
           //Assert.AreEqual(products.Count(), productList.Count); // checking for the count of result 

        }

        [Test]
        [ExpectedException(typeof(Exception))]
        public void test_mock()
        {
            // arrange
            var productService = new ProductService();

            // act
            productService.Test();

            // assert

            
        }

        [TearDown]
        public void TearDown()
        {

        }
    }
}
