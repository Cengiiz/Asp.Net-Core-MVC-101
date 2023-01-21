using MyAspNetCoreApp.Web.Models;

namespace MyAspNetCoreApp.Web.Models
{
    public class ProductRepository
    {
        private static List<Product> _products = new List<Product>()
        {
             new() { Id = 1, Name = "Kalem 1", Price = 100, Stock = 200 },
             new () { Id = 2, Name = "Kalem 2", Price = 200, Stock = 300 },
             new () { Id = 3, Name = "Kalem 3", Price = 300, Stock = 400 },
             new() { Id = 4, Name = "Kalem 4", Price = 400, Stock = 500 }
        };


        public List<Product> GetAll() => _products;

        public void Add(Product newProduct)=> _products.Add(newProduct);

        public void Update(Product updateproduct)
        {
            var hasProduct = _products.FirstOrDefault(x => x.Id == updateproduct.Id);

            if (hasProduct == null)
            {
                throw new Exception($"Bi id({updateproduct.Id})'ye sahip urun bulunmamaktadir");
            }
            hasProduct.Name = updateproduct.Name;
            hasProduct.Price = updateproduct.Price;
            hasProduct.Stock= updateproduct.Stock;
            var index = _products.FindIndex(x => x.Id == updateproduct.Id);
            _products[index] = hasProduct;
            
        }

        public void Remove(int id)
        {
            var hasProduct=_products.FirstOrDefault(x=>x.Id == id);

            if(hasProduct == null)
            {
                throw new Exception($"Bi id({id})'ye sahip urun bulunmamaktadir");
            }
            _products.Remove(hasProduct);

        }

    }
}
