using Insiders_Test_Project.DataProviders.Interfaces;
using Insiders_Test_Project.Models;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.ApplicationServices;

namespace Insiders_Test_Project.DataProviders.DefaultProviders
{
    public class CustomerDataProvider : ICustomerDataProvider
    {
        private readonly string _connectionString = "Server=;Database=;customer Id=;Password=;";
        private readonly UserDataProvider _userDataProvider;
        public bool InsertCustomer(Customer customer)
        {
            _userDataProvider.GetUserById(customer.UserId);
            string query = "INSERT INTO Customers (Id, UserId) VALUES (@Id, @UserId)";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", customer.Id);
                    command.Parameters.AddWithValue("@UserId", customer.UserId);
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected == 0) throw new InvalidOperationException("Failed to insert customer to database");
                    return true;
                }
            }
        }
        public Customer GetCustomerById(Guid Id)
        {
            string query = "SELECT Id, UserId FROM Customers WHERE Id = @Id";
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
                            Customer customer = new Customer
                            {
                                Id = reader.GetGuid(0),
                                UserId = reader.GetGuid(1)
                            };
                            return customer;
                        }
                        else
                        {
                            throw new KeyNotFoundException($"Customer with ID {Id} is not found.");
                        }
                    }
                }
            }
        }
        public ICollection<Customer> GetAllCustomers()
        {
            string query = "SELECT Id, UserId FROM Customers";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        var customers = new List<Customer>();
                        while (reader.Read())
                        {
                            Customer customer = new Customer
                            {
                                Id = reader.GetGuid(0),
                                UserId = reader.GetGuid(1)
                            };
                            customers.Add(customer);
                        }
                        return customers;
                    }
                }
            }
        }
        public bool DeleteCustomer(Guid Id)
        {
            string query = "DELETE FROM Customers WHERE Id = @Id";
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", Id);
                    int affectedRows = command.ExecuteNonQuery();
                    if (affectedRows == 0) throw new InvalidOperationException("Failed to delete the customer.");
                    return true;
                }
            }
        }
    }
}
