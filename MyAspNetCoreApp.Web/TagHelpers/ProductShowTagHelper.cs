using Microsoft.AspNetCore.Razor.TagHelpers;
using MyAspNetCoreApp.Web.Models;

namespace MyAspNetCoreApp.Web.TagHelpers
{
    public class ProductShowTagHelper:TagHelper
    {
        public Product product { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Content.SetHtmlContent(@$"<ul class='list-group'>
                        <li class='list-group-item'>{product.Id}</li>
                        <li class='list-group-item'>{product.Name}</li>
                        <li class='list-group-item'>{product.Price}</li>
                        <li class='list-group-item'>{product.Stock}</li>
                        </ul>");
        }
    }
}
