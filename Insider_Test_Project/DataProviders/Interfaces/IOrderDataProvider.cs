using Insiders_Test_Project.Models;

namespace Insiders_Test_Project.DataProviders.Interfaces
{
    public interface IOrderDataProvider
    {
        bool AddProduct(Guid OrderId, Guid ProductId);
        bool DeleteOrder(Guid Id);
        ICollection<Order> GetAllOrders();
        Order GetOrderById(Guid Id);
        bool InsertOrder(Order order);
        bool RemoveProduct(Guid OrderId, Guid ProductId);
    }
}