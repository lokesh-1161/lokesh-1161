using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Training_Application.Models;

namespace Training_Application.Controllers
{
    public class ProductController : Controller
    {
        private static List<Dictionary<string, string>> products = new List<Dictionary<string, string>>
        {
            new Dictionary<string, string> { { "Id", "101" }, { "Name", "Laptop" }, { "Price", "1200" } },
            new Dictionary<string, string> { { "Id", "102" }, { "Name", "Mouse" }, { "Price", "25" } }
        };

        public ActionResult Index()
        {
            ViewBag.ProductList = products;
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection form)
        {
            var newProduct = new Dictionary<string, string>
            {
                { "Id", form["Id"] },
                { "Name", form["Name"] },
                { "Price", form["Price"] }
            };

            products.Add(newProduct);
            return RedirectToAction("Index");
        }
    }
    }
