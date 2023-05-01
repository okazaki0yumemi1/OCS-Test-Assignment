using System.ComponentModel.DataAnnotations;

namespace OCS_Test_Assignment.Models
{
    public class OrderDTO : Order
    {
        public OrderDTO(Guid id, IEnumerable<OrderDetailsDTO> orderDetails) : base(id, orderDetails)
        {
        }
        [Required]
        public Guid id { get; set; }
        public string status { get; set; }
        public IEnumerable<OrderDetailsDTO>  lines {get; set;}
    }
}
