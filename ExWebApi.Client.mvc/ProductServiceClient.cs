using ExWebApi.Models;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;

namespace ExWebApi.Client.mvc
{
    public class ProductServiceClient
    {
        public IEnumerable<Product> GetProducts()
        {
            string _address = "http://localhost:52772/api/product";
            IEnumerable<Product> result = null;

            var client = new HttpClient();
            var task = client.GetAsync(_address).ContinueWith(
                (getTask) =>
                {
                    var response = getTask.Result;
                    response.EnsureSuccessStatusCode();

                    var readTask = response.Content.ReadAsAsync<IEnumerable<Product>>()
                        .ContinueWith((continueTask) =>
                        {
                            result = continueTask.Result;
                        });
                    readTask.Wait();
                }
                );

            task.Wait();

            return result;
        }

        public Product GetProduct(int productId)
        {
            string _address = "http://localhost:52772/api/product/" + productId.ToString();
            Product result = null;

            var client = new HttpClient();
            var task = client.GetAsync(_address).ContinueWith(
                (getTask) =>
                {
                    var response = getTask.Result;
                    response.EnsureSuccessStatusCode();

                    var readTask = response.Content.ReadAsAsync<Product>()
                        .ContinueWith((continueTask) =>
                        {
                            result = continueTask.Result;
                        });
                    readTask.Wait();
                }
                );

            task.Wait();

            return result;
        }

        public bool Insert(Product product)
        {
            bool result = false;
            if (product != null)
            {
                string _address = "http://localhost:52772/api/product/";
                var requestMessage = new HttpRequestMessage();
                var client = new HttpClient();
                HttpContent content = new ObjectContent<Product>(product, new JsonMediaTypeFormatter());
                var task = client.PostAsync(_address, content).ContinueWith(((getTask) =>
                    {
                        var response = getTask.Result;
                        if (response.StatusCode == HttpStatusCode.Created)
                        {
                            result = true;
                        }
                    }));
                task.Wait();
            }
            return result;
        }

        /// <summary>
        /// Deletes the specified product id.
        /// </summary>
        /// <param name="productId">The product id.</param>
        /// <returns></returns>
        public bool Delete(int productId)
        {
            bool result = false;

            string _address = "http://localhost:52772/api/product/" + productId.ToString();

            var client = new HttpClient();
            var task = client.DeleteAsync(_address).ContinueWith(
                (getTask) =>
                {
                    var response = getTask.Result;
                    result = response.IsSuccessStatusCode;
                }
                );

            task.Wait();

            return result;
        }
        /// <summary>
        /// Updates the specified product.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <returns></returns>
        public bool Update(Product product)
        {
            bool result = false;
            if (product != null)
            {
                string _address = "http://localhost:52772/api/product/";
                var requestMessage = new HttpRequestMessage();
                var client = new HttpClient();
                HttpContent content = new ObjectContent<Product>(product, new JsonMediaTypeFormatter());
                var task = client.PutAsync(_address, content).ContinueWith(((getTask) =>
                {
                    var response = getTask.Result;
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        result = true;
                    }
                }));
                task.Wait();
            }
            return result;
        }
    }
}