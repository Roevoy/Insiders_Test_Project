using Insiders_Test_Project.Models;
using Microsoft.Data.SqlClient;
using Insiders_Test_Project.DataProviders.Interfaces;

namespace Insiders_Test_Project.DataProviders.StoredProcedureProviders
{
    public class StoredOrderDataProvider : IOrderDataProvider
    {
        private readonly string _connectionString;
        private readonly ICustomerDataProvider _customerDataProvider;
        private readonly IProductDataProvider _productDataProvider;
        public bool InsertOrder(Order order)
        {
            _customerDataProvider.GetCustomerById(order.CustomerId);
            string query = "";
            string storedProcedureName = "";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    throw new NotImplementedException();
                }
            }
        }
        public Order GetOrderById(Guid Id)
        {
            string query = "";
            string storedProcedureName = "";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    throw new NotImplementedException();
                }
            }
        }
        public ICollection<Order> GetAllOrders()
        {
            string query = "";
            string storedProcedureName = "";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    throw new NotImplementedException();
                }
            }
        }
        public bool AddProduct(Guid OrderId, Guid ProductId)
        {
            GetOrderById(OrderId);
            _productDataProvider.GetProductById(ProductId);
            string query = "";
            string storedProcedureName = "";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    throw new NotImplementedException();
                }
            }
        }
        public bool RemoveProduct(Guid OrderId, Guid ProductId)
        {
            GetOrderById(OrderId);
            _productDataProvider.GetProductById(ProductId);
            string query = "";
            string storedProcedureName = "";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    throw new NotImplementedException();
                }
            }
        }
        public bool DeleteOrder(Guid Id)
        {
            string query = "";
            string storedProcedureName = "";
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(query, connection))
                {
                    throw new NotImplementedException();
                }
            }
        }
    }
}
