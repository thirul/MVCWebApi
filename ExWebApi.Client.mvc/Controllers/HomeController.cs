using ExWebApi.Models;
using System.Web.Mvc;

namespace ExWebApi.Client.mvc.Controllers
{
    public class HomeController : Controller
    {
        private ProductServiceClient serviceClient = new ProductServiceClient();

        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index(string message)
        {
            ViewBag.Message = message;
            return View(serviceClient.GetProducts());
        }

        /// <summary>
        /// Details the specified view by id.
        /// </summary>
        /// <param name="viewById">The view by id.</param>
        /// <returns></returns>
        public ActionResult Detail(string viewById)
        {
            Product model = null;
            int id = -1;
            if (!string.IsNullOrEmpty(viewById) && int.TryParse(viewById, out id))
            {
                model = serviceClient.GetProduct(id);
            }

            return View(model);
        }

        /// <summary>
        /// Deletes the specified delete by id.
        /// </summary>
        /// <param name="deleteById">The delete by id.</param>
        /// <returns></returns>
        public ActionResult Delete(string deleteById)
        {
            int id = -1;
            var message = "Delete failed, Id does not exits";
            if (!string.IsNullOrEmpty(deleteById) && int.TryParse(deleteById, out id))
            {
                if (serviceClient.Delete(id))
                {
                    message = "Deleted successfully";
                }
            }
            return RedirectToAction("Index", new { message = message });
        }

        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View(new Product());
        }

        /// <summary>
        /// Creates the specified product.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (product != null)
            {
                if (serviceClient.Insert(product))
                {
                    return RedirectToAction("Index", new {message="Successfully created."});
                }
            }

            return RedirectToAction("Create", product);
        }

        /// <summary>
        /// Edits the specified product id.
        /// </summary>
        /// <param name="editById">The edit by id.</param>
        /// <returns></returns>
        public ActionResult Edit(string editById)
        {
            int id = -1;
            if (!string.IsNullOrEmpty(editById) && int.TryParse(editById, out id))
            {
                var product = serviceClient.GetProduct(id);
                if (product != null)
                {
                    return View(product);
                }
            }

            return View("Index");
        }

        /// <summary>
        /// Edits the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(Product model)
        {
            var message = "Update failed.";
            if (model != null)
            {
                if (serviceClient.Update(model))
                {
                    message = "Successfully updated";
                }
            }

            return RedirectToAction("Index", new { message = message });
        }
        /// <summary>
        /// Bies the J query.
        /// </summary>
        /// <returns></returns>
        public ActionResult ByJQuery()
        {
            return View();
        }
    }
}