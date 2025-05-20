using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Training_Application.Models;

namespace Training_Application.Controllers
{
    public class ProductController : Controller
    {
        // Static list to simulate a database
        private static List<Product> _products = new List<Product>();

        public IActionResult Index()
        {
            return View(_products);
        }

        [HttpPost]
        public IActionResult Add(Product product)
        {
            if (ModelState.IsValid)
            {
                _products.Add(product);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                _products.Remove(product);
            }
            return RedirectToAction("Index");
        }
    }
    }
