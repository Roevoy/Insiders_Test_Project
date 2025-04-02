using Insiders_Test_Project.DataProviders.Interfaces;
using Insiders_Test_Project.Models;
using Microsoft.Data.SqlClient;

namespace Insiders_Test_Project.DataProviders.DefaultProviders
{
    public class OrderDataProvider : IOrderDataProvider
    {
        private readonly string _connectionString;
        private readonly CustomerDataProvider _customerDataProvider;
        private readonly ProductDataProvider _productDataProvider;
        public bool InsertOrder(Order order)
        {
            _customerDataProvider.GetCustomerById(order.CustomerId);
            string query = "INSERT INTO Orders (Id, CreatedDate, CustomerId) VALUES (@Id, @CreatedDate, @CustomerId)";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", order.Id);
                    command.Parameters.AddWithValue("@CreatedDate", order.CreatedDate);
                    command.Parameters.AddWithValue("@CustomerId", order.CustomerId);
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected == 0) throw new InvalidOperationException("Failed to insert the order to database");
                    return true;
                }
            }
        }
        public Order GetOrderById(Guid Id)
        {
            string query = "SELECT Id, CreatedDate, CustomerId FROM Orders WHERE Id = @Id";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", Id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Order Order = new Order
                            {
                                Id = reader.GetGuid(0),
                                CustomerId = reader.GetGuid(1),
                                CreatedDate = reader.GetDateTime(2)
                            };
                            return Order;
                        }
                        else
                        {
                            throw new KeyNotFoundException($"Order with ID {Id} is not found.");
                        }
                    }
                }
            }
        }
        public ICollection<Order> GetAllOrders()
        {
            string query = "SELECT Id, CustomerId, CreatedDate FROM Orders";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        var Orders = new List<Order>();
                        while (reader.Read())
                        {
                            Order Order = new Order
                            {
                                Id = reader.GetGuid(0),
                                CustomerId = reader.GetGuid(1),
                                CreatedDate = reader.GetDateTime(2)
                            };
                            Orders.Add(Order);
                        }
                        return Orders;
                    }
                }
            }
        }
        public bool AddProduct(Guid OrderId, Guid ProductId)
        {
            GetOrderById(OrderId);
            _productDataProvider.GetProductById(ProductId);
            string query = "INSERT INTO OrdersProducts (OrderId, ProductId) VALUES (@OrderId, @ProductId)";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@OrderId", OrderId);
                    command.Parameters.AddWithValue("@ProductId", ProductId);
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected == 0) throw new InvalidOperationException("Failed to add the product to the order.");
                    return true;
                }
            }
        }
        public bool RemoveProduct(Guid OrderId, Guid ProductId)
        {
            GetOrderById(OrderId);
            _productDataProvider.GetProductById(ProductId);
            string query = "DELETE FROM OrdersProducts WHERE OrderId = @OrderId AND ProductId = @ProductId";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@OrderId", OrderId);
                    command.Parameters.AddWithValue("@ProductId", ProductId);
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected == 0) throw new InvalidOperationException("Failed to delete the product from the order.");
                    return true;
                }
            }
        }
        public bool DeleteOrder(Guid Id)
        {
            string query = "DELETE FROM Orders WHERE Id = @Id";
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", Id);
                    int affectedRows = command.ExecuteNonQuery();
                    if (affectedRows == 0) throw new InvalidOperationException("Failed to delete the order.");
                    return true;
                }
            }
        }
    }
}
