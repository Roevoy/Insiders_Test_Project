using Insiders_Test_Project.DataProviders.Interfaces;
using Insiders_Test_Project.Models;

namespace Insiders_Test_Project.Managers
{
    public class OrderManager
    {
        private readonly IOrderDataProvider _provider;
        public OrderManager(IOrderDataProvider provider)
        {
            _provider = provider;
        }
        public Guid CreateOrder(Guid CustomerId)
        {
            Order order = new Order
            {
                Id = Guid.NewGuid(),
                CreatedDate = DateTime.Now,
                CustomerId = CustomerId
            };
            _provider.InsertOrder(order);
            return order.Id;
        }
        public Order GetOrderById(Guid Id)
        {
            return _provider.GetOrderById(Id);
        }
        public bool AddProduct (Guid orderId, Guid productId)
        {
            return _provider.AddProduct(orderId, productId);
        }
        public bool RemoveProduct (Guid orderId, Guid productId)
        {
            return _provider.RemoveProduct(orderId,productId);
        }
        public ICollection<Order> GetAll() { return _provider.GetAllOrders(); }
        public bool DeleteOrder(Guid Id) { return _provider.DeleteOrder(Id); }
    }
}
