namespace OCS_Test_Assignment.Models
{
    public class OrderDetails : Entity
    {
        Guid Id { get; set; }
        int Quantity { get; set; }
        public OrderDetails(Guid id, int quantity)
        {
            Id = id;
            Quantity = quantity;
        }
        public bool IsValid()
        {
            //Checking for invalid quantity:
            if (Quantity <= 0) return false;
            else return true;
        }
    }
}
