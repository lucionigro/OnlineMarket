using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Data
{
    public class Product
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }

        public int Id { get; set; }
        //[Required]
        //[DisplayName("Product Image")]
        //public string ProductImage { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(300)]
        public string Description { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
