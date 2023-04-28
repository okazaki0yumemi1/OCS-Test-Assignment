using Microsoft.Net.Http.Headers;

namespace OCS_Test_Assignment.Models
{
    public class Order : Entity
    {
        private Guid Id { get; }
        private string Status { get; set; }
        private DateTime Created { get; set; }
        IEnumerable<OrderDetails> Lines { get; set; }
        public Order(Guid id, IEnumerable<OrderDetails> orderDetails)
        {
            Id = id;
            Status = "New";
            Created = DateTime.Now.ToUniversalTime();
            Lines = orderDetails;
        }
        public bool ChangeStatus(string newStatus)
        {
            switch (newStatus)
            {
                case "Paid": this.Status = newStatus; return true;
                case "Sent": this.Status = newStatus; return true;
                case "Delivered": this.Status = newStatus; return true;
                case "Completed": this.Status = newStatus; return true;
                default: return false;
            }
        }
    }
}
