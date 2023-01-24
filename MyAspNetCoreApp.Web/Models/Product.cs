namespace MyAspNetCoreApp.Web.Models
{
    public class Product
    {
        public int Id { get; set; }
        //.net 6 ile nullable ozelligi proptan ayarlanabilir 
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        public string? Color { get; set; }

        public bool IsPublish { get; set; }
    }
}
