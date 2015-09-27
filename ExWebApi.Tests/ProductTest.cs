using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;
using ExWebApi.Models;

namespace ExWebApi.Tests
{
    [TestFixture]
    public class ProductTest
    {
	
	
	
        [Test]
        public void Get_all_products_test()
        {
            // Arrange ---
            var controller = new ExWebApi.api.ProductController();

            // Act
            var products = controller.AllProducts();

            // Assert
            Assert.IsNotNull(products);
            Assert.Greater(products.Count(), 0);
        }

        [Test]
        public void Get_by_id_bad_request()
        {
            // arrange
            var controller = new ExWebApi.api.ProductController();
            var config = new HttpConfiguration();
            var request = new HttpRequestMessage(HttpMethod.Get,"http://localhost:52772/api/product");
            var route = config.Routes.MapHttpRoute("defaultapi", "api/{controller}/{id}");
            var routeData = new HttpRouteData(route, new HttpRouteValueDictionary { {"controller","product"} });
            controller.Request = request;
            controller.Request.Properties[System.Web.Http.Hosting.HttpPropertyKeys.HttpConfigurationKey] = config;

            // act
            var product = controller.ProductById(-1);
            

            // assert         
            Assert.AreEqual(HttpStatusCode.BadRequest, ((HttpResponseMessage)product).StatusCode);

        }
        public void Get_by_id_not_found()
        {
            // arrange
            var controller = new ExWebApi.api.ProductController();
            var config = new HttpConfiguration();
            var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:52772/api/product");
            var route = config.Routes.MapHttpRoute("defaultapi", "api/{controller}/{id}");
            var routeData = new HttpRouteData(route, new HttpRouteValueDictionary { { "controller", "product" } });
            controller.Request = request;
            controller.Request.Properties[System.Web.Http.Hosting.HttpPropertyKeys.HttpConfigurationKey] = config;

            // act
            var product = controller.ProductById(10000);


            // assert         
            Assert.AreEqual(HttpStatusCode.NotFound, ((HttpResponseMessage)product).StatusCode);

        }
        [Test]
        public void PostProduct()
        {
            // arrange
            var controller = new ExWebApi.api.ProductController();
            var config = new HttpConfiguration();
            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost:52772/api/product");
            var route = config.Routes.MapHttpRoute("defaultapi", "api/{controller}/{id}");
            var routeData = new HttpRouteData(route, new HttpRouteValueDictionary { { "controller", "product" } });
            controller.Request = request;
            controller.Request.Properties[System.Web.Http.Hosting.HttpPropertyKeys.HttpConfigurationKey] = config;

            // act
            var mock = new Product(){Id=100,Name="new prod", Price=12323.22};
            var product = controller.AddProduct(mock);



            // assert         
            Assert.AreEqual(HttpStatusCode.Created, ((HttpResponseMessage)product).StatusCode);

        }
    }
}
