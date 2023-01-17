using Microsoft.AspNetCore.Mvc;

namespace MyAspNetCoreApp.Web.Controllers
{
    public class OrnekController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Index2()
        {
            return RedirectToAction("Index");
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
