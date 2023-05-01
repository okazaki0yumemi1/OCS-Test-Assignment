using System.ComponentModel.DataAnnotations;

namespace OCS_Test_Assignment.Models
{
    public class OrderDetailsDTO : OrderDetails
    {
        public OrderDetailsDTO(Guid id, int quantity) : base(id, quantity)
        {
        }
        [Required]
        public Guid id { get; set; }
        [Required]
        public int qty { get; set; }
    }
}
