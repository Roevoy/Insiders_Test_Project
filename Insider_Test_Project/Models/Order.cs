namespace Insiders_Test_Project.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        //public ICollection<Product> Products { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
