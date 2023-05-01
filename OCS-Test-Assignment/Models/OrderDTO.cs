using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
//using System.Text.Json.Serialization;


namespace OCS_Test_Assignment.Models
{
    //[JsonObject(MemberSerialization.OptIn)]
    public class OrderDTO 
    {
        [JsonConstructor]
        public OrderDTO() { }
        [Required]
        [JsonProperty("id")]
        public string orderId { get; set; }
        [JsonProperty("status")]
        public string status { get; set; }
        public IEnumerable<OrderDetailsDTO>  lines {get; set;}
    }
}
