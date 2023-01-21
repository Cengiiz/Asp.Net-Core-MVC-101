using Microsoft.AspNetCore.Mvc;
using MyAspNetCoreApp.Web.Models;

namespace MyAspNetCoreApp.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductRepository _productRepository;

        public ProductsController()
        {
            _productRepository = new ProductRepository();
            if(!_productRepository.GetAll().Any())
            {
                _productRepository.Add(new() { Id = 1, Name = "Kalem 1", Price = 100, Stock = 200 });
                _productRepository.Add(new() { Id = 2, Name = "Kalem 2", Price = 200, Stock = 300 });
                _productRepository.Add(new() { Id = 3, Name = "Kalem 3", Price = 300, Stock = 400 });
                _productRepository.Add(new() { Id = 4, Name = "Kalem 4", Price = 400, Stock = 500 });
            }
        }

        public IActionResult Index()
        {
            var products = _productRepository.GetAll();
            return View(products);
        }
    }
}
