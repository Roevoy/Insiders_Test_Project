namespace Insiders_Test_Project.Models
{
    public class Customer
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
