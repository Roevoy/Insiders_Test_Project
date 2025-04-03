using Insiders_Test_Project.DataProviders.Interfaces;
using Insiders_Test_Project.Models;

namespace Insiders_Test_Project.Managers
{
    public class CustomerManager
    {
        private readonly ICustomerDataProvider _provider;
        public CustomerManager (ICustomerDataProvider provider)
        {
            _provider = provider;
        }
        public Guid CreateCustomer(Guid UserId)
        {
            Customer customer = new Customer
            {
                Id = Guid.NewGuid(),
                UserId = UserId
            };
            _provider.InsertCustomer(customer);
            return customer.Id;
        }
        public Customer GetCustomerById(Guid Id)
        {
            return _provider.GetCustomerById(Id);
        }
        public ICollection<Customer> GetAll() { return _provider.GetAllCustomers(); }
        public bool DeleteCustomer(Guid Id) { return _provider.DeleteCustomer(Id); }
    }
}
