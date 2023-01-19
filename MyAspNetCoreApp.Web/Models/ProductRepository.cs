namespace MyAspNetCoreApp.Web.Models
{
    public class ProductRepository
    {
        private static List<Product> _products;


        public List<Product> Products() => _products;

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
