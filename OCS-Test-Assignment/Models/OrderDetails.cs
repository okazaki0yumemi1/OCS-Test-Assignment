//using System.Text.Json.Serialization;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OCS_Test_Assignment.Models
{
    [Table("OrderDetails")]
    public class OrderDetails : Entity
    {
        [Column("detail_id"), Key]
        public Guid Id { get; private set; }
        [Column("quantity")]
        public int Qty { get; private set; } //Quantity column id Db 
        public OrderDetails() { }
        public OrderDetails(string id, int quantity)
        {
            Guid.TryParse(id, out Guid result);
            Id = result;
            Qty = quantity;
        }
        public bool IsValid()
        {
            //Checking for invalid quantity:
            if (Qty <= 0) return false;
            else return true;
        }
    }
}
