using Insiders_Test_Project.Models;

namespace Insiders_Test_Project.DataProviders.Interfaces
{
    public interface ICustomerDataProvider
    {
        bool DeleteCustomer(Guid Id);
        ICollection<Customer> GetAllCustomers();
        Customer GetCustomerById(Guid Id);
        bool InsertCustomer(Customer customer);
    }
}