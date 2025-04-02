using Insiders_Test_Project.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Insiders_Test_Project.DataProviders
{
    public class ProductDataProvider
    {
        private readonly string _connectionString;
        public bool InsertProduct(Product product)
        {
            string query = "INSERT INTO Products (Id, Name, Price, Description) VALUES (@Id, @Name, @Price, @Description)";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", product.Id);
                    command.Parameters.AddWithValue("@Price", product.Price);
                    command.Parameters.AddWithValue("@Description", product.Description);
                    command.Parameters.AddWithValue("@Name", product.Name);
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected == 0) throw new InvalidOperationException("Failed to insert the product to database");
                    return true;
                }
            }
        }
        public Product GetProductById(Guid Id)
        {
            string query = "SELECT Id, Name, Price, Description FROM Products WHERE Id = @Id";
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
                            Product Product = new Product
                            {
                                Id = reader.GetGuid(0),
                                Name = reader.GetString(1),
                                Price = reader.GetDouble(2),
                                Description = reader.GetString(3)
                            };
                            return Product;
                        }
                        else
                        {
                            throw new KeyNotFoundException($"Product with ID {Id} is not found.");
                        }
                    }
                }
            }
        }
        public ICollection<Product> GetAllProducts()
        {
            string query = "SELECT Id, Name, Price, Description FROM Products";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        var Products = new List<Product>();
                        while (reader.Read())
                        {
                            Product Product = new Product
                            {
                                Id = reader.GetGuid(0),
                                Name = reader.GetString(1),
                                Price= reader.GetDouble(2),
                                Description = reader.GetString(3)
                            };
                            Products.Add(Product);
                        }
                        return Products;
                    }
                }
            }
        }
        public bool UpdateProduct(Guid Id, Product newProduct)
        {
            string query = "SELECT * FROM Products WHERE Id = @Id";
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var adapter = new SqlDataAdapter(query, connection))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@Id", Id);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "Products");
                    if (ds.Tables["Products"].Rows.Count == 0) throw new KeyNotFoundException($"Product with ID {Id} is not found.");
                    DataRow row = ds.Tables["Products"].Rows[0];
                    row["Name"] = newProduct.Name;
                    row["Price"] = newProduct.Price;
                    row["Description"] = newProduct.Description;
                    var builder = new SqlCommandBuilder(adapter);
                    int affected = adapter.Update(ds, "Products");
                    if (affected == 0) throw new InvalidOperationException("Failed to update the product.");
                    return true;
                }
            }
        }
        public bool DeleteProduct(Guid Id)
        {
            string query = "DELETE FROM Products WHERE Id = @Id";
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", Id);
                    int affectedRows = command.ExecuteNonQuery();
                    if (affectedRows == 0) throw new InvalidOperationException("Failed to delete the product.");
                    return true;
                }
            }
        }
    }
}
