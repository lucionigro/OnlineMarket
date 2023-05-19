using System.ComponentModel.DataAnnotations;

namespace WebApp.Data
{
    public class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }

        public int Id { get; set; }
        public decimal Price { get; set; }
        public bool Paid { get; set; }

        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
