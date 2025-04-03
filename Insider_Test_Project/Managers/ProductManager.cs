using Insiders_Test_Project.DataProviders.Interfaces;
using Insiders_Test_Project.Models;

namespace Insiders_Test_Project.Managers
{
    public class ProductManager
    {
        private readonly IProductDataProvider _provider;
        public ProductManager(IProductDataProvider provider)
        {
            _provider = provider;
        }
        public Guid CreateProduct(string name, string description, double price)
        {
            Product product = new Product
            {
                Id = Guid.NewGuid(),
                Name = name,
                Description = description,
                Price = price
                
            };
            _provider.InsertProduct(product);
            return product.Id;
        }
        public Product GetProductById(Guid Id)
        {
            return _provider.GetProductById(Id);
        }
        public ICollection<Product> GetAll() { return _provider.GetAllProducts(); }
        public bool DeleteProduct(Guid Id) { return _provider.DeleteProduct(Id); }
    }
}
