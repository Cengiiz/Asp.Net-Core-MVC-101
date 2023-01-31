using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyAspNetCoreApp.Web.Filters;
using MyAspNetCoreApp.Web.Helpers;
using MyAspNetCoreApp.Web.Models;
using MyAspNetCoreApp.Web.ViewModels;

namespace MyAspNetCoreApp.Web.Controllers
{
    [Route("[controller]/[action]")]
    public class ProductsController : Controller
    {
        private AppDbContext _context;
        private readonly ProductRepository _productRepository;
        private IHelper _helper;
        private readonly IMapper _mapper;
        public ProductsController(AppDbContext context, IHelper helper, IMapper mapper)//dependency injection pattern-constructor injection
        {
            //DI Container
            _productRepository = new ProductRepository();
            _context = context;
            _helper = helper;
            _mapper = mapper;
            //Linq method
            //if (!_context.Products.Any())
            //{
            //    _context.Products.Add(new Product { Name = "Kalem 1", Price = 100, Stock = 300, Color = "Red" });
            //    _context.Products.Add(new Product { Name = "Kalem 2", Price = 200, Stock = 400, Color = "Red" });
            //    _context.Products.Add(new Product { Name = "Kalem 3", Price = 300, Stock = 500, Color = "Red" });
            //    _context.SaveChanges();
            //}

        }
        [CacheResourceFilter]
        public IActionResult Index([FromServices]IHelper helper2)//method injection
        {
            var text = "Asp.Net";
            var upperText = _helper.Upper(text);
            //IHelper helper=new Helper(); false
            var status = _helper.Equals(helper2);

            var products = _context.Products.ToList();


            return View(_mapper.Map<List<ProductViewModel>>(products));
        }
        [Route("[controller]/[action]/{page}/{pageSize}",Name ="productpage")]
        public IActionResult Pages(int page,int pageSize)
        {
            //page=1 pagesize=3 =>ilk 3 kayit
            //page=2 pagesize=3 =>ikinci 3 kayit
            //page=3 pagesize=3 =>ucuncu 3 kayit

            var products = _context.Products.Skip((page-1)*page).Take(pageSize).ToList();
            ViewBag.Page=page;
            ViewBag.PageSize=pageSize;


            return View(_mapper.Map<List<ProductViewModel>>(products));
        }

        [ServiceFilter(typeof(NotFoundFilter))]
        [Route("products/product/{productid}", Name ="product")]
        public IActionResult GetById(int productid)
        {
            var products=_context.Products.Find(productid);
            return View(_mapper.Map<ProductViewModel>(products));
        }

        [ServiceFilter(typeof(NotFoundFilter))]
        [HttpGet("{id}")]
        public IActionResult Remove(int id)
        {
            var product = _context.Products.Find(id);
            _context.Products.Remove(product);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Add()
        {
            ViewBag.Expire = new Dictionary<string, int>()
            {
                {"1. Month",1},
                {"3. Months",3},
                {"6. Months",6},
                {"12. Months",12}
            };
            //ViewBag.Expire = new List<string>() { "1. Month", "3. Months", "6. Months", "12. Months" };
            ViewBag.ColorSelect = new SelectList(new List<ColorSelectList>() {

                new(){Data="Blue",Value="Blue"},
                new(){Data="Red",Value="Red"},
                new(){Data="Yellow",Value="Yellow"}
            },"Value","Data");
            return View();
        }
        [HttpPost]
        public IActionResult Add(/*string Name, decimal Price, int Stock, string Color*/ ProductViewModel newProduct)
        {
            /*if (!string.IsNullOrEmpty(newProduct.Name) && newProduct.Name.StartsWith("A"))
            {
                ModelState.AddModelError(string.Empty, "Error Message");
            }*/
            ViewBag.Expire = new Dictionary<string, int>()
                {
                    {"1. Month",1},
                    {"3. Months",3},
                    {"6. Months",6},
                    {"12. Months",12}
                };
            //ViewBag.Expire = new List<string>() { "1. Month", "3. Months", "6. Months", "12. Months" };
            ViewBag.ColorSelect = new SelectList(new List<ColorSelectList>() {

                    new(){Data="Blue",Value="Blue"},
                    new(){Data="Red",Value="Red"},
                    new(){Data="Yellow",Value="Yellow"}
                }, "Value", "Data");
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Products.Add(_mapper.Map<Product>(newProduct));
                    _context.SaveChanges();

                    TempData["status"] = "Product successfully added";

                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    ModelState.AddModelError(string.Empty,"Error Message");
                    return View();
                }
                
            }
            else
            {

                return View();
            }
            //1. method
            //var name = HttpContext.Request.Form["Name"].ToString();
            //var price = decimal.Parse(HttpContext.Request.Form["Price"].ToString());
            //var stock = int.Parse(HttpContext.Request.Form["Stock"].ToString());
            //var color = HttpContext.Request.Form["Color"].ToString();
            //2. method
            //Product product = new Product() { Name=Name,Price=Price,Stock=Stock,Color=Color};

            
        }

        [ServiceFilter(typeof(NotFoundFilter))]
        [Route("{id}")]
        public IActionResult Update(int id)
        {
            var product=_context.Products.Find(id);
            if(product != null)
            {
                ViewBag.ExprieValue = product.Expire;
                ViewBag.Expire = new Dictionary<string, int>()
                {
                    {"1. Month",1},
                    {"3. Months",3},
                    {"6. Months",6},
                    {"12. Months",12}
                };
                //ViewBag.Expire = new List<string>() { "1. Month", "3. Months", "6. Months", "12. Months" };
                ViewBag.ColorSelect = new SelectList(new List<ColorSelectList>() {

                    new(){Data="Blue",Value="Blue"},
                    new(){Data="Red",Value="Red"},
                    new(){Data="Yellow",Value="Yellow"}
                }, "Value", "Data", product.Color);

            }

            return View(_mapper.Map<ProductViewModel>(product));
        }

        [HttpPost]
        public IActionResult Update(ProductViewModel newProduct,int id)
        {
            if(!ModelState.IsValid)
            {
                
                if (newProduct != null)
                {
                    ViewBag.ExprieValue = newProduct.Expire;
                    ViewBag.Expire = new Dictionary<string, int>()
                {
                    {"1. Month",1},
                    {"3. Months",3},
                    {"6. Months",6},
                    {"12. Months",12}
                };
                    //ViewBag.Expire = new List<string>() { "1. Month", "3. Months", "6. Months", "12. Months" };
                    ViewBag.ColorSelect = new SelectList(new List<ColorSelectList>() {

                    new(){Data="Blue",Value="Blue"},
                    new(){Data="Red",Value="Red"},
                    new(){Data="Yellow",Value="Yellow"}
                }, "Value", "Data", newProduct.Color);

                }
                return View();
            }
            else
            {
                _context.Products.Update(_mapper.Map<Product>(newProduct));
                _context.SaveChanges();
                TempData["status"] = "Product successfully updated";
                return RedirectToAction("Index");
            }
        }
        [AcceptVerbs("Get","Post")]
        public IActionResult HasProductName(string Name)
        {
            var anyProduct = _context.Products.Any(x => x.Name.ToLower() == Name.ToLower());
            if(anyProduct)
            {
                return Json("This product is in the database");
            }
            else
            {
                return Json(true);
            }
        }
    }
}
