using Insiders_Test_Project.Models;
using Microsoft.Data.SqlClient;
using System.Data;
using Insiders_Test_Project.DataProviders.Interfaces;
using WinFormProject1;

namespace Insiders_Test_Project.DataProviders.StoredProcedureProviders
{
    public class StoredProductDataProvider : IProductDataProvider
    {
        private readonly string _connectionString = Program.ConnectionString;
        public bool InsertProduct(Product product)
        {
            
            string storedProcedureName = "InsertProduct";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@Id", SqlDbType.UniqueIdentifier));
                    command.Parameters["@Id"].Value = product.Id;
                    command.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar));
                    command.Parameters["@Name"].Value = product.Name;
                    command.Parameters.Add(new SqlParameter("@Description", SqlDbType.NVarChar));
                    command.Parameters["@Description"].Value = product.Description;
                    command.Parameters.Add(new SqlParameter("@Price", SqlDbType.Float));
                    command.Parameters["@Price"].Value = product.Price;
                    command.Parameters.Add(new SqlParameter("@OutputParameter", SqlDbType.Int));
                    command.Parameters["@OutputParameter"].Direction = ParameterDirection.ReturnValue;
                    command.ExecuteNonQuery();
                    if ((int)command.Parameters["@OutputParameter"].Value != 0)
                        throw new InvalidOperationException("Failed insert the product to DB.");
                    return true;
                }
            }
        }
        public Product GetProductById(Guid Id)
        {
            
            string storedProcedureName = "GetProductById";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@Id", SqlDbType.UniqueIdentifier));
                    command.Parameters["@Id"].Value = Id;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var product = new Product()
                            {
                                Id = reader.GetGuid(0),
                                Name = reader.GetString(1),
                                Description = reader.GetString(2),
                                Price = reader.GetDouble(3)
                            };
                            return product;
                        }
                        else throw new KeyNotFoundException($"Product with ID {Id} is not found.");
                    }
                }
            }
        }
        public ICollection<Product> GetAllProducts()
        {
            
            string storedProcedureName = "GetAllProducts";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        var products = new List<Product>();
                        while (reader.Read())
                        {
                            var product = new Product
                            {
                                Id = reader.GetGuid(0),
                                Name= reader.GetString(1),
                                Description = reader.GetString(2),
                                Price = reader.GetDouble(3)
                            };
                            products.Add(product);
                        }
                        return products;
                    }
                }
            }
        }
        public bool UpdateProduct(Guid Id, Product newProduct)
        {
            
            string storedProcedureName = "UpdateProduct";
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@Id", SqlDbType.UniqueIdentifier));
                    command.Parameters["@Id"].Value = Id;
                    command.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar));
                    command.Parameters["@Name"].Value = newProduct.Name;
                    command.Parameters.Add(new SqlParameter("@Description", SqlDbType.NVarChar));
                    command.Parameters["@Description"].Value = newProduct.Description;
                    command.Parameters.Add(new SqlParameter("@Price", SqlDbType.Float));
                    command.Parameters["@Price"].Value = newProduct.Price;

                    SqlParameter outputParam = new SqlParameter("@OutputParameter", SqlDbType.Int);
                    outputParam.Direction = ParameterDirection.ReturnValue;
                    command.Parameters.Add(outputParam);

                    command.ExecuteNonQuery();

                    if ((int)command.Parameters["@OutputParameter"].Value != 0)
                        throw new InvalidOperationException("Failed to update the product from DB.");
                    return true;
                }
            }
        }
        public bool DeleteProduct(Guid Id)
        {
            
            string storedProcedureName = "DeleteProduct";
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@Id", SqlDbType.UniqueIdentifier));
                    command.Parameters["@Id"].Value = Id;
                    command.Parameters.Add(new SqlParameter("@OutputParameter", SqlDbType.Int));
                    command.Parameters["@OutputParameter"].Direction = ParameterDirection.ReturnValue;
                    command.ExecuteNonQuery();
                    if ((int)command.Parameters["@OutputParameter"].Value != 0)
                        throw new InvalidOperationException("Failed to delete the product from DB.");
                    return true;
                }
            }
        }
    }
}
