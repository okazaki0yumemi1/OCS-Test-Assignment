//using System.Text.Json.Serialization;

using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OCS_Test_Assignment.Models
{
    [Table("OrderDetails")]
    public class OrderDetails : Entity
    {
        [Key]
        public Guid Id { get; set; }
        public int Qty { get; set; }
        //[ForeignKey("Orders"), JsonIgnore]
        //public Order ParentOrder { get; set; }
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
