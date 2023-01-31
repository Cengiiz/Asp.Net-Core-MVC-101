using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MyAspNetCoreApp.Web.Filters
{
    public class CacheResourceFilter : Attribute, IResourceFilter
    {
        private static IActionResult _cach; 
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            _cach = context.Result;
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            if (_cach!=null)
            {
                context.Result = _cach;
            }
        }
    }
}
