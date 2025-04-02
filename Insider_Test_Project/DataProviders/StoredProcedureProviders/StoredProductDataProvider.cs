using Insiders_Test_Project.Models;
using Microsoft.Data.SqlClient;
using System.Data;
using Insiders_Test_Project.DataProviders.Interfaces;

namespace Insiders_Test_Project.DataProviders.StoredProcedureProviders
{
    public class StoredProductDataProvider : IProductDataProvider
    {
        private readonly string _connectionString;
        public bool InsertProduct(Product product)
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
        public Product GetProductById(Guid Id)
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
        public ICollection<Product> GetAllProducts()
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
        public bool UpdateProduct(Guid Id, Product newProduct)
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
        public bool DeleteProduct(Guid Id)
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
