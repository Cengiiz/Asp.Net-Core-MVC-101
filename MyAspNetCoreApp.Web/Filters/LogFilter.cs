using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace MyAspNetCoreApp.Web.Filters
{
    public class LogFilter:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Debug.WriteLine("Action Method calismadan once");
        }
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            Debug.WriteLine("Action Method calistiktan sonra");

        }
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            Debug.WriteLine("Action Method sonuc uretilmeden once");

        }
        public override void OnResultExecuted(ResultExecutedContext context)
        {
            Debug.WriteLine("Action Method sonuc uretildikten sonra");
        }
    }
}
