using Microsoft.AspNetCore.Mvc;

namespace MyAspNetCoreApp.Web.Controllers
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class OrnekController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.name = "Asp.Net Core ";
            ViewData["age"] = 30;
            ViewData["names"] = new List<string>() { "ahmet", "mehmet", "hasan" };

            ViewBag.person = new { id = 1, name = "ahmet", age = 23 };

            TempData["animals"] = new List<string>() { "dog", "cat", "bird" };


            var productList = new List<Product>()
            {
                new(){ Id=1, Name="Kalem"},
                new(){ Id = 2, Name = "Defter"},
                new(){ Id=3, Name="Silgi"}
            };

            return View(productList);
        }
        public IActionResult Index2()
        {
            return View();
        }
        public IActionResult ParametreView(int id)
        {
            return RedirectToAction("JsonResultParanetre", "Ornek", new {id=id});
        }
        public IActionResult JsonResultParanetre(int id)
        {
            return Json(new { Id=id});
        }



        public IActionResult ContentResult()
        {
            return Content("ContentResult");
        }
        public IActionResult JsonResult() 
        {
            return Json(new {Id=1,name="kalem 1",price=100});
        }
        public IActionResult EmptyResult()
        {
            return new EmptyResult();
        }
    }
}
