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
                case "Pending payment": this.Status = newStatus; return true;
                default: return false;
            }
        }
        public bool DataIsValid()
        {
            //Checking if status is correct:
            switch (this.Status)
            {
                case "Paid": break;
                case "Sent": break;
                case "Delivered": break;
                case "Completed": break;
                case "Pending payment": break;
                default: return false;
            }

            //Checking if order has no items in it:
            if (this.Lines.Count() == 0) return false;

            //Checking validity of items inside Order:
            foreach (var line in this.Lines)
            {
                if (line.IsValid() == false) return false; 
            }
            //Guid can be checked via regex,
            //DateTime is assigned automatically but still needs to be checked.
            return true;
        }
    }
}
