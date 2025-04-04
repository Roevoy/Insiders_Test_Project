﻿using Insiders_Test_Project.Models;
using Microsoft.Data.SqlClient;
using Insiders_Test_Project.DataProviders.Interfaces;
using System.Data;
using WinFormProject1;

namespace Insiders_Test_Project.DataProviders.StoredProcedureProviders
{
    public class StoredOrderDataProvider : IOrderDataProvider
    {
        private readonly string _connectionString = Program.ConnectionString;
        public bool InsertOrder(Order order)
        {
            string storedProcedureName = "InsertOrder";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@Id", SqlDbType.UniqueIdentifier));
                    command.Parameters["@Id"].Value = order.Id;
                    command.Parameters.Add(new SqlParameter("@CustomerId", SqlDbType.UniqueIdentifier));
                    command.Parameters["@CustomerId"].Value = order.CustomerId;
                    command.Parameters.Add(new SqlParameter("@CreatedDate", SqlDbType.DateTime));
                    command.Parameters["@CreatedDate"].Value = order.CreatedDate;
                    command.Parameters.Add(new SqlParameter("@OutputParameter", SqlDbType.Int));
                    command.Parameters["@OutputParameter"].Direction = ParameterDirection.Output;
                    command.ExecuteNonQuery();
                    if ((int)command.Parameters["@OutputParameter"].Value != 0)
                        throw new InvalidOperationException("Failed insert the order to DB.");
                    return true;
                }
            }
        }
        public Order GetOrderById(Guid Id)
        {
            string storedProcedureName = "GetOrderById";
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
                            var order = new Order()
                            {
                                Id = reader.GetGuid(0),
                                CustomerId = reader.GetGuid(1),
                                CreatedDate = reader.GetDateTime(2)
                            };
                            return order;
                        }
                        else throw new KeyNotFoundException($"Order with ID {Id} is not found.");
                    }
                }
            }
        }
        public ICollection<Order> GetAllOrders()
        {
            string storedProcedureName = "GetAllOrders";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        var orders = new List<Order>();
                        while (reader.Read())
                        {
                            var order = new Order
                            {
                                Id = reader.GetGuid(0),
                                CustomerId = reader.GetGuid(1),
                                CreatedDate = reader.GetDateTime(2)
                            };
                            orders.Add(order);
                        }
                        return orders;
                    }
                }
            }
        }
        public bool AddProduct(Guid OrderId, Guid ProductId)
        {
            string storedProcedureName = "AddProduct";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@OrderId", SqlDbType.UniqueIdentifier));
                    command.Parameters["@OrderId"].Value = OrderId;
                    command.Parameters.Add(new SqlParameter("@ProductId", SqlDbType.UniqueIdentifier));
                    command.Parameters["@ProductId"].Value = ProductId;
                    command.Parameters.Add(new SqlParameter("@OutputParameter", SqlDbType.Int));
                    command.Parameters["@OutputParameter"].Direction = ParameterDirection.Output;
                    command.ExecuteNonQuery();
                    if ((int)command.Parameters["@OutputParameter"].Value != 0)
                        throw new InvalidOperationException("Failed add product to order in DB.");
                    return true;
                }
            }
        }
        public bool RemoveProduct(Guid OrderId, Guid ProductId)
        {
            string storedProcedureName = "RemoveProduct";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@OrderId", SqlDbType.UniqueIdentifier));
                    command.Parameters["@OrderId"].Value = OrderId;
                    command.Parameters.Add(new SqlParameter("@ProductId", SqlDbType.UniqueIdentifier));
                    command.Parameters["@ProductId"].Value = ProductId;
                    command.Parameters.Add(new SqlParameter("@OutputParameter", SqlDbType.Int));
                    command.Parameters["@OutputParameter"].Direction = ParameterDirection.Output;
                    command.ExecuteNonQuery();
                    if ((int)command.Parameters["@OutputParameter"].Value != 0)
                        throw new InvalidOperationException("Failed to remove the product from the order in DB.");
                    return true;
                }
            }
        }
        public bool DeleteOrder(Guid Id)
        {

            string storedProcedureName = "DeleteOrder";
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@Id", SqlDbType.UniqueIdentifier));
                    command.Parameters["@Id"].Value= Id;
                    command.Parameters.Add(new SqlParameter("@OutputParameter", SqlDbType.Int));
                    command.Parameters["@OutputParameter"].Direction = ParameterDirection.Output;
                    command.ExecuteNonQuery();
                    if ((int)command.Parameters["@OutputParameter"].Value != 0)
                        throw new InvalidOperationException("Failed to delete the order from DB.");
                    return true;
                }
            }
        }
    }
}
