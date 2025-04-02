using Insiders_Test_Project.Models;
using Microsoft.Data.SqlClient;
using Insiders_Test_Project.DataProviders.Interfaces;
using System.Data;

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
            string storedProcedureName = "";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    throw new NotImplementedException();
                }
            }
        }
        public Order GetOrderById(Guid Id)
        {
            string storedProcedureName = "";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    throw new NotImplementedException();
                }
            }
        }
        public ICollection<Order> GetAllOrders()
        {
            string storedProcedureName = "";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    throw new NotImplementedException();
                }
            }
        }
        public bool AddProduct(Guid OrderId, Guid ProductId)
        {
            GetOrderById(OrderId);
            _productDataProvider.GetProductById(ProductId);
            string storedProcedureName = "";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    throw new NotImplementedException();
                }
            }
        }
        public bool RemoveProduct(Guid OrderId, Guid ProductId)
        {
            GetOrderById(OrderId);
            _productDataProvider.GetProductById(ProductId);
            string storedProcedureName = "";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    throw new NotImplementedException();
                }
            }
        }
        public bool DeleteOrder(Guid Id)
        {

            string storedProcedureName = "";
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    throw new NotImplementedException();
                }
            }
        }
    }
}
