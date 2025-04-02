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
        public Product GetProductById(Guid Id)
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
        public ICollection<Product> GetAllProducts()
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
        public bool UpdateProduct(Guid Id, Product newProduct)
        {
            string query = "";
            string storedProcedureName = "";
            using (var connection = new SqlConnection(_connectionString))
            {
                throw new NotImplementedException();
            }
        }
        public bool DeleteProduct(Guid Id)
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
