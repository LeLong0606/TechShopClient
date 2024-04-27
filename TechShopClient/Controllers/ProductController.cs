using Microsoft.AspNetCore.Mvc;
using TechShopClient.Models;
using TechShopClient.Services;

namespace TechShopClient.Controllers
{
    public class ProductController : Controller
    {
        private readonly APIGateway _APIGetway;
        public ProductController(APIGateway aPIGetway)
        {
            _APIGetway = aPIGetway;
        }

        public IActionResult Index()
        {
            List<Product> products;
            products = _APIGetway.ListProducts();
            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            Product product = new Product();
            return View(product);
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            _APIGetway.CreateProduct(product);
            return RedirectToAction("index");
        }

        public IActionResult Details(int Id)
        {
            Product product = new Product();
            product = _APIGetway.GetProduct(Id);
            return View(product);
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            Product product;
            product = _APIGetway.GetProduct(Id);
            return View(product);
        }
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            _APIGetway.UpdateProduct(product); 
            return RedirectToAction("index");
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            Product product;
            product = _APIGetway.GetProduct(Id);
            return View(product);
        }
        [HttpPost]
        public IActionResult Delete(Product product)
        {
            _APIGetway.DeleteProduct(product.id);
            return RedirectToAction("index");
        }
    }
}
