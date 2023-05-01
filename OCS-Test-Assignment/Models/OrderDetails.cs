namespace OCS_Test_Assignment.Models
{
    public class OrderDetails : Entity
    {
        public Guid Id { get; set; }
        public int Qty { get; set; } //Quantity column id Db 
        public OrderDetails(Guid id, int quantity)
        {
            Id = id;
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
