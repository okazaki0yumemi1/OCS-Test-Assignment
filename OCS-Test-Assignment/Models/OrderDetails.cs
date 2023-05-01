using System.Text.Json.Serialization;

namespace OCS_Test_Assignment.Models
{
    public class OrderDetails : Entity
    {
        public Guid Id { get; private set; }
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
