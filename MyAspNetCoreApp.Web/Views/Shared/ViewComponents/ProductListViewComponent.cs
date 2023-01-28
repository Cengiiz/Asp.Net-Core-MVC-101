using Microsoft.AspNetCore.Mvc;
using MyAspNetCoreApp.Web.Models;
using MyAspNetCoreApp.Web.ViewModels;

namespace MyAspNetCoreApp.Web.Views.Shared.ViewComponents
{
    //[ViewComponent(Name ="p-list")] change component name
    public class ProductListViewComponent:ViewComponent
    {
        private readonly AppDbContext _context;

        public ProductListViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int type=1)
        {
            var viewmodles = _context.Products.Select(x => new ProductListComponentViewModel()
            {
                Name=x.Name,
                Description=x.Description
            }).ToList();
            if (type==1)
            {
                return View("Default",viewmodles);
            }
            else
            {
                return View("Type2",viewmodles);
            }
            
        }

    }
}
