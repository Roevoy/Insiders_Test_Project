using Insiders_Test_Project.Models;

namespace Insiders_Test_Project.DataProviders.Interfaces
{
    public interface IProductDataProvider
    {
        bool DeleteProduct(Guid Id);
        ICollection<Product> GetAllProducts();
        Product GetProductById(Guid Id);
        bool InsertProduct(Product product);
        bool UpdateProduct(Guid Id, Product newProduct);
    }
}